

#pragma once

#include "GameFramework/PlayerStart.h"
#include "KokkuPlayerStartByClass.generated.h"

/**
 * A player start based on player's class
 */
UCLASS()
class KOKKUENGINE_API AKokkuPlayerStartByClass : public APlayerStart
{
	GENERATED_UCLASS_BODY()

	/** The class of the player associated with this player start */
	UPROPERTY(EditInstanceOnly, Category = Player)
	UClass* PlayerClass;	
};
