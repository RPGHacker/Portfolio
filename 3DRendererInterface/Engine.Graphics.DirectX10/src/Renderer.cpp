// Engine specific includes
#include "Engine.Graphics.DirectX10/Renderer.h"

// Namespace Engine::Graphics::DirectX10
namespace Engine { namespace Graphics { namespace DirectX10
{
	// --------------------------------------------------------
	
#if defined (ENGINE_PLATFORM_WINDOWS)

	Dx10Renderer::Dx10Renderer(HWND hwnd, uint32 width, uint32 height)
	{
		ID3D10Texture2D* backBuffer = 0;  
		ID3D10Texture2D* depthStencilBuffer = 0; 
		IDXGIDevice* dxgiDevice = 0;
		IDXGIFactory* factory = 0;
		IDXGIAdapter* adapter = 0;
		DXGI_SWAP_CHAIN_DESC swapChainDescription;  
		D3D10_TEXTURE2D_DESC depthStencilDescription;
		D3D10_VIEWPORT viewPort;  

		this->device = 0;
		this->swapChain = 0;
		this->backBufferView = 0;
		this->depthStencilView = 0;

		D3D10_DRIVER_TYPE driverType[] =
		{
			D3D10_DRIVER_TYPE_HARDWARE,
			D3D10_DRIVER_TYPE_WARP,
			D3D10_DRIVER_TYPE_SOFTWARE
		};

		// Create device object
		HRESULT deviceFailed = false;
		int currentDriver = 0;

		do
		{
			deviceFailed = FAILED(D3D10CreateDevice(NULL, driverType[currentDriver], NULL, D3D10_CREATE_DEVICE_SINGLETHREADED  |
				D3D10_CREATE_DEVICE_BGRA_SUPPORT, D3D10_SDK_VERSION, &this->device));

			currentDriver++;
		}
		while (deviceFailed && currentDriver < 3);

		if (deviceFailed)	
		{
			// TODO: Replace with true exception
			throw;
		}

		// Get DXGI device
		this->device->QueryInterface(__uuidof(IDXGIDevice), (LPVOID*)&dxgiDevice);

		// Get adapter of that device
		dxgiDevice->GetAdapter(&adapter);

		dxgiDevice->Release();

		// Get factory of that adapter
		adapter->GetParent(IID_PPV_ARGS(&factory));

		adapter->Release();

		// Create the swap-chain object
		ZeroMemory(&swapChainDescription, sizeof(swapChainDescription));
		swapChainDescription.BufferDesc.Width = width;
		swapChainDescription.BufferDesc.Height = height;
		swapChainDescription.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
		swapChainDescription.BufferDesc.RefreshRate.Numerator = 60;
		swapChainDescription.BufferDesc.RefreshRate.Denominator = 1;
		swapChainDescription.BufferDesc.Scaling = DXGI_MODE_SCALING_CENTERED;
		swapChainDescription.BufferDesc.ScanlineOrdering = DXGI_MODE_SCANLINE_ORDER_PROGRESSIVE;
		swapChainDescription.SampleDesc.Count = 1;
		swapChainDescription.SampleDesc.Quality = 0;
		swapChainDescription.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
		swapChainDescription.BufferCount = 1;
		swapChainDescription.OutputWindow = hwnd;
		swapChainDescription.Windowed = true;
		swapChainDescription.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;
		swapChainDescription.Flags = 0;

		factory->CreateSwapChain(this->device, &swapChainDescription, &this->swapChain);

		factory->Release();

		this->swapChain->GetBuffer(0, __uuidof(ID3D10Texture2D), (LPVOID*)&backBuffer);

		this->device->CreateRenderTargetView(backBuffer, NULL, &this->backBufferView);

		backBuffer->Release();

		ZeroMemory(&depthStencilDescription, sizeof(depthStencilDescription));
		depthStencilDescription.Width = width;
		depthStencilDescription.Height = height;
		depthStencilDescription.MipLevels = 1;
		depthStencilDescription.ArraySize = 1;
		depthStencilDescription.Format = DXGI_FORMAT_D24_UNORM_S8_UINT;
		depthStencilDescription.SampleDesc.Count = 1;
		depthStencilDescription.SampleDesc.Quality = 0;
		depthStencilDescription.Usage = D3D10_USAGE_DEFAULT;
		depthStencilDescription.BindFlags = D3D10_BIND_DEPTH_STENCIL;
		depthStencilDescription.CPUAccessFlags = 0;
		depthStencilDescription.MiscFlags = 0;

		this->device->CreateTexture2D(&depthStencilDescription, 0, &depthStencilBuffer);

		this->device->CreateDepthStencilView(depthStencilBuffer, 0, &this->depthStencilView);

		depthStencilBuffer->Release();

		viewPort.Width = (float)width;
		viewPort.Height = (float)height;
		viewPort.MinDepth = 0.0f;
		viewPort.MaxDepth = 1.0f;
		viewPort.TopLeftX = 0;
		viewPort.TopLeftY = 0;

		this->device->RSSetViewports(1, &viewPort);
	}

#elif defined (ENGINE_PLATFORM_LINUX)

#endif
	
	// --------------------------------------------------------

	Dx10Renderer::~Dx10Renderer()
	{
		SAFE_RELEASE(this->swapChain);
		SAFE_RELEASE(this->device);
		SAFE_RELEASE(this->backBufferView);
		SAFE_RELEASE(this->depthStencilView);
	}
	
	// --------------------------------------------------------

	void Dx10Renderer::Begin(uint32 clearColor)
	{
		float32 r = (float)(clearColor>>24) / 256.0f;
		float32 g = (float)((clearColor>>16)&0xFF) / 256.0f;
		float32 b = (float)((clearColor>>8)&0xFF) / 256.0f;
		float32 a = (float)(clearColor&0xFF) / 256.0f;

		float colorArray[] = {r, g, b, a};

		// Set render target and depth-stencil buffer
		this->device->OMSetRenderTargets(1, &this->backBufferView, this->depthStencilView);

		// Clear backbuffer
		this->device->ClearRenderTargetView(this->backBufferView, colorArray);

		// Clear depth-stencil buffer
		this->device->ClearDepthStencilView(this->depthStencilView, 
			D3D10_CLEAR_DEPTH | D3D10_CLEAR_STENCIL, 1.0f, 0);
	}
	
	// --------------------------------------------------------

	void Dx10Renderer::End()
	{
		// Present backbuffer contents
		this->swapChain->Present(0, 0);
	}
}}}