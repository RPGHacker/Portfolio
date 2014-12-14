
#include "KokkuEngine.h"
#include "KokkuPaperFlipbookFactory.h"

UKokkuPaperFlipbookFactory::UKokkuPaperFlipbookFactory(const class FObjectInitializer& PCIP)
	: Super(PCIP)
{
	this->bCreateNew = true;
	this->bEditAfterNew = true;
	this->SupportedClass = UKokkuPaperFlipbook::StaticClass();
}

//////////////////////////////////////////////////////////////////////////
// Factory

UObject* UKokkuPaperFlipbookFactory::FactoryCreateNew(UClass* Class, UObject* InParent, FName Name, EObjectFlags Flags, UObject* Context, FFeedbackContext* Warn)
{
	UKokkuPaperFlipbook* NewFlipbook = ConstructObject<UKokkuPaperFlipbook>(Class, InParent, Name, Flags | RF_Transactional);

	return NewFlipbook;
}