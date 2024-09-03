using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using KeyboardHook;
using InputSimulator;
using InputSimulator.Native;

namespace GameRotation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public KeyboardHook.KeyboardHook Hook { get; set; }

		private string _message = "hello world";

		public string Message
		{
			get => _message;
			set => SetField(ref _message, value);
		}

		private string _keyUp = "KeyUp";

		public string KeyUp
		{
			get => _keyUp;
			set => SetField(ref _keyUp, value);
		}

		private string _keyDown = "KeyDown";

		public string KeyDown
		{
			get => _keyDown;
			set => SetField(ref _keyDown, value);
		}

		private string _sysKeyUp = "SysKeyUp";

		public string SysKeyUp
		{
			get => _sysKeyUp;
			set => SetField(ref _sysKeyUp, value);
		}

		private string _sysKeyDown = "SysKeyDown";

		public string SysKeyDown
		{
			get => _sysKeyDown;
			set => SetField(ref _sysKeyDown, value);
		}

		public MainWindow()
		{
			InitializeComponent();
			Hook = new KeyboardHook.KeyboardHook();
			Hook.SetAllKeyDownBinding(OnHookKeyDown);
		}

		private void OnHookKeyDown(KeyStrokeInfo strokeInfo, VKeys key, KeyboardState keyboardState)
		{
			this.Dispatcher.BeginInvoke(() => Message = $"KeyDown: {key} flag: {strokeInfo.Flags:b8} scanCode:{strokeInfo.ScanCode} time:{strokeInfo.Time} extraInfo: {strokeInfo.ExtraInfo}");
			// if((strokeInfo.Flags & 0b10000) == 0)
			// {
			// 	Task.Factory.StartNew(()=>PressSameKeyAfter5Seconds(key, keyboardState));
			// }
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		private InputSimulator.InputSimulator simulator = new InputSimulator.InputSimulator();

		private void StartKeyPress(object sender, RoutedEventArgs e)
		{
			simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LALT, VirtualKeyCode.KEY_Q);
		}

		private void StopKeyPress(object sender, RoutedEventArgs e)
		{
		}

		private void PressSameKeyAfter5Seconds(VKeys key, KeyboardState state)
		{
			if (key is VKeys.ALT or VKeys.SHIFT or VKeys.CONTROL or VKeys.LWIN or VKeys.RWIN)
			{
				simulator.Keyboard.Sleep(5000).KeyPress((VirtualKeyCode)key);
				return;
			}

			if (state.IsAltPressed || state.IsCtrlPressed || state.IsShiftPressed)
			{
				List<VKeys> modifierKeys = state.GetPressedKeys();
				List<VirtualKeyCode> modifierKeyCodes = modifierKeys.Select(key => (VirtualKeyCode)key).ToList();
				simulator.Keyboard.Sleep(5000).ModifiedKeyStroke(modifierKeyCodes, (VirtualKeyCode)key);
			}

			else simulator.Keyboard.Sleep(5000).KeyPress((VirtualKeyCode)key);
		}
	}
}