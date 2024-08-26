﻿using System.Diagnostics;

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

	/// <summary>
	/// 所有按键按下都会触发的事件
	/// </summary>
	private (Action<long, int, VKeys, KeyboardState> action, bool intercept) _allKeyDownAction = (null, false);

	/// <summary>
	/// 所有按键弹起都会触发的事件
	/// </summary>
	private (Action<long, int, VKeys, KeyboardState> action, bool intercept) _allKeyUpAction = (null, false);

	/// <summary>
	/// 设定所有按键按下都会触发的事件
	/// </summary>
	/// <param name="action">所触发的动作</param>
	/// <param name="intercept">是否截断信号</param>
	public void SetAllKeyDownBinding(Action<long, int, VKeys, KeyboardState> action, bool intercept = false)
	{
		_allKeyDownAction = (action, intercept);
	}

	/// <summary>
	/// 设定所有按键弹起都会触发的事件
	/// </summary>
	/// <param name="action">所触发的动作</param>
	/// <param name="intercept">是否截断信号</param>
	public void SetAllKeyUpBinding(Action<long, int, VKeys, KeyboardState> action, bool intercept = false)
	{
		_allKeyUpAction = (action, intercept);
	}

	/// <summary>
	/// 用于储存按下单个按键绑定的动作字典
	/// </summary>
	private Dictionary<KeyBinging, (Action<long, int> action, bool intercept)> _keyDownActions = new();

	/// <summary>
	/// 用于储存弹起单个按键绑定的动作字典
	/// </summary>
	private Dictionary<KeyBinging, (Action<long, int> action, bool intercept)> _keyUpActions = new();

	/// <summary>
	/// 设定按键按下的绑定
	/// </summary>
	/// <param name="key">按键</param>
	/// <param name="action">触发的动作</param>
	/// <param name="intercept">是否截断信号</param>
	/// <param name="ctrlState">是否按下Ctrl</param>
	/// <param name="shiftState">是否按下Shift</param>
	/// <param name="altState">是否按下Alt</param>
	/// <param name="capsLock">是否开启大写锁定</param>
	public void SetKeyDownBinding(VKeys key, Action<long, int> action, bool intercept = false, bool ctrlState = false, bool shiftState = false, bool altState = false, bool capsLock = false)
	{
		_keyDownActions[new KeyBinging(key, new KeyboardState(ctrlState, shiftState, altState, capsLock))] = (action, intercept);
	}

	/// <summary>
	/// 设定按键弹起的绑定
	/// </summary>
	/// <param name="key">按键</param>
	/// <param name="action">触发的动作</param>
	/// <param name="intercept">是否截断信号</param>
	/// <param name="ctrlState">是否按下Ctrl</param>
	/// <param name="shiftState">是否按下Shift</param>
	/// <param name="altState">是否按下Alt</param>
	/// <param name="capsLock">是否开启大写锁定</param>
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

				if (_allKeyDownAction is (not null, _) allDownAction)
				{
					allDownAction.action.Invoke(lParam.Time, lParam.Flags, (VKeys)(lParam.KeyCode), state);
					intercept = intercept || allDownAction.intercept;
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

				if (_allKeyUpAction is (not null, _) allUpAction)
				{
					allUpAction.action.Invoke(lParam.Time, lParam.Flags, (VKeys)(lParam.KeyCode), state);
					intercept = intercept || allUpAction.intercept;
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