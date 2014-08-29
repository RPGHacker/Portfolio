

#pragma once

#include "Object.h"
#include "KokkuEntity.generated.h"

/**
 * Helper class for Kokku Engine's shared entity interface
 */
UINTERFACE(MinimalAPI, BlueprintType)
class UKokkuEntity : public UInterface
{
	GENERATED_UINTERFACE_BODY()
};

/**
* Kokku Engine's shared entity interface
*/
class KOKKUENGINE_API IKokkuEntity
{
	GENERATED_IINTERFACE_BODY()

	/** Entity is currently carriable */
	uint32 bIsCarryable : 1;

	/** Attach parent for being carried */
	USceneComponent* CarryAttachParent;

	/** Entity starts to be carried
	* @param		CarriedBy		The actor carrying this entity
	*/
	virtual void OnStartCarry(class AActor* CarriedBy);

	/** Entity stops to be carried
	* @param		CarriedBy		The actor carrying this entity
	* @param		InputVector		Input vector of actor carrying this entity
	*/
	virtual void OnStopCarry(class AActor* CarriedBy, FVector InputVector);
};