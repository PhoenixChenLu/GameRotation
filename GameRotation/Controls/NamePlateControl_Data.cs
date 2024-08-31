namespace GameRotation.Controls;

public partial class NamePlateControl
{
	public Icon[] DebuffIcons { get; set; } = new Icon[10];
	
	private void InitializeSelfIcons()
	{
		DebuffIcons[0] = Debuff1Icon;
		DebuffIcons[1] = Debuff2Icon;
		DebuffIcons[2] = Debuff3Icon;
		DebuffIcons[3] = Debuff4Icon;
		DebuffIcons[4] = Debuff5Icon;
		DebuffIcons[5] = Debuff6Icon;
		DebuffIcons[6] = Debuff7Icon;
		DebuffIcons[7] = Debuff8Icon;
		DebuffIcons[8] = Debuff9Icon;
		DebuffIcons[9] = Debuff10Icon;
	}
}