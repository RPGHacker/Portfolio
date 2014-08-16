

#pragma once

#include "PaperCharacter.h"
#include "KokkuPaperFlipbookComponent.h"
#include "KokkuPaperCharacterBase.generated.h"

/**
 * Case class for paper characters
 */
UCLASS()
class KOKKUENGINE_API AKokkuPaperCharacterBase : public APaperCharacter
{
	GENERATED_UCLASS_BODY()

	/** Name of the flipbook component */
	static FName KokkuSpriteComponentName;

	/** This character's flipbook component */
	UPROPERTY(Category = Character, VisibleAnywhere, BlueprintReadOnly)
	TSubobjectPtr<class UKokkuPaperFlipbookComponent> AnimatedSprite;

	/** Character's default camera */
	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = Character)
	TSubobjectPtr<UCameraComponent> CharacterCamera;

	/** Character's idle animation */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character, meta = (DisplayThumbnail = "true"))
	class UPaperFlipbook* IdleAnimation;

	/** Character's walk animation */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character, meta = (DisplayThumbnail = "true"))
	class UPaperFlipbook* WalkAnimation;

	/** Character's run animation */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character, meta = (DisplayThumbnail = "true"))
	class UPaperFlipbook* RunAnimation;

	/** Character's jump animation */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character, meta = (DisplayThumbnail = "true"))
	class UPaperFlipbook* JumpAnimation;

	/** Character's fall animation */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character, meta = (DisplayThumbnail = "true"))
	class UPaperFlipbook* FallAnimation;

	/** Character's duck animation */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character, meta = (DisplayThumbnail = "true"))
	class UPaperFlipbook* DuckAnimation;

	/** Max walking speed */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character)
	float WalkingSpeed;

	/** Max running speed */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character)
	float RunningSpeed;

	/** Factor of original jump velocity to add to jump when jumping at full running speed */
	UPROPERTY(EditDefaultsOnly, BlueprintReadOnly, Category = Character)
	float RunningJumpVelocityBonus;

protected:
	/** Character is holding run button*/
	bool bRunButtonHeld;

	/** Character is holding jump button*/
	bool bJumpButtonHeld;

	/** Can jump override */
	bool CanJumpOverride();

	/** Update character animation */
	void UpdateAnimation();

	/** Jump pressed input function */
	void JumpPressedInput();

	/** Jump released input function */
	void JumpReleasedInput();

	/** Duck pressed input function */
	void DuckPressedInput();

	/** Duck released input function */
	void DuckReleasedInput();

	/** Run pressed input function */
	void RunPressedInput();

	/** Run released input function */
	void RunReleasedInput();

	/** Walk Left/Right input function */
	void WalkLeftRightInput(float InputValue);

	/** Unaltered jump velocity */
	float InitialJumpVelocity;

	// AActor interface
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaSeconds) override;
	// End of AActor interface

	// APawn interface
	virtual void SetupPlayerInputComponent(class UInputComponent* InputComponent) override;
	// End of APawn interface

	// ACharacter interface
	virtual bool CanCrouch() override;
	// End of ACharacter interface
};
