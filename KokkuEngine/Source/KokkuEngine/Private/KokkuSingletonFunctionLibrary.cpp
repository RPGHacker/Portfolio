

#include "KokkuEngine.h"
#include "KokkuSingletonFunctionLibrary.h"


UKokkuSingletonFunctionLibrary::UKokkuSingletonFunctionLibrary(const class FObjectInitializer& PCIP)
	: Super(PCIP)
{
}

//////////////////////////////////////////////////////////////////////////
// Accessor

UKokkuSingleton* UKokkuSingletonFunctionLibrary::GetKokkuSingleton()
{
	if (GEngine)
	{
		class UKokkuSingleton* SingletonInstance = Cast<UKokkuSingleton>(GEngine->GameSingleton);

		if (!SingletonInstance || !(SingletonInstance->IsValidLowLevel())) return nullptr;

		return SingletonInstance;
	}

	return nullptr;
}

UKokkuGameInstance* UKokkuSingletonFunctionLibrary::GetKokkuGameInstance(UObject* WorldContextObject)
{
	UGameInstance* GameInstance = UGameplayStatics::GetGameInstance(WorldContextObject);

	if (GameInstance != nullptr)
	{
		UKokkuGameInstance* KokkuGameInstance = Cast<UKokkuGameInstance>(GameInstance);
		return KokkuGameInstance;
	}

	return nullptr;
}