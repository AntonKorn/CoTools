# Tools for more concentrated work in windows

## Plugins
Plugins can be added by adding the dll with classes that implement ITools and have [ToolAttribute] applied into the folder of the application. These libraries can reference .Common.dll

## Default tools
The project is still in development. Tools that are planned:
- Make window Top Most
- Make Top Most link to the window
- Blur Window
- Draw on window

## Window blurring
In order to blur the window, the Layered window with the printed by OpenCV image will be used.
