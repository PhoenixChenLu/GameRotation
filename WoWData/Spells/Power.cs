namespace WoWData;

public class Power
{
	public PowerType PowerType { get; set; }

	public int Value { get; set; }

	public static Power operator +(Power power, PowerChange powerChange)
	{
		if (powerChange.PowerType == power.PowerType)
		{
			return new Power()
			{
				PowerType = power.PowerType,
				Value = power.Value + powerChange.Value
			};
		}
		else throw new Exception("PowerType mismatch");
	}
	
	public static Power operator -(Power power, PowerChange powerChange)
	{
		if (powerChange.PowerType == power.PowerType)
		{
			return new Power()
			{
				PowerType = power.PowerType,
				Value = power.Value - powerChange.Value
			};
		}
		else throw new Exception("PowerType mismatch");
	}
}