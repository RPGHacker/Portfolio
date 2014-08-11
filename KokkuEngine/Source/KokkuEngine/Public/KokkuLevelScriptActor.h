

#pragma once

#include "Engine/LevelScriptActor.h"
#include "KokkuLevelScriptActor.generated.h"

/**
 * Kokku level blueprint override
 */
UCLASS(BlueprintType, Blueprintable, HideCategories=(Replication, Input, Actor, Tags))
class KOKKUENGINE_API AKokkuLevelScriptActor : public ALevelScriptActor
{
	GENERATED_UCLASS_BODY()

	/** This level's display name */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category=LevelSettings)
	FText LevelName;
};