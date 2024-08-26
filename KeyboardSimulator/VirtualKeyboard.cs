using System.Runtime.InteropServices;
using KeyboardSimulator.Entities;

namespace KeyboardSimulator;

public class VirtualKeyboard
{
	private static bool SendInput(Input[] inputs)
	{
		var successInputs = ExternMethods.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

		return successInputs == inputs.Length;
	}

	public static bool Press(VKeys key, bool alt = false, bool ctrl = false, bool shift = false)
	{
		List<Input> inputs = new();

		List<VKeys> altPressed = AltPressed(), ctrlPressed = CtrlPressed(), shiftPressed = ShiftPressed();

		bool altDown = altPressed.Count > 0, ctrlDown = ctrlPressed.Count > 0, shiftDown = shiftPressed.Count > 0;

		if (altDown != alt)
		{
			switch (alt)
			{
				case true:
					inputs.Add(VKeys.LALT.Down());
					break;
				case false:
					inputs.AddRange(altPressed.Select(altKey => altKey.Up()));
					break;
			}
		}

		if (ctrlDown != ctrl)
		{
			switch (ctrl)
			{
				case true:
					inputs.Add(VKeys.LCONTROL.Down());
					break;
				case false:
					inputs.AddRange(ctrlPressed.Select(ctrlKey => ctrlKey.Up()));
					break;
			}
		}

		if (shiftDown != shift)
		{
			switch (shift)
			{
				case true:
					inputs.Add(VKeys.LSHIFT.Down());
					break;
				case false:
					inputs.AddRange(shiftPressed.Select(shiftKey => shiftKey.Up()));
					break;
			}
		}

		inputs.AddRange(key.Press());

		if (altDown != alt)
		{
			switch (alt)
			{
				case true:
					inputs.Add(VKeys.LALT.Up());
					break;
				case false:
					inputs.AddRange(altPressed.Select(altKey => altKey.Down()));
					break;
			}
		}

		if (ctrlDown != ctrl)
		{
			switch (ctrl)
			{
				case true:
					inputs.Add(VKeys.LCONTROL.Up());
					break;
				case false:
					inputs.AddRange(ctrlPressed.Select(ctrlKey => ctrlKey.Down()));
					break;
			}
		}

		if (shiftDown != shift)
		{
			switch (shift)
			{
				case true:
					inputs.Add(VKeys.LSHIFT.Up());
					break;
				case false:
					inputs.AddRange(shiftPressed.Select(shiftKey => shiftKey.Down()));
					break;
			}
		}

		return SendInput(inputs.ToArray());
	}

	private static List<VKeys> AltPressed()
	{
		List<VKeys> keys = new();
		if (ExternMethods.GetKeyState((int)VKeys.LALT) == -127)
		{
			keys.Add(VKeys.LALT);
		}

		if (ExternMethods.GetKeyState((int)VKeys.RALT) == -127)
		{
			keys.Add(VKeys.RALT);
		}

		return keys;
	}

	private static List<VKeys> CtrlPressed()
	{
		List<VKeys> keys = new();
		if (ExternMethods.GetKeyState((int)VKeys.LCONTROL) == -127)
		{
			keys.Add(VKeys.LCONTROL);
		}

		if (ExternMethods.GetKeyState((int)VKeys.RCONTROL) == -127)
		{
			keys.Add(VKeys.RCONTROL);
		}

		return keys;
	}

	private static List<VKeys> ShiftPressed()
	{
		List<VKeys> keys = new();
		if (ExternMethods.GetKeyState((int)VKeys.LSHIFT) == -127)
		{
			keys.Add(VKeys.LSHIFT);
		}

		if (ExternMethods.GetKeyState((int)VKeys.RSHIFT) == -127)
		{
			keys.Add(VKeys.RSHIFT);
		}

		return keys;
	}
}