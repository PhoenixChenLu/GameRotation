using System.Runtime.Serialization;

namespace KeyboardHook;

public struct KeyBinding
{
	public VKeys Key { get; set; }
	public KeyboardState KeyboardState { get; set; }

	public KeyBinding(VKeys key, KeyboardState keyboardState)
	{
		Key = key;
		KeyboardState = keyboardState;
	}

	public KeyBinding(int keyCode, KeyboardState keyboardState)
	{
		Key = (VKeys)keyCode;
		KeyboardState = keyboardState;
	}

	public KeyBinding(VKeys key, bool ctrlState = false, bool shiftState = false, bool altState = false, bool capsLock = false)
	{
		Key = key;
		KeyboardState = new KeyboardState(ctrlState, shiftState, altState, capsLock);
	}

	public override string ToString()
	{
		return KeyboardState.ToString() + Key.GetString();
	}
}