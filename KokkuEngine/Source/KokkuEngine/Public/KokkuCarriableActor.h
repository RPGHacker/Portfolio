

#pragma once

#include "KokkuBaseActor.h"
#include "KokkuCarriableActor.generated.h"

/**
 * A simple carriable actor
 */
UCLASS()
class KOKKUENGINE_API AKokkuCarriableActor : public AKokkuBaseActor
{
	GENERATED_UCLASS_BODY()

	/** Object's collision box */
	UPROPERTY(Category = CarriableActor, VisibleAnywhere, BlueprintReadOnly)
	class UBoxComponent* CollisionBox;

	/** Constraint for locking object's rotation */
	UPROPERTY(Category = CarriableActor, VisibleAnywhere, BlueprintReadOnly)
	class UPhysicsConstraintComponent* PhysicsConstraint;

	// IKokkuEntity interface
	virtual void OnStartCarry(class AActor* CarriedBy) override;
	virtual void OnStopCarry(class AActor* CarriedBy, FVector InputVector) override;
	// IKokkuEntity interface end	
};
