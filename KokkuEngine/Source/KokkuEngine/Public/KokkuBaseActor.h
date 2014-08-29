

#pragma once

#include "GameFramework/Actor.h"
#include "KokkuEntity.h"
#include "KokkuBaseActor.generated.h"

/**
 * Base class for kokku actors
 */
UCLASS(BlueprintType, Blueprintable, DefaultToInstanced, Abstract)
class KOKKUENGINE_API AKokkuBaseActor : public AActor, public IKokkuEntity
{
	GENERATED_UCLASS_BODY()

	/** Actor's root component */
	UPROPERTY(Category = KokkuActor, VisibleAnywhere, BlueprintReadOnly)
	TSubobjectPtr<class USceneComponent> ActorRoot;
};
