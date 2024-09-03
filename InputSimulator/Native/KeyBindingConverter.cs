using KeyboardHook;

namespace InputSimulator.Native;

public static class KeyBindingConverter
{
	public static VirtualKeyCode ToVirtualKeyCode(this KeyBinding binding)
	{
		return (VirtualKeyCode)binding.Key;
	}

	public static List<VirtualKeyCode>? ToModifiers(this KeyBinding binding)
	{
		if (binding.KeyboardState is { IsCtrlPressed: false, IsShiftPressed: false, IsAltPressed: false }) return null;
		var modifiers = new List<VirtualKeyCode>();
		if (binding.KeyboardState.LCtrlPressed) modifiers.Add(VirtualKeyCode.LCONTROL);
		if (binding.KeyboardState.RCtrlPressed) modifiers.Add(VirtualKeyCode.RCONTROL);
		if (binding.KeyboardState.LShiftPressed) modifiers.Add(VirtualKeyCode.LSHIFT);
		if (binding.KeyboardState.RShiftPressed) modifiers.Add(VirtualKeyCode.RSHIFT);
		if (binding.KeyboardState.LAltPressed) modifiers.Add(VirtualKeyCode.LALT);
		if (binding.KeyboardState.RAltPressed) modifiers.Add(VirtualKeyCode.RALT);
		return modifiers;

	}
}