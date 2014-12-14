

#include "KokkuEngine.h"
#include "KokkuWorldSettings.h"


AKokkuWorldSettings::AKokkuWorldSettings(const class FObjectInitializer& PCIP)
	: Super(PCIP)
{
	this->LevelLightingQuality = ELightingBuildQuality::Quality_Preview;
}