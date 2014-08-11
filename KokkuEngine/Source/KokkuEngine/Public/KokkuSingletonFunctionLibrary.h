

#pragma once

#include "Kismet/BlueprintFunctionLibrary.h"
#include "KokkuSingleton.h"
#include "KokkuSingletonFunctionLibrary.generated.h"

/**
 * Kokku singleton function library
 */
UCLASS()
class KOKKUENGINE_API UKokkuSingletonFunctionLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_UCLASS_BODY()

	/** Return game's singleton */
	UFUNCTION(BlueprintPure, Category = "Kokku Singleton")
	static UKokkuSingleton* GetKokkuSingleton();
};
