using System.Drawing;

namespace WoWData.ExtensionMethods;

public static class ColorExtensions
{
	/// <summary>
	/// 将颜色根据RGB转换为整数
	/// </summary>
	/// <param name="color">颜色数值</param>
	/// <returns>转化好的整数</returns>
	public static uint ToUint(this Color color)
	{
		return (uint)((color.R << 16) | (color.G << 8) | color.B);
	}

	/// <summary>
	/// 将颜色根据RGB转换为整数
	/// </summary>
	/// <param name="high">高位颜色</param>
	/// <param name="low">低位颜色</param>
	/// <returns>转化好的整数</returns>
	public static uint ColorToUint(Color high, Color low)
	{
		uint higInt = high.ToUint(), lowInt = low.ToUint();
		return higInt << 24 | lowInt;
	}
	
	/// <summary>
	/// 将颜色转化为布尔数组
	/// </summary>
	/// <param name="color">颜色值</param>
	/// <returns>颜色按照RGB每一位的布尔值</returns>
	public static bool[] ToBool(this Color color)
	{
		bool[] result = new bool[24];
		bool[] r = color.R.ToBool();
		bool[] g = color.G.ToBool();
		bool[] b = color.B.ToBool();
		for (int i = 0; i < 8; i++)
		{
			result[i] = r[i];
			result[i + 8] = g[i];
			result[i + 16] = b[i];
		}

		return result;
	}
	
}