#pragma once

// Engine.Core specific includes
#include "Engine.Core/Engine.Core.System.h"
#include "Engine.Core/IRenderer.h"

#if defined (ENGINE_PLATFORM_WINDOWS)

#include <D3D10.h>
#include <D3DX10.h>

#elif defined (ENGINE_PLATFORM_LINUX)

#endif

// Namespace Engine::Graphics::DirectX10
namespace Engine { namespace Graphics { namespace DirectX10
{
    using namespace Engine::Core;


	/** DirectX10 renderer implementation */
	class Dx10Renderer : public IRenderer
	{
	public:

#if defined (ENGINE_PLATFORM_WINDOWS)

		/**
		 * @brief	Creates a new Dx10Renderer instance
		 * @param	hwnd	Window handle
		 * @param	width	Window width
		 * @param	height	Window height
		 */
		Dx10Renderer(HWND hwnd, uint32 width, uint32 height);

#elif defined (ENGINE_PLATFORM_LINUX)

#endif

		/**
		 * @brief	Frees resources used by Dx10Renderer
		 */
		~Dx10Renderer();
		
		/**
		 * @brief	Clears backbuffer and begins rendering process
		 * @param	clearColor	Color to clear backbuffer to RGBA format
		 */
		void Begin(uint32 clearColor);
		
		/**
		 * @brief	Ends rendering process and displays rendered scene
		 */
		void End();

	protected:
	private:
		ID3D10Device* device;		/**< Pointer to the Direct3D device instance */
		IDXGISwapChain* swapChain;		/**< Pointer to the swap-chain instance */
		ID3D10RenderTargetView* backBufferView;		/**< Pointer to the back-buffer view instance */
		ID3D10DepthStencilView* depthStencilView;		/**< Pointer to the depth-stencil view instance */
	};

	
	// --------------------------------------------------------
	
	

#if defined (ENGINE_PLATFORM_WINDOWS)

	/**
	 * @brief	Creates a Dx10Renderer instance
	 * @return	Returns a new Dx10Renderer instance
	 */
	EXPORT IRenderer* CreateRenderDevice(HWND hwnd, uint32 width, uint32 height)
    {
		return new Dx10Renderer(hwnd, width, height);
    }

#elif defined (ENGINE_PLATFORM_LINUX)

#endif

}}}