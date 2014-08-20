#pragma once

// Application specific includes
#include "Globals.h"
#include "IRenderer.h"

// Namespace Engine::Core
namespace Engine { namespace Core
{
	/** IScene interface */
	struct IScene
    {
		/**
		 * @brief	Initializes scene
		 */
		virtual void Initialize() = 0;
		
		/**
		 * @brief	Updates scene
		 */
		virtual void Update() = 0;
		
		/**
		 * @brief	Renders scene
		 * @param	renderer	Renderer to use
		 */
		virtual void Render(IRenderer* renderer) = 0;
		
		/**
		 * @brief	Cleans up scene
		 */
		virtual void Shutdown() = 0;
		
		/**
		 * @brief	Checks if application has exit
		 * @return	Returns true when application has exit
		 */
		virtual bool HasQuit() = 0;
    };
}}

