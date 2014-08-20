// Engine specific includes
#include "Engine.Core/Application.h"

// Namespace Engine::Core
namespace Engine { namespace Core
{
	// --------------------------------------------------------

	// Some static functions and variables for window message handler

#if defined (ENGINE_PLATFORM_WINDOWS)

	LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
	bool quitWind = false;

#elif defines (ENGINE_PLATFORM_LINUX)

#endif

	// --------------------------------------------------------

	Application::Application(ApplicationDescription& description)
	{
		this->quit = false;
		this->error = false;

		this->renderer = 0;



	#if defined (ENGINE_PLATFORM_WINDOWS)

		this->rendererModule = 0;
		this->hwnd = 0;

		// Declare function pointer
		typedef IRenderer* (*CREATE_RENDER_DEVICE) (HWND hwnd, uint32 width, uint32 height);

		CREATE_RENDER_DEVICE rendererCreateFunction = 0;

		// Load shared library
		switch (description.renderer)
		{
			case Engine::Core::RENDERER_DIRECTX10:
				this->rendererModule = LoadLibrary(L"Engine.Graphics.DirectX10.dll");
				break;
			case Engine::Core::RENDERER_DIRECTX11:
				this->rendererModule = LoadLibrary(L"Engine.Graphics.DirectX11.dll");
				break;
		}

		if (this->rendererModule == 0)
		{
			this->quit = true;
			this->error = true;
			return;
		}

		// Get pointer to entry function
		rendererCreateFunction = (CREATE_RENDER_DEVICE) GetProcAddress(this->rendererModule, "CreateRenderDevice");



		// Create window on Win32 system
		WNDCLASS wc;

		ZeroMemory(&wc, sizeof(WNDCLASS));
		wc.cbClsExtra = 0;
		wc.cbWndExtra = 0;
		wc.hbrBackground = (HBRUSH) GetStockObject(BLACK_BRUSH);
		wc.hCursor = LoadCursor(NULL, IDC_ARROW);  
		wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
		wc.hInstance = GetModuleHandle(NULL);  
		wc.lpfnWndProc = WndProc;
		wc.lpszClassName = L"Application";
		wc.lpszMenuName = NULL;
		wc.style = CS_HREDRAW | CS_VREDRAW;

		if(!RegisterClass(&wc))
		{
			this->quit = true;
			this->error = true;
			return;
		}

		int windowX = ::GetSystemMetrics(SM_CXSCREEN) / 2 - description.width / 2;
		int windowY = ::GetSystemMetrics(SM_CYSCREEN) / 2 - description.height / 2;

		this->hwnd = CreateWindow(wc.lpszClassName, wc.lpszClassName, WS_OVERLAPPEDWINDOW, 
			windowX, windowY, description.width, description.height, NULL, NULL, wc.hInstance, NULL);

		if(this->hwnd == 0)
		{
			this->quit = true;
			this->error = true;
			return;
		}

		ShowWindow(this->hwnd, SW_SHOWDEFAULT);
		UpdateWindow(this->hwnd);  

		ZeroMemory(&(this->msg), sizeof(MSG));		


		// Call function to create renderer instance
		this->renderer = rendererCreateFunction(this->hwnd, description.width, description.height);



	#elif defined (ENGINE_PLATFORM_LINUX)


	#endif
    }
	
	// --------------------------------------------------------

	Application::~Application()
	{
		SAFE_DELETE(this->renderer);

	#if defined (ENGINE_PLATFORM_WINDOWS)

		FreeLibrary(this->rendererModule);

	#elif defined (ENGINE_PLATFORM_LINUX)


	#endif
    }
	
	// --------------------------------------------------------

	void Application::Run(IScene* scene)
	{
		// Initialize scene
		scene->Initialize();

		while(!scene->HasQuit() && !(this->quit))
		{

		#if defined (ENGINE_PLATFORM_WINDOWS)

			// Get window messages
			if(PeekMessage(&(this->msg), this->hwnd, 0, 0, PM_REMOVE))
			{
				TranslateMessage(&(this->msg));
				DispatchMessage(&(this->msg));
			}
			if (quitWind)
				this->quit = true;

		#elif defines (ENGINE_PLATFORM_LINUX)

		#endif

			// Update scene
			scene->Update();

			// Render scene
    	    scene->Render(this->renderer);
		}

		// Shutdown scene
		scene->Shutdown();
    }	
	
	// --------------------------------------------------------
	
	bool Application::GetError()
	{
		return this->error;
	}
	
	// --------------------------------------------------------
	
#if defined (ENGINE_PLATFORM_WINDOWS)
	
	/**
	 * @brief	Windows message handler
	 */
	LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
	{
		switch(message)
		{
		case WM_DESTROY:
			PostQuitMessage(0);  
			quitWind = true;
			break;
		}

		return DefWindowProc(hwnd, message, wParam, lParam);
	}

#elif defines (ENGINE_PLATFORM_LINUX)

#endif
}}