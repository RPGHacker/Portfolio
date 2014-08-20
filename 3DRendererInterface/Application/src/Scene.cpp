// Application specific includes
#include "Application/Scene.h"

namespace Application
{	
	// --------------------------------------------------------	

    Scene::Scene()
	{
	}
	
	// --------------------------------------------------------	

    Scene::~Scene()
	{
	}
	
	// --------------------------------------------------------	

    void Scene::Initialize()
	{
	}
	    
	// --------------------------------------------------------	

    void Scene::Update()
	{
	}
    
	// --------------------------------------------------------	

    void Scene::Render(engine_IRenderer* renderer)
	{		
		renderer->Begin(0x00FF80FF);
			
		renderer->End();
	}
	
	// --------------------------------------------------------	
    
    void Scene::Shutdown()
	{
	}
	
	// --------------------------------------------------------	
    
    bool Scene::HasQuit()
	{
		return false;
	}
}