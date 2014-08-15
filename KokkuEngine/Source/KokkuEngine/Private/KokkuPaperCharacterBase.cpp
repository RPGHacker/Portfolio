

#include "KokkuEngine.h"
#include "KokkuPaperCharacterBase.h"


FName AKokkuPaperCharacterBase::KokkuSpriteComponentName(TEXT("Sprite0"));

AKokkuPaperCharacterBase::AKokkuPaperCharacterBase(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP.DoNotCreateDefaultSubobject(AKokkuPaperCharacterBase::KokkuSpriteComponentName))
{
	// Try to create the sprite component
	this->AnimatedSprite = PCIP.CreateDefaultSubobject<UKokkuPaperFlipbookComponent>(this, AKokkuPaperCharacterBase::KokkuSpriteComponentName);
	if (this->AnimatedSprite)
	{
		this->AnimatedSprite->AlwaysLoadOnClient = true;
		this->AnimatedSprite->AlwaysLoadOnServer = true;
		this->AnimatedSprite->bOwnerNoSee = false;
		this->AnimatedSprite->bAffectDynamicIndirectLighting = true;
		this->AnimatedSprite->PrimaryComponentTick.TickGroup = TG_PrePhysics;

		// force tick after movement component updates
		if (this->CharacterMovement)
		{
			this->AnimatedSprite->PrimaryComponentTick.AddPrerequisite(this, this->CharacterMovement->PrimaryComponentTick);
		}

		this->AnimatedSprite->AttachParent = this->CapsuleComponent;
		static FName CollisionProfileName(TEXT("CharacterMesh"));
		this->AnimatedSprite->SetCollisionProfileName(CollisionProfileName);
		this->AnimatedSprite->bGenerateOverlapEvents = false;
	}

	// Don't rotate when the controller rotates.
	this->bUseControllerRotationPitch = false;
	this->bUseControllerRotationYaw = false;
	this->bUseControllerRotationRoll = false;

	// Set the size of the collision capsule.
	this->CapsuleComponent->SetCapsuleHalfHeight(96.0f);
	this->CapsuleComponent->SetCapsuleRadius(40.0f);

	// Create an orthographic camera (no perspective) and attach it to the boom
	this->CharacterCamera = PCIP.CreateDefaultSubobject<UCameraComponent>(this, TEXT("SideViewCamera"));
	this->CharacterCamera->ProjectionMode = ECameraProjectionMode::Orthographic;
	this->CharacterCamera->OrthoWidth = 2048.0f;
	this->CharacterCamera->bUseControllerViewRotation = false;
	this->CharacterCamera->AttachTo(this->CapsuleComponent, NAME_None);
	this->CharacterCamera->SetRelativeLocation(FVector(0.0f, 500.0f, 0.0f));
	this->CharacterCamera->SetRelativeRotation(FRotator(0.0f, -90.0f, 0.0f));

	this->WalkingSpeed = 600.0f;
	this->RunningSpeed = 1500.0f;
	this->MaxJumpVelocity = 1000.0f;

	// Configure character movement
	this->CharacterMovement->bOrientRotationToMovement = false;
	this->CharacterMovement->NavAgentProps.bCanCrouch = true;
	this->CharacterMovement->bCanWalkOffLedgesWhenCrouching = true;
	this->CharacterMovement->CrouchedHalfHeight = 96.0f / 2.0f;
	this->CharacterMovement->GravityScale = 2.0f;
	this->CharacterMovement->AirControl = 0.80f;
	this->JumpMaxHoldTime = 0.25f;
	this->CharacterMovement->GroundFriction = 3.0f;
	this->CharacterMovement->MaxWalkSpeed = this->WalkingSpeed;
	this->CharacterMovement->MaxFlySpeed = this->RunningSpeed;
	this->CharacterMovement->JumpZVelocity = this->MaxJumpVelocity;
	this->CharacterMovement->MaxWalkSpeedCrouched = 0.0f;
	this->CharacterMovement->bUseFlatBaseForFloorChecks = true;

	// Lock character motion onto the XZ plane, so the character can't move in or out of the screen
	this->CharacterMovement->bConstrainToPlane = true;
	this->CharacterMovement->SetPlaneConstraintNormal(FVector(0.0f, -1.0f, 0.0f));

	// Enable tick
	this->PrimaryActorTick.bCanEverTick = true;
	this->SetActorTickEnabled(true);

	this->bRunButtonHeld = false;
}

//////////////////////////////////////////////////////////////////////////
// Logic

void AKokkuPaperCharacterBase::Tick(float DeltaSeconds)
{
	FVector CameraPosition = this->CharacterCamera->GetComponentLocation();
	this->CharacterCamera->bAbsoluteLocation = true;
	this->CharacterCamera->bAbsoluteRotation = true;
	CameraPosition.X = this->CapsuleComponent->GetComponentLocation().X;
	this->CharacterCamera->SetWorldLocation(CameraPosition);

	if (this->CharacterMovement->IsFalling())
	{
		if (this->bPressedJump)
			this->CharacterMovement->JumpZVelocity = (1.0f - FMath::Clamp<float>((this->JumpKeyHoldTime - (this->JumpMaxHoldTime * 0.25f)) / this->JumpMaxHoldTime, 0.0f, 0.75f)) * this->MaxJumpVelocity;
		else
			this->CharacterMovement->JumpZVelocity = this->MaxJumpVelocity * 0.25f;		// TODO: Fix me

		this->CharacterMovement->MaxWalkSpeedCrouched = this->CharacterMovement->MaxWalkSpeed;
	}
	else
	{
		if (this->bRunButtonHeld)
			this->CharacterMovement->MaxWalkSpeed = this->RunningSpeed;
		else
			this->CharacterMovement->MaxWalkSpeed = this->WalkingSpeed;

		this->CharacterMovement->MaxWalkSpeedCrouched = 0.0f;
	}

	this->UpdateAnimation();
}

void AKokkuPaperCharacterBase::UpdateAnimation()
{
	class UPaperFlipbook* NewAnimation = nullptr;
	bool bLoopAnimation = true;
	float PlayRate = 1.0f;

	if (!(this->CharacterMovement->IsFalling()))
	{
		// We are currently touching the ground
		float WalkSpeed = this->GetVelocity().X;

		if (WalkSpeed < 0.0f)
		{
			// We are facing left
			this->AnimatedSprite->SetRelativeRotation(FRotator(0.0, 180.0f, 0.0f));
		}
		else if (WalkSpeed > 0.0f)
		{
			// We are facing right
			this->AnimatedSprite->SetRelativeRotation(FRotator(0.0f, 0.0f, 0.0f));
		}

		WalkSpeed = FMath::Abs(WalkSpeed);

		if (this->bIsCrouched)
			NewAnimation = this->DuckAnimation;		// Currently ducking
		else if (WalkSpeed < 1.0f)
			NewAnimation = this->IdleAnimation;		// Standing still
		else if (this->bRunButtonHeld)
		{
			// Currently running
			PlayRate = FMath::Clamp<float>(WalkSpeed, this->CharacterMovement->MaxWalkSpeed * 0.1f, this->CharacterMovement->MaxWalkSpeed) / this->CharacterMovement->MaxWalkSpeed;
			NewAnimation = this->RunAnimation;
		}
		else
		{
			// Currently walking
			PlayRate = FMath::Clamp<float>(WalkSpeed, this->CharacterMovement->MaxWalkSpeed * 0.1f, this->CharacterMovement->MaxWalkSpeed) / this->CharacterMovement->MaxWalkSpeed;
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
	const bool bCanHoldToJumpHigher = (this->GetJumpMaxHoldTime() > 0.0f) && this->IsJumping();

	return this->CharacterMovement && (this->CharacterMovement->IsMovingOnGround() || bCanHoldToJumpHigher) && this->CharacterMovement->CanEverJump();
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
	if (this->CanJumpOverride())
		this->Jump();
}

void AKokkuPaperCharacterBase::JumpReleasedInput()
{
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
}

void AKokkuPaperCharacterBase::WalkLeftRightInput(float InputValue)
{
	this->AddMovementInput(FVector(1.0f, 0.0f, 0.0f), InputValue);
}