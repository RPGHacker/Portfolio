#pragma once



// -------------------------------------------------------

// Compiler specific definitions

#if defined _MSC_VER

    #define EXPORT __declspec(dllexport)

#elif defined __GNUC__

    #define EXPORT extern "C"

#endif



// -------------------------------------------------------

// Platform specific definitions and includes

#if defined (WIN32) | (_WIN32)

    #define ENGINE_PLATFORM_WINDOWS

    #include "Engine.Core.System.Windows.h"

    #if defined _CONSOLE

		#define ENGINE_MAIN main()

    #elif defined _WINDOWS

		#define ENGINE_MAIN WINAPI WinMain(HINSTANCE instance, HINSTANCE prevInstance, LPSTR cmd, int cmdShow)

    #else

		#define ENGINE_MAIN main()

    #endif

#elif defined __linux

    #define ENGINE_PLATFORM_LINUX

    #include "Engine.Core.System.Linux.h"
  
    #define ENGINE_MAIN main()

#else

    #define ENGINE_MAIN main()

#endif