#pragma once

#include "Factories/Factory.h"
#include "KokkuPaperFlipbook.h"
#include "KokkuPaperFlipbookFactory.generated.h"

/**
 * Factory for Kokku Flipbooks
 */
UCLASS()
class KOKKUENGINE_API UKokkuPaperFlipbookFactory : public UFactory
{
	GENERATED_UCLASS_BODY()

	// UFactory interface
	virtual UObject* FactoryCreateNew(UClass* Class, UObject* InParent, FName Name, EObjectFlags Flags, UObject* Context, FFeedbackContext* Warn) override;
	// End of UFactory interface
};
