

#pragma once

#include "PaperFlipbook.h"
#include "KokkuPaperFlipbook.generated.h"

/**
 * Modified Kokku Engine flipbook
 */
UCLASS(BlueprintType, meta = (DisplayThumbnail = "true"))
class KOKKUENGINE_API UKokkuPaperFlipbook : public UPaperFlipbook
{
	GENERATED_UCLASS_BODY()

	/** Loop starting frame */
	UPROPERTY(Category = Sprite, EditAnywhere, BlueprintReadOnly)
	int32 LoopStart;

	/** Loop end frame */
	UPROPERTY(Category = Sprite, EditAnywhere, BlueprintReadOnly)
	int32 LoopEnd;	
};
