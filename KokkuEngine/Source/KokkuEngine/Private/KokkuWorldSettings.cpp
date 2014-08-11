

#include "KokkuEngine.h"
#include "KokkuWorldSettings.h"


AKokkuWorldSettings::AKokkuWorldSettings(const class FPostConstructInitializeProperties& PCIP)
	: Super(PCIP)
{
	this->LevelLightingQuality = ELightingBuildQuality::Quality_Preview;
}