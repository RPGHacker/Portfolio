

#include "KokkuEngine.h"
#include "KokkuLevelScriptActor.h"


AKokkuLevelScriptActor::AKokkuLevelScriptActor(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	this->LevelName = NSLOCTEXT("Level Names", "Default Level Name", "New Level");
}

//////////////////////////////////////////////////////////////////////////
// Properties

void AKokkuLevelScriptActor::PostEditChangeProperty(FPropertyChangedEvent& PropertyChangedEvent)
{
	Super::PostEditChangeProperty(PropertyChangedEvent);

	const FName PropertyName = PropertyChangedEvent.Property ? PropertyChangedEvent.Property->GetFName() : NAME_None;

	if (PropertyName == FName(TEXT("PublicLevelName")))
	{
		FString TextKey = FGuid::NewGuid().ToString();
		this->LevelName = FInternationalization::ForUseOnlyByLocMacroAndGraphNodeTextLiterals_CreateText(*(this->PublicLevelName), TEXT("Level Names"), *(TextKey));
	}
}