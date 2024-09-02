using System.Drawing;
using WoWData.Entities;

namespace WoWData.Buffs;

public class Buff
{
	public bool Exists { get; set; }

	public UnitType FromType { get; init; }

	public UnitType ToType { get; init; }

	public int Id { get; init; }

	public bool Stackable { get; set; } = false;

	public int CurrentStack { get; set; }

	public int MaxStack { get; set; } = 1;

	public string Name { get; init; }

	public string ChineseName { get; init; }

	public string Description { get; init; }

	public uint RemainingTime { get; set; }

	public DateTime EndDateTime { get; set; }
	
	public bool DontShowTime { get; set; } = false;

	public void SetEndTime(DateTime endTime)
	{
		EndDateTime = endTime;
	}

	public void UpdateFromColorAndCurrentTime(Color color, DateTime currentTime)
	{
		byte r = color.R;
		byte g = color.G;
		byte b = color.B;

		if (r < 128)
		{
			Exists = false;
			RemainingTime = 0;
			EndDateTime = DateTime.MinValue;
			return;
		}

		r -= 128;
		Exists = true;
		if (Stackable)
		{
			CurrentStack = r;
			uint ticksToExpire = (uint)(g << 8 | b);
			RemainingTime = ticksToExpire;
			EndDateTime = currentTime + TimeSpan.FromMilliseconds(ticksToExpire);
		}
		else
		{
			CurrentStack = 0;
			uint ticksToExpire = (uint)(r << 16 | g << 8 | b);
			RemainingTime = ticksToExpire;
			EndDateTime = currentTime + TimeSpan.FromMilliseconds(ticksToExpire);
		}
	}

	public static Buff EmptyBuff => new Buff()
	{
		FromType = UnitType.Empty,
		ToType = UnitType.Empty,
		Id = 0,
		Name = "Empty",
		ChineseName = "空",
		Description = "空",
		CurrentStack = 0,
		EndDateTime = DateTime.MinValue
	};
}