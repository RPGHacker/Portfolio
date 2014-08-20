
// Engine specific includes
#include "Engine.Core/Engine.Core.h"

// Application specific includes
#include "Application/Scene.h"

using namespace Application;



/** Application's main entry point */
int ENGINE_MAIN
{
	// Create new scene
    Scene* scene = new Scene();

	// Create new application description
    engine_ApplicationDescription desc;

	desc.renderer = Engine::Core::RENDERER_DIRECTX11;	// Renderer to use (DirectX10 or DirectX11)
	desc.width = 720;	// Window width
	desc.height = 480;	// Window height

	// Create new application
    engine_Application* application = new engine_Application(desc);



	// Run application loop
    application->Run(scene);



	// Free resources and exit application
	int error = 0;
	if (application->GetError())
		error = -1;

    SAFE_DELETE(scene);
    SAFE_DELETE(application);
	
	return error;
}