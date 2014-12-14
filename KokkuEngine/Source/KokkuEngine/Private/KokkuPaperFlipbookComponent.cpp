

#include "KokkuEngine.h"
#include "KokkuPaperFlipbookComponent.h"


UKokkuPaperFlipbookComponent::UKokkuPaperFlipbookComponent(const class FObjectInitializer& PCIP)
	: Super(PCIP)
{

}

//////////////////////////////////////////////////////////////////////////
// Animation

void UKokkuPaperFlipbookComponent::KokkuTickFlipbook(float DeltaTime)
{
	bool bIsFinished = false;

	if (this->bPlaying)
	{
		float NewPosition = this->AccumulatedTime;
		const float TimelineLength = this->GetFlipbookLength();
		const float LoopEndTime = this->GetFlipbookLoopEndTime();
		const float LoopStartTime = this->GetFlipbookLoopStartTime();
		const float LoopSegmentLength = FMath::Max(LoopEndTime - LoopStartTime, 0.0f);

		if (!(this->bReversePlayback))
		{
			NewPosition = this->AccumulatedTime + (DeltaTime * this->PlayRate);

			if (this->bLooping)
			{
				if (NewPosition >= LoopEndTime)
				{
					// If looping, play to end, jump to start, and set target to somewhere near the beginning.
					this->SetPlaybackPosition(LoopEndTime, true);
					this->SetPlaybackPosition(LoopStartTime, false);

					if (LoopSegmentLength > 0.0f)
					{
						while (NewPosition >= LoopEndTime)
						{
							NewPosition -= LoopSegmentLength;
						}
					}
					else
					{
						NewPosition = LoopEndTime;
					}
				}
			}
			else
			{
				if (NewPosition >= TimelineLength)
				{
					// If not looping, snap to end and stop playing.
					NewPosition = TimelineLength;
					this->Stop();
					bIsFinished = true;
				}
			}
		}
		else
		{
			NewPosition = this->AccumulatedTime - (DeltaTime * this->PlayRate);

			if (this->bLooping)
			{
				if (NewPosition < LoopStartTime)
				{
					// If looping, play to start, jump to end, and set target to somewhere near the end.
					this->SetPlaybackPosition(LoopStartTime, true);
					this->SetPlaybackPosition(LoopEndTime, false);

					if (LoopSegmentLength > 0.0f)
					{
						while (NewPosition < LoopStartTime)
						{
							NewPosition += LoopSegmentLength;
						}
					}
					else
					{
						NewPosition = LoopStartTime;
					}
				}
			}
			else
			{
				if (NewPosition < 0.0f)
				{
					// If not looping, snap to start and stop playing.
					NewPosition = 0.0f;
					this->Stop();
					bIsFinished = true;
				}
			}
		}

		this->SetPlaybackPosition(NewPosition, true);
	}

	// Notify user that timeline finished
	if (bIsFinished)
	{
		this->OnFinishedPlaying.Broadcast();
	}
}


void UKokkuPaperFlipbookComponent::TickComponent(float DeltaTime, enum ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	this->KokkuTickFlipbook(DeltaTime);

	this->CalculateCurrentFrame();
}


float UKokkuPaperFlipbookComponent::GetFlipbookLoopStartTime() const
{
	if (this->SourceFlipbook != nullptr)
	{
		float TotalDuration = this->SourceFlipbook->GetTotalDuration();

		UKokkuPaperFlipbook* KokkuPaperFlipbook = Cast<UKokkuPaperFlipbook>(this->SourceFlipbook);

		if (KokkuPaperFlipbook != nullptr)
		{
			int32 NumFrames = KokkuPaperFlipbook->GetNumFrames();
			int32 LoopStart = KokkuPaperFlipbook->LoopStart;
			if (NumFrames != 0)
			{
				float LoopStartTime = ((float)(LoopStart) / (float)(NumFrames)) * TotalDuration;
				LoopStartTime = FMath::Clamp<float>(LoopStartTime, 0.0f, TotalDuration);
				return LoopStartTime;
			}
		}
	}

	return 0.0f;
}


float UKokkuPaperFlipbookComponent::GetFlipbookLoopEndTime() const
{
	if (this->SourceFlipbook != nullptr)
	{
		float TotalDuration = this->SourceFlipbook->GetTotalDuration();

		UKokkuPaperFlipbook* KokkuPaperFlipbook = Cast<UKokkuPaperFlipbook>(this->SourceFlipbook);

		if (KokkuPaperFlipbook != nullptr)
		{
			int32 NumFrames = KokkuPaperFlipbook->GetNumFrames();
			int32 LoopEnd = KokkuPaperFlipbook->LoopEnd;
			if (NumFrames != 0)
			{
				float LoopEndTime = ((float)(LoopEnd) / (float)(NumFrames)) * TotalDuration;
				LoopEndTime = FMath::Clamp<float>(LoopEndTime, 0.0f, TotalDuration);
				return LoopEndTime;
			}
		}

		return TotalDuration;
	}

	return 0.0f;
}


