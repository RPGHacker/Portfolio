

#include "KokkuEngine.h"
#include "KokkuEntity.h"


UKokkuEntity::UKokkuEntity(const class FObjectInitializer& PCIP)
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