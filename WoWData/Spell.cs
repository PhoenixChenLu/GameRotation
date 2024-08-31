namespace WoWData;

public class Spell
{
	public string Name { get; set; }
	
	public string ChineseName { get; set; }
	
	public uint Id { get; set; }
	
	public TimeSpan Cooldown { get; set; }
	
	public uint PowerCost1 { get; set; }
	
	public PowerType PowerCost1Type { get; set; }
	
	public uint PowerCost2 { get; set; }
	
	public PowerType PowerCost2Type { get; set; }
	
	public uint PowerGenerate1 { get; set; }
	
	public PowerType PowerGenerate1Type { get; set; }
	
	public uint PowerGenerate2 { get; set; }
	
	public PowerType PowerGenerate2Type { get; set; }
}