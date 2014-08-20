#pragma once

// Namespace Engine::Core
namespace Engine { namespace Core 
{
	// Safely release a resource
    #define SAFE_RELEASE(x) if(x != 0) {x->Release(); x = 0;}

	// Safely delete a resource
    #define SAFE_DELETE(x) if(x != 0) {delete x; x = 0;}

    // Unsigned 8-bit integer value.
    typedef unsigned char uint8;

    // Unsigned 16-bit integer value.
    typedef unsigned short uint16;

    // Unsigned 32-bit integer value.
    typedef unsigned int uint32;

    // Signed 8-bit integer value.
    typedef signed char int8;

    // Signed 16-bit integer value.
    typedef signed short int16;

    // Signed 32-bit integer value.
    typedef signed int int32;

    // Unsigned 32-bit long value.
    typedef unsigned long ulong32;

    // Signed 32-bit long value.
    typedef signed long long32;

    // Signed 64-bit integer value.
    typedef signed long long int64;

    // Unsigned 64-bit integer value.
    typedef unsigned long long uint64;

    // 32-bit floating point value.
    typedef float float32;

    // 64-bit floating point value.
    typedef double float64;
}}