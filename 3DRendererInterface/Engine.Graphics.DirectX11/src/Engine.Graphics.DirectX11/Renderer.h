#pragma once

// Engine.Core specific includes
#include "Engine.Core/Engine.Core.System.h"
#include "Engine.Core/IRenderer.h"

#if defined (ENGINE_PLATFORM_WINDOWS)

#include <D3D11.h>
#include <D3DX11.h>

#elif defined (ENGINE_PLATFORM_LINUX)

#endif

// Namespace Engine::Graphics::DirectX11
namespace Engine { namespace Graphics { namespace DirectX11
{
    using namespace Engine::Core;

	/** DirectX11 renderer implementation */
	class Dx11Renderer : public IRenderer
	{
	public:

#if defined (ENGINE_PLATFORM_WINDOWS)

		/**
		 * @brief	Creates a new Dx11Renderer instance
		 * @param	hwnd	Window handle
		 * @param	width	Window width
		 * @param	height	Window height
		 */
		Dx11Renderer(HWND hwnd, uint32 width, uint32 height);

#elif defined (ENGINE_PLATFORM_LINUX)

#endif

		/**
		 * @brief	Frees resources used by Dx11Renderer
		 */
		~Dx11Renderer();
		
		/**
		 * @brief	Clears backbuffer and begins rendering process
		 * @param	clearColor	Color to clear backbuffer to in RGBA format
		 */
		void Begin(uint32 clearColor);
		
		/**
		 * @brief	Ends rendering process and displays rendered scene
		 */
		void End();

	protected:
	private:
		ID3D11Device* device;		/**< Pointer to the Direct3D device instance */
		IDXGISwapChain* swapChain;		/**< Pointer to the swap-chain instance */
		ID3D11DeviceContext* context;		/**< Pointer to the Direct3D device context instance */
		ID3D11RenderTargetView* backBufferView;		/**< Pointer to the back-buffer view instance */
		ID3D11DepthStencilView* depthStencilView;		/**< Pointer to the depth-stencil view instance */
	};

	
	// --------------------------------------------------------



#if defined (ENGINE_PLATFORM_WINDOWS)

	/**
	 * @brief	Creates a Dx11Renderer instance
	 * @return	Returns a new Dx11Renderer instance
	 */
	EXPORT IRenderer* CreateRenderDevice(HWND hwnd, uint32 width, uint32 height)
    {
		return new Dx11Renderer(hwnd, width, height);
    }
	
#elif defined (ENGINE_PLATFORM_LINUX)

#endif
}}}