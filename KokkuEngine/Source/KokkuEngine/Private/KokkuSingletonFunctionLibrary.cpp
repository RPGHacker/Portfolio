

#include "KokkuEngine.h"
#include "KokkuSingletonFunctionLibrary.h"


UKokkuSingletonFunctionLibrary::UKokkuSingletonFunctionLibrary(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
}

//////////////////////////////////////////////////////////////////////////
// Accessor

UKokkuSingleton* UKokkuSingletonFunctionLibrary::GetKokkuSingleton()
{
	UKokkuSingleton* SingletonInstance = Cast<UKokkuSingleton>(GEngine->GameSingleton);

	if (!SingletonInstance || !(SingletonInstance->IsValidLowLevel())) return nullptr;

	return SingletonInstance;
}