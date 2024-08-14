using System.Diagnostics;

namespace KeyboardHook;

public class KeyboardHook : IDisposable
{
	/// <summary>
	/// 钩子的ID
	/// </summary>
	public IntPtr HookId = IntPtr.Zero;

	/// <summary>
	/// 钩子回调
	/// </summary>
	private event LowLevelKeyboardProc _hookCallback;

	public KeyboardHook()
	{
		if (_hookCallback == null) _hookCallback += _defaultHookCallback;

		SetHook();
	}

	public KeyboardHook(LowLevelKeyboardProc hookCallback)
	{
		_hookCallback = hookCallback;
		SetHook();
	}

	public void SetHookCallback(LowLevelKeyboardProc hookCallback)
	{
		if (_hookCallback.GetInvocationList().Contains(_defaultHookCallback)) _hookCallback -= _defaultHookCallback;
		_hookCallback += hookCallback;
		Dispose();
		SetHook();
	}

	private void SetHook()
	{
		using var curProcess = Process.GetCurrentProcess();
		using var curModule = curProcess.MainModule;
		{
			HookId = HookEx.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookCallback, HookEx.GetModuleHandle(curModule.ModuleName), 0);
		}
	}

	public void Dispose()
	{
		HookEx.UnhookWindowsHookEx(HookId);
	}

	#region 按键绑定逻辑储存

	private Dictionary<KeyBinging, (Action<long, int> action, bool intercept)> _keyDownActions = new();

	private Dictionary<KeyBinging, (Action<long, int> action, bool intercept)> _keyUpActions = new();

	public void SetKeyDownBinding(VKeys key, Action<long, int> action, bool intercept = false, bool ctrlState = false, bool shiftState = false, bool altState = false, bool capsLock = false)
	{
		_keyDownActions[new KeyBinging(key, new KeyboardState(ctrlState, shiftState, altState, capsLock))] = (action, intercept);
	}

	public void SetKeyUpBinding(VKeys key, Action<long, int> action, bool intercept = false, bool ctrlState = false, bool shiftState = false, bool altState = false, bool capsLock = false)
	{
		_keyUpActions[new KeyBinging(key, new KeyboardState(ctrlState, shiftState, altState, capsLock))] = (action, intercept);
	}

	public void SetKeyDownBinding(KeyBinging key, Action<long, int> action, bool intercept = false)
	{
		_keyDownActions[key] = (action, intercept);
	}

	public void SetKeyUpBinding(KeyBinging key, Action<long, int> action, bool intercept = false)
	{
		_keyUpActions[key] = (action, intercept);
	}

	public void UnbindKeyDown(KeyBinging key)
	{
		_keyDownActions.Remove(key);
	}

	public void UnbindKeyUp(KeyBinging key)
	{
		_keyUpActions.Remove(key);
	}

	public void ClearKeyDownBindings()
	{
		_keyDownActions.Clear();
	}

	public void ClearKeyUpBindings()
	{
		_keyUpActions.Clear();
	}

	public void ClearAllBindings()
	{
		ClearKeyDownBindings();
		ClearKeyUpBindings();
	}

	#endregion

	#region 产生信号

	private IntPtr _defaultHookCallback(int nCode, IntPtr wParam, ref KeyStrokeInfo lParam)
	{
		if (nCode < 0) return HookEx.CallNextHookEx(HookId, nCode, wParam, ref lParam);

		bool intercept = false;

		KeyboardState state = GetKeyboardState();

		switch (wParam)
		{
			case (IntPtr)WMKeys.WM_KEYDOWN or (IntPtr)WMKeys.WM_SYSKEYDOWN:
			{
				if (_keyDownActions.TryGetValue(new KeyBinging(lParam.KeyCode, state), out var action))
				{
					action.action.Invoke(lParam.Time, lParam.Flags);
					intercept = action.intercept;
				}

				break;
			}
			case (IntPtr)WMKeys.WM_KEYUP or (IntPtr)WMKeys.WM_SYSKEYUP:
			{
				if (_keyUpActions.TryGetValue(new KeyBinging(lParam.KeyCode, state), out var action))
				{
					action.action.Invoke(lParam.Time, lParam.Flags);
					intercept = action.intercept;
				}

				break;
			}
		}

		return intercept ? (IntPtr)1 : HookEx.CallNextHookEx(HookId, nCode, wParam, ref lParam);
	}

	private KeyboardState GetKeyboardState()
	{
		KeyboardState state = new KeyboardState();
		short lAlt = HookEx.GetKeyState((int)VKeys.LALT);
		short rAlt = HookEx.GetKeyState((int)VKeys.RALT);
		short lCtrl = HookEx.GetKeyState((int)VKeys.LCONTROL);
		short rCtrl = HookEx.GetKeyState((int)VKeys.RCONTROL);
		short lShift = HookEx.GetKeyState((int)VKeys.LSHIFT);
		short rShift = HookEx.GetKeyState((int)VKeys.RSHIFT);
		short capsLock = HookEx.GetKeyState((int)VKeys.CAPITAL);

		state.IsAltPressed = lAlt == -127 || rAlt == -127;
		state.IsCtrlPressed = lCtrl == -127 || rCtrl == -127;
		state.IsShiftPressed = lShift == -127 || rShift == -127;
		state.IsCapsLock = (capsLock & 0x0001) != 0;

		return state;
	}

	#endregion
}