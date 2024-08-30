using WoWData.Entities;

namespace WoWData.Buffs;

public class Buff
{
	public UnitType FromType { get; init; }
	
	public UnitType ToType { get; init; }
	
	public int Id { get; init; }

	public bool Stackable { get; set; } = false;

	public int CurrentStack { get; set; }

	public int MaxStack { get; set; } = 1;

	public string Name { get; init; }

	public string ChineseName { get; init; }

	public string Description { get; init; }

	public DateTime EndDateTime { get; set; }

	public void SetEndTime(DateTime endTime)
	{
		EndDateTime = endTime;
	}
}