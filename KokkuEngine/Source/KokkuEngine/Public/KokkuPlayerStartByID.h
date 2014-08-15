

#pragma once

#include "GameFramework/PlayerStart.h"
#include "KokkuPlayerStartByID.generated.h"

/**
 * A player start based on player's controller ID
 */
UCLASS()
class KOKKUENGINE_API AKokkuPlayerStartByID : public APlayerStart
{
	GENERATED_UCLASS_BODY()

	/** The controller ID of the player associated with this player start */
	UPROPERTY(EditInstanceOnly, Category = Player)
	int32 PlayerControllerID;
};
