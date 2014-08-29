

#include "KokkuEngine.h"
#include "KokkuEntity.h"


UKokkuEntity::UKokkuEntity(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
}


//////////////////////////////////////////////////////////////////////////
// Carrying objects

void IKokkuEntity::OnStartCarry(class AActor* CarriedBy)
{
}

void IKokkuEntity::OnStopCarry(class AActor* CarriedBy, FVector InputVector)
{
}