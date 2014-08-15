

#include "KokkuEngine.h"
#include "KokkuGameModeBase.h"


AKokkuGameModeBase::AKokkuGameModeBase(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
}

//////////////////////////////////////////////////////////////////////////
// Game start

AActor* AKokkuGameModeBase::ChoosePlayerStart(AController* Player)
{
	for (int32 PlayerStartIndex = 0; PlayerStartIndex < this->PlayerStarts.Num(); ++PlayerStartIndex)
	{
		// Player start by controller ID
		AKokkuPlayerStartByID* PlayerStartByID = Cast<AKokkuPlayerStartByID>(this->PlayerStarts[PlayerStartIndex]);

		if (PlayerStartByID != nullptr)
		{
			APlayerController* PlayerController = Cast<APlayerController>(Player);

			if (PlayerController != nullptr)
			{
				ULocalPlayer* LocalPlayer = Cast<ULocalPlayer>(PlayerController->Player);

				if (LocalPlayer != nullptr && LocalPlayer->ControllerId == PlayerStartByID->PlayerControllerID)
					return PlayerStartByID;
			}
		}

		// Player start by class (exact class)
		AKokkuPlayerStartByClass* PlayerStartByClass = Cast<AKokkuPlayerStartByClass>(this->PlayerStarts[PlayerStartIndex]);

		if (PlayerStartByClass != nullptr)
		{
			APawn* ControlledPawn = Player->GetControlledPawn();

			if (ControlledPawn != nullptr && ControlledPawn->GetClass() == PlayerStartByClass->PlayerClass)
				return PlayerStartByClass;
		}
	}

	for (int32 PlayerStartIndex = 0; PlayerStartIndex < this->PlayerStarts.Num(); ++PlayerStartIndex)
	{
		// Player start by class (is child of)
		AKokkuPlayerStartByClass* PlayerStartByClass = Cast<AKokkuPlayerStartByClass>(this->PlayerStarts[PlayerStartIndex]);

		if (PlayerStartByClass != nullptr)
		{
			APawn* ControlledPawn = Player->GetControlledPawn();

			if (ControlledPawn != nullptr && PlayerStartByClass->PlayerClass != nullptr && ControlledPawn->IsA(PlayerStartByClass->PlayerClass))
				return PlayerStartByClass;
		}
	}

	return Super::ChoosePlayerStart(Player);
}