using System.Drawing;
using KeyboardHook;

namespace WoWData.Spells;

public class Spell
{
	public string Name { get; set; }

	public string ChineseName { get; set; }

	public uint Id { get; set; }

	public TimeSpan Cooldown { get; set; }

	public PowerChange PowerCost1 { get; set; }

	public PowerChange PowerCost2 { get; set; }

	public PowerChange PowerGenerate1 { get; set; }

	public PowerChange PowerGenerate2 { get; set; }

	public bool RequiresTarget { get; set; }

	public bool RequiresTargetArea { get; set; }

	public bool TriggerGlobalCooldown { get; set; }

	public bool RequiresCasting { get; set; }

	public bool RequiresChanneling { get; set; }

	public bool CanBeCastWhileMoving { get; set; }

	public bool CanBeCastWhileCasting { get; set; }

	public bool CanBeCastWhileStunned { get; set; }

	public uint CooldownRemaining { get; set; }

	public void UpdateFromColor(Color color)
	{
		CooldownRemaining = (uint)color.R << 16 | (uint)color.G << 8 | color.B;
	}

	public KeyBinding KeyBinding { get; set; }
}