

#include "KokkuEngine.h"
#include "KokkuBaseActor.h"


AKokkuBaseActor::AKokkuBaseActor(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	// Create root component
	this->ActorRoot = PCIP.CreateDefaultSubobject<class USceneComponent>(this, FName(TEXT("ActorRoot")));
	this->RootComponent = this->ActorRoot;
}


