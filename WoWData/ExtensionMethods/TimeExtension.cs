using System.Drawing;

namespace WoWData.ExtensionMethods;

public static class TimeExtension
{
	public static readonly DateTime SystemStartTime = DateTime.Now - TimeSpan.FromMilliseconds(Environment.TickCount);

	public static DateTime ToDateTime(this uint ticks)
	{
		return SystemStartTime + TimeSpan.FromMilliseconds(ticks);
	}

	public static TimeSpan ToTimeSpan(this Color color)
	{
		return TimeSpan.FromMilliseconds(color.ToUint());
	}

	public static TimeSpan ColorToTimeSpan(Color high, Color low)
	{
		return TimeSpan.FromMilliseconds(ColorExtensions.ColorToUint(high, low));
	}
	
	
}