using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GameRotation.Entities;
using ScreenReader;
using Color = System.Windows.Media.Color;

namespace GameRotation.Controls;

public partial class ScreenReadControl
{
	#region 私有变量

	private int _screenShotWidth = 100;

	private int _screenShotHeight = 100;

	private int _screenShotX = 0;

	private int _screenShotY = 0;

	private Bitmap _screen = new Bitmap(100, 100);
	
	private ScreenShot _screenReader;

	private ImageSource _screenSource;
	
	private byte _r;
	
	private byte _g;
	
	private byte _b;

	private Color _watchPointColor = Colors.Black;
	
	private bool _screenContinuousRead = false;

	#endregion

	#region 公共变量

	public int ScreenShotWidth
	{
		get => _screenShotWidth;
		set => SetField(ref _screenShotWidth, value);
	}

	public int ScreenShotHeight
	{
		get => _screenShotHeight;
		set => SetField(ref _screenShotHeight, value);
	}

	public int ScreenShotX
	{
		get => _screenShotX;
		set => SetField(ref _screenShotX, value);
	}

	public int ScreenShotY
	{
		get => _screenShotY;
		set => SetField(ref _screenShotY, value);
	}

	public Bitmap Screen
	{
		get => _screen;
		set => SetField(ref _screen, value);
	}
	
	public ImageSource ScreenSource
	{
		get => _screenSource;
		set => SetField(ref _screenSource, value);
	}
	
	public byte R
	{
		get => _r;
		set => SetField(ref _r, value);
	}
	
	public byte G
	{
		get => _g;
		set => SetField(ref _g, value);
	}
	
	public byte B
	{
		get => _b;
		set => SetField(ref _b, value);
	}
	
	public Color WatchPointColor
	{
		get => _watchPointColor;
		set => SetField(ref _watchPointColor, value);
	}
	
	public bool ScreenContinuousRead
	{
		get => _screenContinuousRead;
		set => SetField(ref _screenContinuousRead, value);
	}

	#endregion
}