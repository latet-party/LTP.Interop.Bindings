#region License
/*
	GLFW
	Copyright (c) 2002-2006 Marcus Geelnard
	Copyright (c) 2006-2016 Camilla Löwy <elmindreda@glfw.org>

	This software is provided 'as-is', without any express or implied
	warranty. In no event will the authors be held liable for any damages
	arising from the use of this software.

	Permission is granted to anyone to use this software for any purpose,
	including commercial applications, and to alter it and redistribute it
	freely, subject to the following restrictions:

		1. The origin of this software must not be misrepresented; you must not
		claim that you wrote the original software. If you use this software
		in a product, an acknowledgment in the product documentation would
		be appreciated but is not required.

		2. Altered source versions must be plainly marked as such, and must not
		be misrepresented as being the original software.

		3. This notice may not be removed or altered from any source
		distribution.
*/
#endregion

#region Using statements
using System;
using System.Runtime.InteropServices;

using LTP.Interop.InteropServices;
#endregion

[Library( "glfw3" )]
public static unsafe class GLFW3
{
	#region Fields / Properties
	private static IntPtr _handle;
	#endregion

	#region Constructors
	static GLFW3()
	{
		_handle = LibraryLoader.Load( typeof( GLFW3 ) );
		glfwInit();
	}
	#endregion

	#region Constants
	public const int GLFW_VERSION_MAJOR = 3;
	public const int GLFW_VERSION_MINOR = 2;
	public const int GLFW_VERSION_REVISION = 1;
	public const int GLFW_TRUE = 1;
	public const int GLFW_FALSE = 0;
	public const int GLFW_RELEASE = 0;
	public const int GLFW_PRESS = 1;
	public const int GLFW_REPEAT = 2;
	public const int GLFW_KEY_UNKNOWN = -1;
	public const int GLFW_KEY_SPACE = 32;
	public const int GLFW_KEY_APOSTROPHE = 39;
	public const int GLFW_KEY_COMMA = 44;
	public const int GLFW_KEY_MINUS = 45;
	public const int GLFW_KEY_PERIOD = 46;
	public const int GLFW_KEY_SLASH = 47;
	public const int GLFW_KEY_0 = 48;
	public const int GLFW_KEY_1 = 49;
	public const int GLFW_KEY_2 = 50;
	public const int GLFW_KEY_3 = 51;
	public const int GLFW_KEY_4 = 52;
	public const int GLFW_KEY_5 = 53;
	public const int GLFW_KEY_6 = 54;
	public const int GLFW_KEY_7 = 55;
	public const int GLFW_KEY_8 = 56;
	public const int GLFW_KEY_9 = 57;
	public const int GLFW_KEY_SEMICOLON = 59;
	public const int GLFW_KEY_EQUAL = 61;
	public const int GLFW_KEY_A = 65;
	public const int GLFW_KEY_B = 66;
	public const int GLFW_KEY_C = 67;
	public const int GLFW_KEY_D = 68;
	public const int GLFW_KEY_E = 69;
	public const int GLFW_KEY_F = 70;
	public const int GLFW_KEY_G = 71;
	public const int GLFW_KEY_H = 72;
	public const int GLFW_KEY_I = 73;
	public const int GLFW_KEY_J = 74;
	public const int GLFW_KEY_K = 75;
	public const int GLFW_KEY_L = 76;
	public const int GLFW_KEY_M = 77;
	public const int GLFW_KEY_N = 78;
	public const int GLFW_KEY_O = 79;
	public const int GLFW_KEY_P = 80;
	public const int GLFW_KEY_Q = 81;
	public const int GLFW_KEY_R = 82;
	public const int GLFW_KEY_S = 83;
	public const int GLFW_KEY_T = 84;
	public const int GLFW_KEY_U = 85;
	public const int GLFW_KEY_V = 86;
	public const int GLFW_KEY_W = 87;
	public const int GLFW_KEY_X = 88;
	public const int GLFW_KEY_Y = 89;
	public const int GLFW_KEY_Z = 90;
	public const int GLFW_KEY_LEFT_BRACKET = 91;
	public const int GLFW_KEY_BACKSLASH = 92;
	public const int GLFW_KEY_RIGHT_BRACKET = 93;
	public const int GLFW_KEY_GRAVE_ACCENT = 96;
	public const int GLFW_KEY_WORLD_1 = 161;
	public const int GLFW_KEY_WORLD_2 = 162;
	public const int GLFW_KEY_ESCAPE = 256;
	public const int GLFW_KEY_ENTER = 257;
	public const int GLFW_KEY_TAB = 258;
	public const int GLFW_KEY_BACKSPACE = 259;
	public const int GLFW_KEY_INSERT = 260;
	public const int GLFW_KEY_DELETE = 261;
	public const int GLFW_KEY_RIGHT = 262;
	public const int GLFW_KEY_LEFT = 263;
	public const int GLFW_KEY_DOWN = 264;
	public const int GLFW_KEY_UP = 265;
	public const int GLFW_KEY_PAGE_UP = 266;
	public const int GLFW_KEY_PAGE_DOWN = 267;
	public const int GLFW_KEY_HOME = 268;
	public const int GLFW_KEY_END = 269;
	public const int GLFW_KEY_CAPS_LOCK = 280;
	public const int GLFW_KEY_SCROLL_LOCK = 281;
	public const int GLFW_KEY_NUM_LOCK = 282;
	public const int GLFW_KEY_PRINT_SCREEN = 283;
	public const int GLFW_KEY_PAUSE = 284;
	public const int GLFW_KEY_F1 = 290;
	public const int GLFW_KEY_F2 = 291;
	public const int GLFW_KEY_F3 = 292;
	public const int GLFW_KEY_F4 = 293;
	public const int GLFW_KEY_F5 = 294;
	public const int GLFW_KEY_F6 = 295;
	public const int GLFW_KEY_F7 = 296;
	public const int GLFW_KEY_F8 = 297;
	public const int GLFW_KEY_F9 = 298;
	public const int GLFW_KEY_F10 = 299;
	public const int GLFW_KEY_F11 = 300;
	public const int GLFW_KEY_F12 = 301;
	public const int GLFW_KEY_F13 = 302;
	public const int GLFW_KEY_F14 = 303;
	public const int GLFW_KEY_F15 = 304;
	public const int GLFW_KEY_F16 = 305;
	public const int GLFW_KEY_F17 = 306;
	public const int GLFW_KEY_F18 = 307;
	public const int GLFW_KEY_F19 = 308;
	public const int GLFW_KEY_F20 = 309;
	public const int GLFW_KEY_F21 = 310;
	public const int GLFW_KEY_F22 = 311;
	public const int GLFW_KEY_F23 = 312;
	public const int GLFW_KEY_F24 = 313;
	public const int GLFW_KEY_F25 = 314;
	public const int GLFW_KEY_KP_0 = 320;
	public const int GLFW_KEY_KP_1 = 321;
	public const int GLFW_KEY_KP_2 = 322;
	public const int GLFW_KEY_KP_3 = 323;
	public const int GLFW_KEY_KP_4 = 324;
	public const int GLFW_KEY_KP_5 = 325;
	public const int GLFW_KEY_KP_6 = 326;
	public const int GLFW_KEY_KP_7 = 327;
	public const int GLFW_KEY_KP_8 = 328;
	public const int GLFW_KEY_KP_9 = 329;
	public const int GLFW_KEY_KP_DECIMAL = 330;
	public const int GLFW_KEY_KP_DIVIDE = 331;
	public const int GLFW_KEY_KP_MULTIPLY = 332;
	public const int GLFW_KEY_KP_SUBTRACT = 333;
	public const int GLFW_KEY_KP_ADD = 334;
	public const int GLFW_KEY_KP_ENTER = 335;
	public const int GLFW_KEY_KP_EQUAL = 336;
	public const int GLFW_KEY_LEFT_SHIFT = 340;
	public const int GLFW_KEY_LEFT_CONTROL = 341;
	public const int GLFW_KEY_LEFT_ALT = 342;
	public const int GLFW_KEY_LEFT_SUPER = 343;
	public const int GLFW_KEY_RIGHT_SHIFT = 344;
	public const int GLFW_KEY_RIGHT_CONTROL = 345;
	public const int GLFW_KEY_RIGHT_ALT = 346;
	public const int GLFW_KEY_RIGHT_SUPER = 347;
	public const int GLFW_KEY_MENU = 348;
	public const int GLFW_KEY_LAST = GLFW_KEY_MENU;
	public const int GLFW_MOD_SHIFT = 1;
	public const int GLFW_MOD_CONTROL = 2;
	public const int GLFW_MOD_ALT = 4;
	public const int GLFW_MOD_SUPER = 8;
	public const int GLFW_MOUSE_BUTTON_1 = 0;
	public const int GLFW_MOUSE_BUTTON_2 = 1;
	public const int GLFW_MOUSE_BUTTON_3 = 2;
	public const int GLFW_MOUSE_BUTTON_4 = 3;
	public const int GLFW_MOUSE_BUTTON_5 = 4;
	public const int GLFW_MOUSE_BUTTON_6 = 5;
	public const int GLFW_MOUSE_BUTTON_7 = 6;
	public const int GLFW_MOUSE_BUTTON_8 = 7;
	public const int GLFW_MOUSE_BUTTON_LAST = GLFW_MOUSE_BUTTON_8;
	public const int GLFW_MOUSE_BUTTON_LEFT = GLFW_MOUSE_BUTTON_1;
	public const int GLFW_MOUSE_BUTTON_RIGHT = GLFW_MOUSE_BUTTON_2;
	public const int GLFW_MOUSE_BUTTON_MIDDLE = GLFW_MOUSE_BUTTON_3;
	public const int GLFW_JOYSTICK_1 = 0;
	public const int GLFW_JOYSTICK_2 = 1;
	public const int GLFW_JOYSTICK_3 = 2;
	public const int GLFW_JOYSTICK_4 = 3;
	public const int GLFW_JOYSTICK_5 = 4;
	public const int GLFW_JOYSTICK_6 = 5;
	public const int GLFW_JOYSTICK_7 = 6;
	public const int GLFW_JOYSTICK_8 = 7;
	public const int GLFW_JOYSTICK_9 = 8;
	public const int GLFW_JOYSTICK_10 = 9;
	public const int GLFW_JOYSTICK_11 = 10;
	public const int GLFW_JOYSTICK_12 = 11;
	public const int GLFW_JOYSTICK_13 = 12;
	public const int GLFW_JOYSTICK_14 = 13;
	public const int GLFW_JOYSTICK_15 = 14;
	public const int GLFW_JOYSTICK_16 = 15;
	public const int GLFW_JOYSTICK_LAST = GLFW_JOYSTICK_16;
	public const int GLFW_NOT_INITIALIZED = 65537;
	public const int GLFW_NO_CURRENT_CONTEXT = 65538;
	public const int GLFW_INVALID_ENUM = 65539;
	public const int GLFW_INVALID_VALUE = 65540;
	public const int GLFW_OUT_OF_MEMORY = 65541;
	public const int GLFW_API_UNAVAILABLE = 65542;
	public const int GLFW_VERSION_UNAVAILABLE = 65543;
	public const int GLFW_PLATFORM_ERROR = 65544;
	public const int GLFW_FORMAT_UNAVAILABLE = 65545;
	public const int GLFW_NO_WINDOW_CONTEXT = 65546;
	public const int GLFW_FOCUSED = 131073;
	public const int GLFW_ICONIFIED = 131074;
	public const int GLFW_RESIZABLE = 131075;
	public const int GLFW_VISIBLE = 131076;
	public const int GLFW_DECORATED = 131077;
	public const int GLFW_AUTO_ICONIFY = 131078;
	public const int GLFW_FLOATING = 131079;
	public const int GLFW_MAXIMIZED = 131080;
	public const int GLFW_RED_BITS = 135169;
	public const int GLFW_GREEN_BITS = 135170;
	public const int GLFW_BLUE_BITS = 135171;
	public const int GLFW_ALPHA_BITS = 135172;
	public const int GLFW_DEPTH_BITS = 135173;
	public const int GLFW_STENCIL_BITS = 135174;
	public const int GLFW_ACCUM_RED_BITS = 135175;
	public const int GLFW_ACCUM_GREEN_BITS = 135176;
	public const int GLFW_ACCUM_BLUE_BITS = 135177;
	public const int GLFW_ACCUM_ALPHA_BITS = 135178;
	public const int GLFW_AUX_BUFFERS = 135179;
	public const int GLFW_STEREO = 135180;
	public const int GLFW_SAMPLES = 135181;
	public const int GLFW_SRGB_CAPABLE = 135182;
	public const int GLFW_REFRESH_RATE = 135183;
	public const int GLFW_DOUBLEBUFFER = 135184;
	public const int GLFW_CLIENT_API = 139265;
	public const int GLFW_CONTEXT_VERSION_MAJOR = 139266;
	public const int GLFW_CONTEXT_VERSION_MINOR = 139267;
	public const int GLFW_CONTEXT_REVISION = 139268;
	public const int GLFW_CONTEXT_ROBUSTNESS = 139269;
	public const int GLFW_OPENGL_FORWARD_COMPAT = 139270;
	public const int GLFW_OPENGL_DEBUG_CONTEXT = 139271;
	public const int GLFW_OPENGL_PROFILE = 139272;
	public const int GLFW_CONTEXT_RELEASE_BEHAVIOR = 139273;
	public const int GLFW_CONTEXT_NO_ERROR = 139274;
	public const int GLFW_CONTEXT_CREATION_API = 139275;
	public const int GLFW_NO_API = 0;
	public const int GLFW_OPENGL_API = 196609;
	public const int GLFW_OPENGL_ES_API = 196610;
	public const int GLFW_NO_ROBUSTNESS = 0;
	public const int GLFW_NO_RESET_NOTIFICATION = 200705;
	public const int GLFW_LOSE_CONTEXT_ON_RESET = 200706;
	public const int GLFW_OPENGL_ANY_PROFILE = 0;
	public const int GLFW_OPENGL_CORE_PROFILE = 204801;
	public const int GLFW_OPENGL_COMPAT_PROFILE = 204802;
	public const int GLFW_CURSOR = 208897;
	public const int GLFW_STICKY_KEYS = 208898;
	public const int GLFW_STICKY_MOUSE_BUTTONS = 208899;
	public const int GLFW_CURSOR_NORMAL = 212993;
	public const int GLFW_CURSOR_HIDDEN = 212994;
	public const int GLFW_CURSOR_DISABLED = 212995;
	public const int GLFW_ANY_RELEASE_BEHAVIOR = 0;
	public const int GLFW_RELEASE_BEHAVIOR_FLUSH = 217089;
	public const int GLFW_RELEASE_BEHAVIOR_NONE = 217090;
	public const int GLFW_NATIVE_CONTEXT_API = 221185;
	public const int GLFW_EGL_CONTEXT_API = 221186;
	public const int GLFW_ARROW_CURSOR = 221185;
	public const int GLFW_IBEAM_CURSOR = 221186;
	public const int GLFW_CROSSHAIR_CURSOR = 221187;
	public const int GLFW_HAND_CURSOR = 221188;
	public const int GLFW_HRESIZE_CURSOR = 221189;
	public const int GLFW_VRESIZE_CURSOR = 221190;
	public const int GLFW_CONNECTED = 262145;
	public const int GLFW_DISCONNECTED = 262146;
	public const int GLFW_DONT_CARE = -1;
	#endregion

	#region Structs
	[StructLayout( LayoutKind.Sequential )]
	public struct GLFWvidmode
	{
		public int width;
		public int height;
		public int redBits;
		public int greenBits;
		public int blueBits;
		public int refreshRate;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct GLFWgammaramp
	{
		public void* red;
		public void* green;
		public void* blue;
		public uint size;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct GLFWimage
	{
		public int width;
		public int height;
		[MarshalAs( UnmanagedType.LPStr )]
		public string pixels;
	}
	#endregion

	#region Delegates
	public delegate void GLFWvkproc();
	public delegate void GLFWerrorfun( int code, [In] [MarshalAs( UnmanagedType.LPStr )] string description );
	public delegate void GLFWwindowposfun( void* window, int x, int y );
	public delegate void GLFWwindowsizefun( void* window, int w, int h );
	public delegate void GLFWwindowclosefun( void* window );
	public delegate void GLFWwindowrefreshfun( void* window );
	public delegate void GLFWwindowfocusfun( void* window, int got );
	public delegate void GLFWwindowiconifyfun( void* window, int iconify );
	public delegate void GLFWframebuffersizefun( void* window, int w, int h );
	public delegate void GLFWmousebuttonfun( void* window, int button, int action, int mods );
	public delegate void GLFWcursorposfun( void* window, double x, double y );
	public delegate void GLFWcursorenterfun( void* window, int entered );
	public delegate void GLFWscrollfun( void* window, double xoffset, double yoffset );
	public delegate void GLFWkeyfun( void* window, int key, int scancode, int action, int mods );
	public delegate void GLFWcharfun( void* window, uint codepoint );
	public delegate void GLFWcharmodsfun( void* window, uint codepoint, int mods );
	public delegate void GLFWdropfun( void* window, int count, [Out] string[] paths );
	public delegate void GLFWmonitorfun( void* window, int ev );
	public delegate void GLFWjoystickfun( int window, int ev );

	public delegate int PFNGLFWINITPROC();
	public delegate void PFNGLFWTERMINATEPROC();
	public delegate void PFNGLFWGETVERSIONPROC( ref int major, ref int minor, ref int rev );
	public delegate void* PFNGLFWGETVERSIONSTRINGPROC();
	public delegate GLFWerrorfun PFNGLFWSETERRORCALLBACKPROC( GLFWerrorfun cbfun );
	public delegate void* PFNGLFWGETMONITORSPROC( ref int count );
	public delegate void* PFNGLFWGETPRIMARYMONITORPROC();
	public delegate void PFNGLFWGETMONITORPOSPROC( void* monitor, ref int xpos, ref int ypos );
	public delegate void PFNGLFWGETMONITORPHYSICALSIZEPROC( void* monitor, ref int widthMM, ref int heightMM );
	public delegate void* PFNGLFWGETMONITORNAMEPROC( void* monitor );
	public delegate GLFWmonitorfun PFNGLFWSETMONITORCALLBACKPROC( GLFWmonitorfun cbfun );
	public delegate void* PFNGLFWGETVIDEOMODESPROC( void* monitor, ref int count );
	public delegate void* PFNGLFWGETVIDEOMODEPROC( void* monitor );
	public delegate void PFNGLFWSETGAMMAPROC( void* monitor, float gamma );
	public delegate void* PFNGLFWGETGAMMARAMPPROC( void* monitor );
	public delegate void PFNGLFWSETGAMMARAMPPROC( void* monitor, ref GLFWgammaramp ramp );
	public delegate void PFNGLFWDEFAULTWINDOWHINTSPROC();
	public delegate void PFNGLFWWINDOWHINTPROC( int hint, int value );
	public delegate void* PFNGLFWCREATEWINDOWPROC( int width, int height, [In] [MarshalAs( UnmanagedType.LPStr )] string title, void* monitor, void* share );
	public delegate void PFNGLFWDESTROYWINDOWPROC( void* window );
	public delegate int PFNGLFWWINDOWSHOULDCLOSEPROC( void* window );
	public delegate void PFNGLFWSETWINDOWSHOULDCLOSEPROC( void* window, int value );
	public delegate void PFNGLFWSETWINDOWTITLEPROC( void* window, [In] [MarshalAs( UnmanagedType.LPStr )] string title );
	public delegate void PFNGLFWSETWINDOWICONPROC( void* window, int count, ref GLFWimage images );
	public delegate void PFNGLFWGETWINDOWPOSPROC( void* window, ref int xpos, ref int ypos );
	public delegate void PFNGLFWSETWINDOWPOSPROC( void* window, int xpos, int ypos );
	public delegate void PFNGLFWGETWINDOWSIZEPROC( void* window, ref int width, ref int height );
	public delegate void PFNGLFWSETWINDOWSIZELIMITSPROC( void* window, int minwidth, int minheight, int maxwidth, int maxheight );
	public delegate void PFNGLFWSETWINDOWASPECTRATIOPROC( void* window, int numer, int denom );
	public delegate void PFNGLFWSETWINDOWSIZEPROC( void* window, int width, int height );
	public delegate void PFNGLFWGETFRAMEBUFFERSIZEPROC( void* window, ref int width, ref int height );
	public delegate void PFNGLFWGETWINDOWFRAMESIZEPROC( void* window, ref int left, ref int top, ref int right, ref int bottom );
	public delegate void PFNGLFWICONIFYWINDOWPROC( void* window );
	public delegate void PFNGLFWRESTOREWINDOWPROC( void* window );
	public delegate void PFNGLFWMAXIMIZEWINDOWPROC( void* window );
	public delegate void PFNGLFWSHOWWINDOWPROC( void* window );
	public delegate void PFNGLFWHIDEWINDOWPROC( void* window );
	public delegate void PFNGLFWFOCUSWINDOWPROC( void* window );
	public delegate void* PFNGLFWGETWINDOWMONITORPROC( void* window );
	public delegate void PFNGLFWSETWINDOWMONITORPROC( void* window, void* monitor, int xpos, int ypos, int width, int height, int refreshRate );
	public delegate int PFNGLFWGETWINDOWATTRIBPROC( void* window, int attrib );
	public delegate void PFNGLFWSETWINDOWUSERPOINTERPROC( void* window, void* pointer );
	public delegate void* PFNGLFWGETWINDOWUSERPOINTERPROC( void* window );
	public delegate GLFWwindowposfun PFNGLFWSETWINDOWPOSCALLBACKPROC( void* window, GLFWwindowposfun cbfun );
	public delegate GLFWwindowsizefun PFNGLFWSETWINDOWSIZECALLBACKPROC( void* window, GLFWwindowsizefun cbfun );
	public delegate GLFWwindowclosefun PFNGLFWSETWINDOWCLOSECALLBACKPROC( void* window, GLFWwindowclosefun cbfun );
	public delegate GLFWwindowrefreshfun PFNGLFWSETWINDOWREFRESHCALLBACKPROC( void* window, GLFWwindowrefreshfun cbfun );
	public delegate GLFWwindowfocusfun PFNGLFWSETWINDOWFOCUSCALLBACKPROC( void* window, GLFWwindowfocusfun cbfun );
	public delegate GLFWwindowiconifyfun PFNGLFWSETWINDOWICONIFYCALLBACKPROC( void* window, GLFWwindowiconifyfun cbfun );
	public delegate GLFWframebuffersizefun PFNGLFWSETFRAMEBUFFERSIZECALLBACKPROC( void* window, GLFWframebuffersizefun cbfun );
	public delegate void PFNGLFWPOLLEVENTSPROC();
	public delegate void PFNGLFWWAITEVENTSPROC();
	public delegate void PFNGLFWWAITEVENTSTIMEOUTPROC( double timeout );
	public delegate void PFNGLFWPOSTEMPTYEVENTPROC();
	public delegate int PFNGLFWGETINPUTMODEPROC( void* window, int mode );
	public delegate void PFNGLFWSETINPUTMODEPROC( void* window, int mode, int value );
	public delegate void* PFNGLFWGETKEYNAMEPROC( int key, int scancode );
	public delegate int PFNGLFWGETKEYPROC( void* window, int key );
	public delegate int PFNGLFWGETMOUSEBUTTONPROC( void* window, int button );
	public delegate void PFNGLFWGETCURSORPOSPROC( void* window, ref double xpos, ref double ypos );
	public delegate void PFNGLFWSETCURSORPOSPROC( void* window, double xpos, double ypos );
	public delegate void* PFNGLFWCREATECURSORPROC( ref GLFWimage image, int xhot, int yhot );
	public delegate void* PFNGLFWCREATESTANDARDCURSORPROC( int shape );
	public delegate void PFNGLFWDESTROYCURSORPROC( void* cursor );
	public delegate void PFNGLFWSETCURSORPROC( void* window, void* cursor );
	public delegate GLFWkeyfun PFNGLFWSETKEYCALLBACKPROC( void* window, GLFWkeyfun cbfun );
	public delegate GLFWcharfun PFNGLFWSETCHARCALLBACKPROC( void* window, GLFWcharfun cbfun );
	public delegate GLFWcharmodsfun PFNGLFWSETCHARMODSCALLBACKPROC( void* window, GLFWcharmodsfun cbfun );
	public delegate GLFWmousebuttonfun PFNGLFWSETMOUSEBUTTONCALLBACKPROC( void* window, GLFWmousebuttonfun cbfun );
	public delegate GLFWcursorposfun PFNGLFWSETCURSORPOSCALLBACKPROC( void* window, GLFWcursorposfun cbfun );
	public delegate GLFWcursorenterfun PFNGLFWSETCURSORENTERCALLBACKPROC( void* window, GLFWcursorenterfun cbfun );
	public delegate GLFWscrollfun PFNGLFWSETSCROLLCALLBACKPROC( void* window, GLFWscrollfun cbfun );
	public delegate GLFWdropfun PFNGLFWSETDROPCALLBACKPROC( void* window, GLFWdropfun cbfun );
	public delegate int PFNGLFWJOYSTICKPRESENTPROC( int joy );
	public delegate void* PFNGLFWGETJOYSTICKAXESPROC( int joy, ref int count );
	public delegate void* PFNGLFWGETJOYSTICKBUTTONSPROC( int joy, ref int count );
	public delegate void* PFNGLFWGETJOYSTICKNAMEPROC( int joy );
	public delegate GLFWjoystickfun PFNGLFWSETJOYSTICKCALLBACKPROC( GLFWjoystickfun cbfun );
	public delegate void PFNGLFWSETCLIPBOARDSTRINGPROC( void* window, [In] [MarshalAs( UnmanagedType.LPStr )] string @string );
	public delegate void* PFNGLFWGETCLIPBOARDSTRINGPROC( void* window );
	public delegate double PFNGLFWGETTIMEPROC();
	public delegate void PFNGLFWSETTIMEPROC( double time );
	public delegate uint PFNGLFWGETTIMERVALUEPROC();
	public delegate uint PFNGLFWGETTIMERFREQUENCYPROC();
	public delegate void PFNGLFWMAKECONTEXTCURRENTPROC( void* window );
	public delegate void* PFNGLFWGETCURRENTCONTEXTPROC();
	public delegate void PFNGLFWSWAPBUFFERSPROC( void* window );
	public delegate void PFNGLFWSWAPINTERVALPROC( int interval );
	public delegate int PFNGLFWEXTENSIONSUPPORTEDPROC( [In] [MarshalAs( UnmanagedType.LPStr )] string extension );
	public delegate void* PFNGLFWGETPROCADDRESSPROC( [In] [MarshalAs( UnmanagedType.LPStr )] string procname );
	public delegate int PFNGLFWVULKANSUPPORTEDPROC();
	public delegate void* PFNGLFWGETREQUIREDINSTANCEEXTENSIONSPROC( ref uint count );
	#endregion

	#region Methods
	[ExternalMethod]
	public static PFNGLFWINITPROC glfwInit;
	[ExternalMethod]
	public static PFNGLFWTERMINATEPROC glfwTerminate;
	[ExternalMethod]
	public static PFNGLFWGETVERSIONPROC glfwGetVersion;
	[ExternalMethod]
	public static PFNGLFWGETVERSIONSTRINGPROC glfwGetVersionString;
	[ExternalMethod]
	public static PFNGLFWSETERRORCALLBACKPROC glfwSetErrorCallback;
	[ExternalMethod]
	public static PFNGLFWGETMONITORSPROC glfwGetMonitors;
	[ExternalMethod]
	public static PFNGLFWGETPRIMARYMONITORPROC glfwGetPrimaryMonitor;
	[ExternalMethod]
	public static PFNGLFWGETMONITORPOSPROC glfwGetMonitorPos;
	[ExternalMethod]
	public static PFNGLFWGETMONITORPHYSICALSIZEPROC glfwGetMonitorPhysicalSize;
	[ExternalMethod]
	public static PFNGLFWGETMONITORNAMEPROC glfwGetMonitorName;
	[ExternalMethod]
	public static PFNGLFWSETMONITORCALLBACKPROC glfwSetMonitorCallback;
	[ExternalMethod]
	public static PFNGLFWGETVIDEOMODESPROC glfwGetVideoModes;
	[ExternalMethod]
	public static PFNGLFWGETVIDEOMODEPROC glfwGetVideoMode;
	[ExternalMethod]
	public static PFNGLFWSETGAMMAPROC glfwSetGamma;
	[ExternalMethod]
	public static PFNGLFWGETGAMMARAMPPROC glfwGetGammaRamp;
	[ExternalMethod]
	public static PFNGLFWSETGAMMARAMPPROC glfwSetGammaRamp;
	[ExternalMethod]
	public static PFNGLFWDEFAULTWINDOWHINTSPROC glfwDefaultWindowHints;
	[ExternalMethod]
	public static PFNGLFWWINDOWHINTPROC glfwWindowHint;
	[ExternalMethod]
	public static PFNGLFWCREATEWINDOWPROC glfwCreateWindow;
	[ExternalMethod]
	public static PFNGLFWDESTROYWINDOWPROC glfwDestroyWindow;
	[ExternalMethod]
	public static PFNGLFWWINDOWSHOULDCLOSEPROC glfwWindowShouldClose;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWSHOULDCLOSEPROC glfwSetWindowShouldClose;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWTITLEPROC glfwSetWindowTitle;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWICONPROC glfwSetWindowIcon;
	[ExternalMethod]
	public static PFNGLFWGETWINDOWPOSPROC glfwGetWindowPos;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWPOSPROC glfwSetWindowPos;
	[ExternalMethod]
	public static PFNGLFWGETWINDOWSIZEPROC glfwGetWindowSize;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWSIZELIMITSPROC glfwSetWindowSizeLimits;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWASPECTRATIOPROC glfwSetWindowAspectRatio;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWSIZEPROC glfwSetWindowSize;
	[ExternalMethod]
	public static PFNGLFWGETFRAMEBUFFERSIZEPROC glfwGetFramebufferSize;
	[ExternalMethod]
	public static PFNGLFWGETWINDOWFRAMESIZEPROC glfwGetWindowFrameSize;
	[ExternalMethod]
	public static PFNGLFWICONIFYWINDOWPROC glfwIconifyWindow;
	[ExternalMethod]
	public static PFNGLFWRESTOREWINDOWPROC glfwRestoreWindow;
	[ExternalMethod]
	public static PFNGLFWMAXIMIZEWINDOWPROC glfwMaximizeWindow;
	[ExternalMethod]
	public static PFNGLFWSHOWWINDOWPROC glfwShowWindow;
	[ExternalMethod]
	public static PFNGLFWHIDEWINDOWPROC glfwHideWindow;
	[ExternalMethod]
	public static PFNGLFWFOCUSWINDOWPROC glfwFocusWindow;
	[ExternalMethod]
	public static PFNGLFWGETWINDOWMONITORPROC glfwGetWindowMonitor;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWMONITORPROC glfwSetWindowMonitor;
	[ExternalMethod]
	public static PFNGLFWGETWINDOWATTRIBPROC glfwGetWindowAttrib;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWUSERPOINTERPROC glfwSetWindowUserPointer;
	[ExternalMethod]
	public static PFNGLFWGETWINDOWUSERPOINTERPROC glfwGetWindowUserPointer;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWPOSCALLBACKPROC glfwSetWindowPosCallback;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWSIZECALLBACKPROC glfwSetWindowSizeCallback;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWCLOSECALLBACKPROC glfwSetWindowCloseCallback;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWREFRESHCALLBACKPROC glfwSetWindowRefreshCallback;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWFOCUSCALLBACKPROC glfwSetWindowFocusCallback;
	[ExternalMethod]
	public static PFNGLFWSETWINDOWICONIFYCALLBACKPROC glfwSetWindowIconifyCallback;
	[ExternalMethod]
	public static PFNGLFWSETFRAMEBUFFERSIZECALLBACKPROC glfwSetFramebufferSizeCallback;
	[ExternalMethod]
	public static PFNGLFWPOLLEVENTSPROC glfwPollEvents;
	[ExternalMethod]
	public static PFNGLFWWAITEVENTSPROC glfwWaitEvents;
	[ExternalMethod]
	public static PFNGLFWWAITEVENTSTIMEOUTPROC glfwWaitEventsTimeout;
	[ExternalMethod]
	public static PFNGLFWPOSTEMPTYEVENTPROC glfwPostEmptyEvent;
	[ExternalMethod]
	public static PFNGLFWGETINPUTMODEPROC glfwGetInputMode;
	[ExternalMethod]
	public static PFNGLFWSETINPUTMODEPROC glfwSetInputMode;
	[ExternalMethod]
	public static PFNGLFWGETKEYNAMEPROC glfwGetKeyName;
	[ExternalMethod]
	public static PFNGLFWGETKEYPROC glfwGetKey;
	[ExternalMethod]
	public static PFNGLFWGETMOUSEBUTTONPROC glfwGetMouseButton;
	[ExternalMethod]
	public static PFNGLFWGETCURSORPOSPROC glfwGetCursorPos;
	[ExternalMethod]
	public static PFNGLFWSETCURSORPOSPROC glfwSetCursorPos;
	[ExternalMethod]
	public static PFNGLFWCREATECURSORPROC glfwCreateCursor;
	[ExternalMethod]
	public static PFNGLFWCREATESTANDARDCURSORPROC glfwCreateStandardCursor;
	[ExternalMethod]
	public static PFNGLFWDESTROYCURSORPROC glfwDestroyCursor;
	[ExternalMethod]
	public static PFNGLFWSETCURSORPROC glfwSetCursor;
	[ExternalMethod]
	public static PFNGLFWSETKEYCALLBACKPROC glfwSetKeyCallback;
	[ExternalMethod]
	public static PFNGLFWSETCHARCALLBACKPROC glfwSetCharCallback;
	[ExternalMethod]
	public static PFNGLFWSETCHARMODSCALLBACKPROC glfwSetCharModsCallback;
	[ExternalMethod]
	public static PFNGLFWSETMOUSEBUTTONCALLBACKPROC glfwSetMouseButtonCallback;
	[ExternalMethod]
	public static PFNGLFWSETCURSORPOSCALLBACKPROC glfwSetCursorPosCallback;
	[ExternalMethod]
	public static PFNGLFWSETCURSORENTERCALLBACKPROC glfwSetCursorEnterCallback;
	[ExternalMethod]
	public static PFNGLFWSETSCROLLCALLBACKPROC glfwSetScrollCallback;
	[ExternalMethod]
	public static PFNGLFWSETDROPCALLBACKPROC glfwSetDropCallback;
	[ExternalMethod]
	public static PFNGLFWJOYSTICKPRESENTPROC glfwJoystickPresent;
	[ExternalMethod]
	public static PFNGLFWGETJOYSTICKAXESPROC glfwGetJoystickAxes;
	[ExternalMethod]
	public static PFNGLFWGETJOYSTICKBUTTONSPROC glfwGetJoystickButtons;
	[ExternalMethod]
	public static PFNGLFWGETJOYSTICKNAMEPROC glfwGetJoystickName;
	[ExternalMethod]
	public static PFNGLFWSETJOYSTICKCALLBACKPROC glfwSetJoystickCallback;
	[ExternalMethod]
	public static PFNGLFWSETCLIPBOARDSTRINGPROC glfwSetClipboardString;
	[ExternalMethod]
	public static PFNGLFWGETCLIPBOARDSTRINGPROC glfwGetClipboardString;
	[ExternalMethod]
	public static PFNGLFWGETTIMEPROC glfwGetTime;
	[ExternalMethod]
	public static PFNGLFWSETTIMEPROC glfwSetTime;
	[ExternalMethod]
	public static PFNGLFWGETTIMERVALUEPROC glfwGetTimerValue;
	[ExternalMethod]
	public static PFNGLFWGETTIMERFREQUENCYPROC glfwGetTimerFrequency;
	[ExternalMethod]
	public static PFNGLFWMAKECONTEXTCURRENTPROC glfwMakeContextCurrent;
	[ExternalMethod]
	public static PFNGLFWGETCURRENTCONTEXTPROC glfwGetCurrentContext;
	[ExternalMethod]
	public static PFNGLFWSWAPBUFFERSPROC glfwSwapBuffers;
	[ExternalMethod]
	public static PFNGLFWSWAPINTERVALPROC glfwSwapInterval;
	[ExternalMethod]
	public static PFNGLFWEXTENSIONSUPPORTEDPROC glfwExtensionSupported;
	[ExternalMethod]
	public static PFNGLFWGETPROCADDRESSPROC glfwGetProcAddress;
	[ExternalMethod]
	public static PFNGLFWVULKANSUPPORTEDPROC glfwVulkanSupported;
	[ExternalMethod]
	public static PFNGLFWGETREQUIREDINSTANCEEXTENSIONSPROC glfwGetRequiredInstanceExtensions;
	#endregion
}