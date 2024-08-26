using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using KeyboardHook;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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

		private void OnHookKeyDown(long time, int flag, VKeys key, KeyboardState keyboardState)
		{
			this.Dispatcher.BeginInvoke(() => Message = $"KeyDown: {key} flag: {flag:B}");
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
	}
}