using System.Drawing;
using System.Windows;
using ScreenReader;

namespace GameRotation.Controls;

public partial class ScreenReadControl
{
	private void SetScreenShotInfo(object sender, RoutedEventArgs e)
	{
		_screenReader = new ScreenShot(ScreenShotWidth, ScreenShotHeight, ScreenShotX, ScreenShotY);
	}

	private void TakeScreenShot(object sender, RoutedEventArgs e)
	{
		Bitmap bmp = _screenReader.GetScreenShot();
		ScreenReadCompleted?.Invoke(bmp);
	}

	private Color GetColor()
	{
		return Screen.GetPixel(0, 0);
	}

	public event Action<Bitmap> ScreenReadCompleted;

	private void ReadScreenContinuously()
	{
		while (ScreenContinuousRead)
		{
			Bitmap screenRead = _screenReader.GetScreenShot();
			ScreenReadCompleted?.Invoke(screenRead);
		}
	}

	private void BeginScreenContinuousRead(object sender, RoutedEventArgs e)
	{
		StopScreenContinuousRead(sender, e);
		ScreenContinuousRead = true;
		Task.Factory.StartNew(ReadScreenContinuously);
	}

	private void StopScreenContinuousRead(object sender, RoutedEventArgs e)
	{
		ScreenContinuousRead = false;
	}


}