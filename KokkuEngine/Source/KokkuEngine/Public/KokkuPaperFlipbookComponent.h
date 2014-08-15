

#pragma once

#include "PaperFlipbookComponent.h"
#include "KokkuPaperFlipbookComponent.generated.h"

/**
 * Modified Kokku Engine flipbook component
 */
UCLASS(ShowCategories = (Mobility), meta = (BlueprintSpawnableComponent))
class KOKKUENGINE_API UKokkuPaperFlipbookComponent : public UPaperFlipbookComponent
{
	GENERATED_UCLASS_BODY()

	// UActorComponent interface
	virtual void TickComponent(float DeltaTime, enum ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
	// End of UActorComponent interface
	
protected:
	/** Update animation frame 
	* @param	DeltaTime	Passed time since previous frame 
	*/
	void KokkuTickFlipbook(float DeltaTime);

	/** Get time of loop start 
	* @returns	Time lof loop start
	*/
	float GetFlipbookLoopStartTime() const;

	/** Get time of loop end
	* @returns	Time lof loop end
	*/
	float GetFlipbookLoopEndTime() const;
};
