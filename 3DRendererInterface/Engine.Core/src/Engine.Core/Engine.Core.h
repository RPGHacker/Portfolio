#pragma once

// System specific includes
#include "Engine.Core.System.h"

// Engine.Core specific includes
#include "Application.h"
#include "Globals.h"
#include "IScene.h"
#include "IRenderer.h"

// Define ENGINE_CORE_PREFIX
#ifdef ENGINE_CORE_PREFIX

#define engine_ApplicationDescription ::Engine::Core::ApplicationDescription
#define engine_Application ::Engine::Core::Application
#define engine_IRenderer ::Engine::Core::IRenderer
#define engine_IScene ::Engine::Core::IScene

#endif
