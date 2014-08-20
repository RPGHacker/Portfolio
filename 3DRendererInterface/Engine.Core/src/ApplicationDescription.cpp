// Engine specific includes
#include "Engine.Core/ApplicationDescription.h"

// Namespace Engine::Core
namespace Engine { namespace Core
{
	// --------------------------------------------------------

	ApplicationDescription::ApplicationDescription()
	{
		// Provide default values for description's fields
		this->renderer = RENDERER_DIRECTX11;
		this->width = 640;
		this->height = 480;
    }

	// --------------------------------------------------------	

	ApplicationDescription::~ApplicationDescription()
	{
    }
}}