using System.Drawing;

namespace ScreenReader;

public static class Functions
{
	public static readonly DateTime SystemStartTime = DateTime.Now - TimeSpan.FromMilliseconds(Environment.TickCount);

	public static uint ColorToUint(Color colorHigh, Color colorLow)
	{
		return (uint)((colorHigh.B << 24) | (colorLow.R << 16) | (colorLow.G << 8) | colorLow.B);
	}

	public static uint ColorToUint(Color color)
	{
		return (uint)((color.R << 16) | (color.G << 8) | color.B);
	}

	public static bool[] ByteToBool(byte b)
	{
		bool[] result = new bool[8];
		for (int i = 0; i < 8; i++)
		{
			result[i] = (b & (0b10000000 >> i)) != 0;
		}

		return result;
	}

	public static bool[] ColorToBool(Color color)
	{
		bool[] result = new bool[24];
		bool[] r = ByteToBool(color.R);
		bool[] g = ByteToBool(color.G);
		bool[] b = ByteToBool(color.B);
		for (int i = 0; i < 8; i++)
		{
			result[i] = r[i];
			result[i + 8] = g[i];
			result[i + 16] = b[i];
		}

		return result;
	}

	public static TimeSpan ColorToTimeSpan(Color colorHigh, Color colorLow)
	{
		uint colorUint = ColorToUint(colorHigh, colorLow);
		return TimeSpan.FromMilliseconds(colorUint);
	}

	public static TimeSpan ColorToTimeSpan(Color color)
	{
		uint colorUint = ColorToUint(color);
		return TimeSpan.FromMilliseconds(colorUint);
	}
	
	public static DateTime ColorToDateTime(Color colorHigh, Color colorLow)
	{
		return SystemStartTime + ColorToTimeSpan(colorHigh, colorLow);
	}
	
	public static DateTime UintToDateTime(uint colorUint)
	{
		return SystemStartTime + TimeSpan.FromMilliseconds(colorUint);
	}
}