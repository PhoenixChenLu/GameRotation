using System.IO;
using System.Windows.Media.Imaging;

namespace GameRotation.Entities;

public static class Extensions
{
	public static BitmapImage ToBitmapImage(this System.Drawing.Bitmap bitmap)
	{         
		MemoryStream ms = new MemoryStream();
		bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
		BitmapImage image = new BitmapImage();
		image.BeginInit();
		ms.Seek(0, SeekOrigin.Begin);
		image.StreamSource = ms;
		image.EndInit();

		return image;
	}
}