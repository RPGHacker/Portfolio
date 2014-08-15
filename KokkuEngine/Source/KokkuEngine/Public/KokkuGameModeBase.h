

#pragma once

#include "GameFramework/GameMode.h"
#include "KokkuPlayerStartByID.h"
#include "KokkuPlayerStartByClass.h"
#include "KokkuGameModeBase.generated.h"

/**
 * Kokku Engine's base game mode
 */
UCLASS()
class KOKKUENGINE_API AKokkuGameModeBase : public AGameMode
{
	GENERATED_UCLASS_BODY()

	// AGameMode interface
	virtual class AActor* ChoosePlayerStart(AController* Player) override;
	// AGameMode interface end	
};
