using System.Drawing;
using System.Windows;
using GameRotation.Entities;
using ScreenReader;
using ScreenReader.Player;

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

	public PlayerStatus? PlayerStatus { get; private set; }

	public event Action<PlayerStatus> PlayerStatusChanged;

	private void ReadDataFromBitmapAndDisplay(Bitmap bmp)
	{
		PlayerStatus newPlayerStatus = PlayerStatusRead.ReadPlayerStatus(bmp);
		if (PlayerStatus?.CurrentTick != newPlayerStatus.CurrentTick)
		{
			PlayerStatus = newPlayerStatus;
			PlayerStatusChanged?.Invoke(newPlayerStatus);
		}
		
		this.Dispatcher.BeginInvoke(() =>
		{
			Screen = bmp;
			ScreenSource = bmp.ToBitmapImage();
		});
	}
}