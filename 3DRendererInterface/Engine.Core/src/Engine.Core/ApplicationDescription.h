#pragma once

// Application specific includes
#include "Globals.h"

// Namespace Engine::Core
namespace Engine { namespace Core 
{
	// --------------------------------------------------------	

	/** Represents possible renderers for application */
	enum ApplicationRenderer
	{
		RENDERER_DIRECTX10,		/**< Use DirectX10 renderer */
		RENDERER_DIRECTX11		/**< Use DirectX11 renderer */
	};	


	// --------------------------------------------------------	

	/** Defines settings for running application */
	struct ApplicationDescription
	{
		/**
		 * @brief	Creates a new ApplicationDescription instance
		 */
		ApplicationDescription();		

		/**
		 * @brief	Frees resources used by ApplicationDescription
		 */
		~ApplicationDescription();


		ApplicationRenderer renderer;		/**< Which renderer to use */
		int width;							/**< Window width */
		int height;							/**< Window height */
	};
}}