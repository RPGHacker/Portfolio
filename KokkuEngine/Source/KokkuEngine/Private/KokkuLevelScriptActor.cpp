

#include "KokkuEngine.h"
#include "KokkuLevelScriptActor.h"


AKokkuLevelScriptActor::AKokkuLevelScriptActor(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	this->LevelName = NSLOCTEXT("Level Names", "Default Level Name", "New Level");
}