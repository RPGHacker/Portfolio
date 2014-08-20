#pragma once

// Application specific includes
#include "Globals.h"

// Namespace Engine::Core
namespace Engine { namespace Core
{
	/** IRenderer interface */
	struct IRenderer
	{
		/**
		 * @brief	Clears backbuffer and begins rendering process
		 * @param	clearColor	Color to clear backbuffer to in RGBA format
		 */
		virtual void Begin(uint32 clearColor) = 0;

		/**
		 * @brief	Ends rendering process and displays rendered scene
		 */
		virtual void End() = 0;
	};
}}