#pragma once

// Application specific includes
#include "Engine.Core.System.h"
#include "Globals.h"
#include "IScene.h"
#include "IRenderer.h"
#include "ApplicationDescription.h"

// Namespace Engine::Core
namespace Engine { namespace Core
{
	/** Class that represents an application's entry point */
	class Application
	{
	public:
		/**
		 * @brief	Creates a new Application instance
		 * @param	description		Contains information on how to run application
		 */
		Application(ApplicationDescription& description);

		/**
		 * @brief	Frees resources used by Application
		 */
		~Application();

		/**
		 * @brief	Runs the application
		 * @param	scene	Application's scene implementation
		 */
		void Run(IScene* scene);

		/**
		 * @brief	Get error code
		 * @return	Returns error code
		 */
		bool GetError();

	protected:
	private:
		IRenderer* renderer;		/**< Application's renderer */
		bool quit;					/**< Setting to true closes application */
		bool error;					/**< Set to true on error */

	#if defined (ENGINE_PLATFORM_WINDOWS)

		HMODULE rendererModule;		/**< Module to load renderer from */
		MSG msg;					/**< Window's messages */		
		HWND hwnd;					/**< Window's handle */

	#elif defined (ENGINE_PLATFORM_LINUX)

	#endif

	};
}}