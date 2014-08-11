

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

	// AActor interface
	virtual void PostEditChangeProperty(FPropertyChangedEvent& PropertyChangedEvent) override;
	// AActor interface end

	/** This level's editable display name */
	UPROPERTY(EditDefaultsOnly, Category = LevelSettings, Meta = (DisplayName = "Level Name"))
	FString PublicLevelName;

	/** This level's localisable display name */
	UPROPERTY(BlueprintReadOnly, Category = LevelSettings)
	FText LevelName;
};