

#include "KokkuEngine.h"
#include "KokkuPaperCharacterBase.h"


FName AKokkuPaperCharacterBase::KokkuSpriteComponentName(TEXT("Sprite0"));

AKokkuPaperCharacterBase::AKokkuPaperCharacterBase(const class FObjectInitializer& PCIP)
	: Super(PCIP.DoNotCreateDefaultSubobject(AKokkuPaperCharacterBase::KokkuSpriteComponentName))
{
	// Create anchor
	this->SpriteAnchor = PCIP.CreateDefaultSubobject<class USceneComponent>(this, TEXT("SpriteAnchor"));
	this->SpriteAnchor->AttachTo(this->GetCapsuleComponent());

	// Try to create the sprite component
	this->AnimatedSprite = PCIP.CreateDefaultSubobject<class UKokkuPaperFlipbookComponent>(this, AKokkuPaperCharacterBase::KokkuSpriteComponentName);
	if (this->AnimatedSprite)
	{
		this->AnimatedSprite->AlwaysLoadOnClient = true;
		this->AnimatedSprite->AlwaysLoadOnServer = true;
		this->AnimatedSprite->bOwnerNoSee = false;
		this->AnimatedSprite->bAffectDynamicIndirectLighting = true;
		this->AnimatedSprite->PrimaryComponentTick.TickGroup = TG_PrePhysics;

		// force tick after movement component updates
		if (this->GetCharacterMovement())
		{
			this->AnimatedSprite->PrimaryComponentTick.AddPrerequisite(this, this->GetCharacterMovement()->PrimaryComponentTick);
		}

		this->AnimatedSprite->AttachParent = this->SpriteAnchor;
		static FName CollisionProfileName(TEXT("CharacterMesh"));
		this->AnimatedSprite->SetCollisionProfileName(CollisionProfileName);
		this->AnimatedSprite->bGenerateOverlapEvents = false;
	}

	// Don't rotate when the controller rotates.
	this->bUseControllerRotationPitch = false;
	this->bUseControllerRotationYaw = false;
	this->bUseControllerRotationRoll = false;

	// Set the size of the collision capsule.
	this->GetCapsuleComponent()->SetCapsuleHalfHeight(96.0f);
	this->GetCapsuleComponent()->SetCapsuleRadius(40.0f);

	// Create an orthographic camera (no perspective) and attach it to the boom
	this->CharacterCamera = PCIP.CreateDefaultSubobject<class UCameraComponent>(this, TEXT("SideViewCamera"));
	this->CharacterCamera->ProjectionMode = ECameraProjectionMode::Orthographic;
	this->CharacterCamera->OrthoWidth = 4096.0f;
	this->CharacterCamera->bUsePawnControlRotation = false;
	this->CharacterCamera->AttachTo(this->GetCapsuleComponent(), NAME_None);
	this->CharacterCamera->SetRelativeLocation(FVector(0.0f, 1000.0f, 500.0f));
	this->CharacterCamera->SetRelativeRotation(FRotator(0.0f, -90.0f, 0.0f));

	// Create carry anchor
	this->CarryAnchor = PCIP.CreateDefaultSubobject<class USceneComponent>(this, TEXT("CarryAnchor"));
	this->CarryAnchor->AttachTo(this->SpriteAnchor, NAME_None);
	this->CarryAnchor->SetRelativeLocation(FVector(50.0f, 0.0f, 0.0f));

	// Create carry sphere
	this->CarrySphere = PCIP.CreateDefaultSubobject<class USphereComponent>(this, TEXT("CarrySphere"));
	this->CarrySphere->SetSphereRadius(25.0f, false);
	this->CarrySphere->SetCollisionProfileName(FName(TEXT("WorldDynamic")));
	this->CarrySphere->SetCollisionObjectType(ECollisionChannel::ECC_WorldDynamic);
	this->CarrySphere->SetCollisionEnabled(ECollisionEnabled::QueryOnly);
	this->CarrySphere->SetCollisionResponseToAllChannels(ECollisionResponse::ECR_Overlap);
	this->CarrySphere->SetSimulatePhysics(false);
	this->CarrySphere->SetEnableGravity(false);
	this->CarrySphere->AttachTo(this->SpriteAnchor, NAME_None);
	this->CarrySphere->SetRelativeLocation(FVector(this->GetCapsuleComponent()->GetUnscaledCapsuleRadius() + this->CarrySphere->GetScaledSphereRadius(), 0.0f, this->CarrySphere->GetScaledSphereRadius() - this->GetCapsuleComponent()->GetUnscaledCapsuleHalfHeight()));

	this->WalkingSpeed = 800.0f;
	this->RunningSpeed = 2000.0f;
	this->RunningJumpVelocityBonus = 0.25f;
	this->bDisableAnalogWalking = false;

	// Configure character movement
	this->GetCharacterMovement()->bOrientRotationToMovement = false;
	this->GetCharacterMovement()->NavAgentProps.bCanCrouch = true;
	this->GetCharacterMovement()->bCanWalkOffLedgesWhenCrouching = true;
	this->GetCharacterMovement()->CrouchedHalfHeight = 96.0f / 2.0f;
	this->GetCharacterMovement()->GravityScale = 2.0f;
	this->GetCharacterMovement()->AirControl = 0.80f;
	this->JumpMaxHoldTime = 0.25f;
	this->GetCharacterMovement()->GroundFriction = 3.0f;
	this->GetCharacterMovement()->MaxWalkSpeed = this->WalkingSpeed;
	this->GetCharacterMovement()->MaxFlySpeed = this->RunningSpeed;
	this->GetCharacterMovement()->JumpZVelocity = 750.0f;
	this->GetCharacterMovement()->MaxWalkSpeedCrouched = 0.0f;
	this->GetCharacterMovement()->bUseFlatBaseForFloorChecks = true;

	// Lock character motion onto the XZ plane, so the character can't move in or out of the screen
	this->GetCharacterMovement()->bConstrainToPlane = true;
	this->GetCharacterMovement()->SetPlaneConstraintNormal(FVector(0.0f, -1.0f, 0.0f));

	// Enable tick
	this->PrimaryActorTick.bCanEverTick = true;
	this->SetActorTickEnabled(true);

	this->bRunButtonHeld = false;
	this->CarriedActor = nullptr;

	// Entity interface
	this->CarryAttachParent = this->CarryAnchor;
}

//////////////////////////////////////////////////////////////////////////
// Logic

void AKokkuPaperCharacterBase::BeginPlay()
{
	Super::BeginPlay();

	this->InitialJumpVelocity = this->GetCharacterMovement()->JumpZVelocity;
}

void AKokkuPaperCharacterBase::Tick(float DeltaSeconds)
{
	Super::Tick(DeltaSeconds);

	// Update camera
	FVector CameraPosition = this->CharacterCamera->GetComponentLocation();
	this->CharacterCamera->bAbsoluteLocation = true;
	this->CharacterCamera->bAbsoluteRotation = true;
	CameraPosition.X = this->GetCapsuleComponent()->GetComponentLocation().X;
	this->CharacterCamera->SetWorldLocation(CameraPosition);

	// Jump physics
	float JumpSpeed = this->GetVelocity().Z;
	if (JumpSpeed < 0.0f)
		this->bJumpButtonHeld = false;
	
	if (this->GetCharacterMovement()->IsFalling())
	{
		this->GetCharacterMovement()->MaxWalkSpeedCrouched = this->GetCharacterMovement()->MaxWalkSpeed;
	}
	else
	{
		if (this->bRunButtonHeld)
			this->GetCharacterMovement()->MaxWalkSpeed = this->RunningSpeed;
		else
			this->GetCharacterMovement()->MaxWalkSpeed = this->WalkingSpeed;

		float JumpVelocityBonus = FMath::Clamp<float>((FMath::Abs(this->GetVelocity().X) - this->WalkingSpeed) / (this->RunningSpeed / this->WalkingSpeed), 0.0f, 1.0f) * this->RunningJumpVelocityBonus * this->InitialJumpVelocity;
		this->GetCharacterMovement()->JumpZVelocity = this->InitialJumpVelocity + JumpVelocityBonus;

		this->GetCharacterMovement()->MaxWalkSpeedCrouched = 0.0f;
	}

	// Carrying objects
	if (this->CarriedActor == nullptr)
	{
		if (this->bRunButtonHeld)
		{
			TArray<class AActor*> OverlappingActors;
			this->CarrySphere->GetOverlappingActors(OverlappingActors, nullptr);

			// Find carriable actor
			class AActor* FoundActor = nullptr;
			class IKokkuEntity* InterfaceInstance = nullptr;

			for (TArray<class AActor*>::TIterator ActorIter(OverlappingActors); ActorIter && !FoundActor; ++ActorIter)
			{
				class AActor* CurrentActor = *ActorIter;
				InterfaceInstance = Cast<IKokkuEntity>(CurrentActor);

				if (InterfaceInstance != nullptr && InterfaceInstance->bIsCarryable)
					FoundActor = CurrentActor;
			}

			// Carry object if found
			if (FoundActor != nullptr && InterfaceInstance != nullptr)
			{
				this->CarriedActor = FoundActor;
				InterfaceInstance->OnStartCarry(this);
			}
		}
	}

	this->UpdateAnimation();
}

void AKokkuPaperCharacterBase::UpdateAnimation()
{
	class UPaperFlipbook* NewAnimation = nullptr;
	bool bLoopAnimation = true;
	float PlayRate = 1.0f;

	if (!(this->GetCharacterMovement()->IsFalling()))
	{
		// We are currently touching the ground
		float WalkSpeed = this->GetVelocity().X;

		if (WalkSpeed < 0.0f)
		{
			// We are facing left
			this->SpriteAnchor->SetRelativeRotation(FRotator(0.0, 180.0f, 0.0f));
		}
		else if (WalkSpeed > 0.0f)
		{
			// We are facing right
			this->SpriteAnchor->SetRelativeRotation(FRotator(0.0f, 0.0f, 0.0f));
		}

		WalkSpeed = FMath::Abs(WalkSpeed);

		if (this->bIsCrouched)
			NewAnimation = this->DuckAnimation;		// Currently ducking
		else if (WalkSpeed < 1.0f)
			NewAnimation = this->IdleAnimation;		// Standing still
		else if (this->bRunButtonHeld && FMath::Abs(this->GetVelocity().X) >= this->WalkingSpeed)
		{
			// Currently running
			PlayRate = FMath::Clamp<float>(WalkSpeed, this->GetCharacterMovement()->MaxWalkSpeed * 0.1f, this->GetCharacterMovement()->MaxWalkSpeed) / this->GetCharacterMovement()->MaxWalkSpeed;
			NewAnimation = this->RunAnimation;
		}
		else
		{
			// Currently walking
			PlayRate = FMath::Clamp<float>(WalkSpeed, this->GetCharacterMovement()->MaxWalkSpeed * 0.1f, this->GetCharacterMovement()->MaxWalkSpeed) / this->GetCharacterMovement()->MaxWalkSpeed;
			NewAnimation = this->WalkAnimation;
		}
	}
	else
	{
		// We are currently in air
		if (this->bIsCrouched)			
			NewAnimation = this->DuckAnimation;		// In air and ducking
		else
		{
			float JumpSpeed = this->GetVelocity().Z;

			if (JumpSpeed < 0.0f)
				NewAnimation = this->FallAnimation;		// In are and falling
			else
			{
				NewAnimation = this->JumpAnimation;		// In are and jumping
				if (JumpSpeed < 100.0f)
					bLoopAnimation = false;			// Low jumping speed, so end loop to transition to fall animation
			}
		}
	}

	float TotalSpeed = this->GetVelocity().Size();

	if (NewAnimation != nullptr)
		this->AnimatedSprite->SetFlipbook(NewAnimation);
	this->AnimatedSprite->SetLooping(bLoopAnimation);
	this->AnimatedSprite->SetPlayRate(PlayRate);
}

bool AKokkuPaperCharacterBase::CanJumpOverride()
{
	// TODO: Fix me
	const bool bCanHoldToJumpHigher = (this->GetJumpMaxHoldTime() > 0.0f) && this->IsJumpProvidingForce();

	return this->GetCharacterMovement() && (this->GetCharacterMovement()->IsMovingOnGround() || bCanHoldToJumpHigher) && this->GetCharacterMovement()->CanEverJump();
}

bool AKokkuPaperCharacterBase::CanCrouch()
{
	return true;
}

//////////////////////////////////////////////////////////////////////////
// Input

void AKokkuPaperCharacterBase::SetupPlayerInputComponent(class UInputComponent* InputComponent)
{
	InputComponent->BindAction("Jump", IE_Pressed, this, &AKokkuPaperCharacterBase::JumpPressedInput).bConsumeInput = false;
	InputComponent->BindAction("Jump", IE_Released, this, &AKokkuPaperCharacterBase::JumpReleasedInput).bConsumeInput = false;
	InputComponent->BindAction("Duck", IE_Pressed, this, &AKokkuPaperCharacterBase::DuckPressedInput).bConsumeInput = false;
	InputComponent->BindAction("Duck", IE_Released, this, &AKokkuPaperCharacterBase::DuckReleasedInput).bConsumeInput = false;
	InputComponent->BindAction("Run", IE_Pressed, this, &AKokkuPaperCharacterBase::RunPressedInput).bConsumeInput = false;
	InputComponent->BindAction("Run", IE_Released, this, &AKokkuPaperCharacterBase::RunReleasedInput).bConsumeInput = false;
	InputComponent->BindAxis("WalkLeftRight", this, &AKokkuPaperCharacterBase::WalkLeftRightInput).bConsumeInput = false;
}

void AKokkuPaperCharacterBase::JumpPressedInput()
{
	this->bJumpButtonHeld = true;
	if (this->CanJumpOverride())
	{
		this->LaunchCharacter(FVector(0.0f, 0.0f, this->GetCharacterMovement()->JumpZVelocity), false, false);
		this->Jump();
	}
}

void AKokkuPaperCharacterBase::JumpReleasedInput()
{
	if (this->IsJumpProvidingForce() || this->bJumpButtonHeld)
		this->LaunchCharacter(FVector(0.0f, 0.0f, -(this->GetVelocity().Z * 0.5f)), false, false);
	this->bJumpButtonHeld = false;
	this->StopJumping();
}

void AKokkuPaperCharacterBase::DuckPressedInput()
{
	if (this->CanCrouch())
		this->Crouch(false);
}

void AKokkuPaperCharacterBase::DuckReleasedInput()
{
	this->UnCrouch(false);
}

void AKokkuPaperCharacterBase::RunPressedInput()
{
	this->bRunButtonHeld = true;
}

void AKokkuPaperCharacterBase::RunReleasedInput()
{
	this->bRunButtonHeld = false;

	if (this->CarriedActor != nullptr)
	{
		class IKokkuEntity* InterfaceInstance = Cast<IKokkuEntity>(this->CarriedActor);

		if (InterfaceInstance != nullptr)
		{
			InterfaceInstance->OnStopCarry(this, FVector(0.0f, -1.0f, 0.0f));
		}

		this->CarriedActor = nullptr;
	}
}

void AKokkuPaperCharacterBase::WalkLeftRightInput(float InputValue)
{
	float NormalizedInput = InputValue;

	if (this->bDisableAnalogWalking)
	{
		if (InputValue > 0.1f)
			NormalizedInput = 1.0f;
		else if (InputValue < -0.1f)
			NormalizedInput = -1.0f;
		else
			NormalizedInput = 0.0f;
	}

	this->AddMovementInput(FVector(1.0f, 0.0f, 0.0f), NormalizedInput);
}