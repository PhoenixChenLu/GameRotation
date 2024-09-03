using System.Runtime.InteropServices;

namespace KeyboardSimulator.Entities;

[StructLayout(LayoutKind.Explicit)]
public struct MOUSEKEYBDHARDWAREINPUT
{
	[FieldOffset(0)] public KEYBDINPUT Keyboard;
}