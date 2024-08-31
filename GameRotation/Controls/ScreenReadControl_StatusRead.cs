using System.Drawing;
using GameRotation.Entities;
using ScreenReader;
using ScreenReader.Player;

namespace GameRotation.Controls;

public partial class ScreenReadControl
{
	public AllInfo AllInfo { get; private set; } = new();

	private void ReadAllInfo(Bitmap bmp)
	{
		AllInfo.UpdateFromImage(bmp);
	}

	private void InitializeReadEvents()
	{
		AllInfo.DataUpdated += UpdateAllDisplayFromInfo;
	}

	private void UpdateAllDisplayFromInfo(AllInfo info)
	{
		this.Dispatcher.BeginInvoke(() =>
		{
			Screen = info.Image;
			ScreenSource = info.Image.ToBitmapImage();
		});
		PlayerStatusControl.DispatcherUpdateFromPlayerStatus(info.PlayerStatus);
		
	}
}