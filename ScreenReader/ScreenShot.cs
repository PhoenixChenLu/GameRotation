using System.Drawing;

namespace ScreenReader;

public class ScreenShot
{
	/// <summary>
	/// 图像
	/// </summary>
	private Bitmap _image;

	/// <summary>
	/// 画布
	/// </summary>
	private Graphics _graphics;

	/// <summary>
	/// 宽度 
	/// </summary>
	public int Width { get; init; }

	/// <summary>
	/// 高度
	/// </summary>
	public int Height { get; init; }

	/// <summary>
	/// 屏幕读取的起始X坐标
	/// </summary>
	public int X { get; init; }

	/// <summary>
	/// 屏幕读取的起始Y坐标
	/// </summary>
	public int Y { get; init; }

	/// <summary>
	/// 初始化一个截图对象
	/// </summary>
	/// <param name="width">宽度</param>
	/// <param name="height">高度</param>
	/// <param name="x">屏幕起始X坐标</param>
	/// <param name="y">屏幕起始Y坐标</param>
	public ScreenShot(int width, int height, int x, int y)
	{
		Width = width;
		Height = height;
		X = x;
		Y = y;

		_image = new Bitmap(width, height);

		_graphics = Graphics.FromImage(_image);
	}

	/// <summary>
	/// 获得截图
	/// </summary>
	/// <returns>屏幕截图的BitMap对象</returns>
	public Bitmap GetScreenShot()
	{
		_graphics.CopyFromScreen(X, Y, 0, 0, _image.Size, CopyPixelOperation.SourceCopy);
		return new Bitmap(_image);
	}
}