#ifdef WIN32

  // Include platform specific headers
  #include <Windows.h>

  // The Windows entry point of this DLL
  bool WINAPI DllMain(HINSTANCE instance, DWORD reasons, LPVOID reserved)
  {
    return true;
  }

#endif