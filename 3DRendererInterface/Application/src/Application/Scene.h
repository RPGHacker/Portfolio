#pragma once

// Engine.Core specific includes
#include "Engine.Core/Engine.Core.h"

// Declare class ::DemoApplication::Scene
namespace Application 
{
	/** Applicaton's scene implementation */
    class Scene : public engine_IScene
    {
    public:		
		/**
		 * @brief	Creates a new Scene instance
		 */
		Scene();

		/**
		 * @brief	Frees resources used by Scene
		 */
		~Scene();

		/**
		 * @brief	Initializes scene
		 */
		void Initialize();

		/**
		 * @brief	Updates scene
		 */
		void Update();

		/**
		 * @brief	Renders scene
		 * @param	renderer	Renderer to use
		 */
		void Render(engine_IRenderer* renderer);

		/**
		 * @brief	Cleans up scene
		 */
		void Shutdown();

		/**
		 * @brief	Checks if application has exit
		 * @return	Returns true when application has exit
		 */
		bool HasQuit();

    private:
    };
}