

#include "KokkuEngine.h"
#include "KokkuCarriableActor.h"


AKokkuCarriableActor::AKokkuCarriableActor(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	// Create collision box
	this->CollisionBox = PCIP.CreateDefaultSubobject<class UBoxComponent>(this, FName(TEXT("CollisionBox")));
	this->CollisionBox->bAbsoluteRotation = true;
	this->CollisionBox->InitBoxExtent(FVector(50.0f, 50.0f, 50.0f));
	this->CollisionBox->SetCollisionProfileName(FName(TEXT("WorldDynamic")));
	this->CollisionBox->SetCollisionObjectType(ECollisionChannel::ECC_WorldDynamic);
	this->CollisionBox->SetCollisionEnabled(ECollisionEnabled::QueryAndPhysics);
	this->CollisionBox->SetCollisionResponseToAllChannels(ECollisionResponse::ECR_Overlap);
	this->CollisionBox->SetCollisionResponseToChannel(ECollisionChannel::ECC_WorldStatic, ECollisionResponse::ECR_Block);
	//this->CollisionBox->SetCollisionResponseToChannel(ECollisionChannel::ECC_WorldDynamic, ECollisionResponse::ECR_Block);
	//this->CollisionBox->SetCollisionResponseToChannel(ECollisionChannel::ECC_Pawn, ECollisionResponse::ECR_Block);
	this->CollisionBox->SetSimulatePhysics(true);
	this->CollisionBox->SetEnableGravity(true);
	this->CollisionBox->AttachTo(this->ActorRoot);

	// Create physics constraint
	this->PhysicsConstraint = PCIP.CreateDefaultSubobject<class UPhysicsConstraintComponent>(this, FName(TEXT("PhysicsConstraint")));
	this->PhysicsConstraint->SetLinearXLimit(ELinearConstraintMotion::LCM_Free, 0.0f);
	this->PhysicsConstraint->SetLinearYLimit(ELinearConstraintMotion::LCM_Locked, 0.0f);
	this->PhysicsConstraint->SetLinearZLimit(ELinearConstraintMotion::LCM_Free, 0.0f);
	this->PhysicsConstraint->SetAngularSwing1Limit(EAngularConstraintMotion::ACM_Locked, 0.0f);
	this->PhysicsConstraint->SetAngularSwing2Limit(EAngularConstraintMotion::ACM_Locked, 0.0f);
	this->PhysicsConstraint->SetAngularTwistLimit(EAngularConstraintMotion::ACM_Locked, 0.0f);
	this->PhysicsConstraint->ComponentName1.ComponentName = FName(TEXT("ActorRoot"));
	this->PhysicsConstraint->ComponentName2.ComponentName = FName(TEXT("CollisionBox"));
	this->PhysicsConstraint->bWantsInitializeComponent = true;
	this->PhysicsConstraint->AttachTo(this->CollisionBox);

	// Make object carriable
	this->bIsCarryable = true;
}


//////////////////////////////////////////////////////////////////////////
// Carrying functions

void AKokkuCarriableActor::OnStartCarry(class AActor* CarriedBy)
{
	class IKokkuEntity* InterfaceInstance = InterfaceCast<class IKokkuEntity>(CarriedBy);

	if (InterfaceInstance != nullptr && InterfaceInstance->CarryAttachParent != nullptr)
	{
		this->CollisionBox->SetSimulatePhysics(false);
		this->CollisionBox->SetCollisionEnabled(ECollisionEnabled::NoCollision);
		this->PhysicsConstraint->ConstraintInstance.TermConstraint();
		this->CollisionBox->AttachTo(InterfaceInstance->CarryAttachParent, NAME_None, EAttachLocation::KeepWorldPosition);
		this->CollisionBox->SetRelativeLocation(FVector::ZeroVector);
	}
}

void AKokkuCarriableActor::OnStopCarry(class AActor* CarriedBy, FVector InputVector)
{
	class IKokkuEntity* InterfaceInstance = InterfaceCast<class IKokkuEntity>(CarriedBy);

	if (InterfaceInstance != nullptr && InterfaceInstance->CarryAttachParent != nullptr)
	{
		FVector ImpulseVector = FVector(InputVector.X, 0.0f, -(InputVector.Y)) * 1000.0f;

		this->CollisionBox->AttachTo(this->ActorRoot, NAME_None, EAttachLocation::KeepWorldPosition);
		this->CollisionBox->SetSimulatePhysics(true);
		this->CollisionBox->SetCollisionEnabled(ECollisionEnabled::QueryAndPhysics);
		this->CollisionBox->WakeAllRigidBodies();
		this->PhysicsConstraint->bWantsInitializeComponent = true;
		this->PhysicsConstraint->InitializeComponent();
		this->CollisionBox->AddImpulse(ImpulseVector, NAME_None, true);
	}
}


