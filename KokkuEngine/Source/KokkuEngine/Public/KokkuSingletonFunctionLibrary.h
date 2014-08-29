

#pragma once

#include "Kismet/BlueprintFunctionLibrary.h"
#include "Kismet/GameplayStatics.h"
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
	static class UKokkuSingleton* GetKokkuSingleton();

	/** Return game instance
	* @param		WorldContextObject		An object to get world context from
	*/
	UFUNCTION(BlueprintPure, Category = "Kokku Game Instance", meta = (HidePin = "WorldContextObject", DefaultToSelf = "WorldContextObject"))
	static class UKokkuGameInstance* GetKokkuGameInstance(UObject* WorldContextObject);
};
