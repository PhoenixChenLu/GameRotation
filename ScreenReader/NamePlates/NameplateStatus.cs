using WoWData.Entities;

namespace ScreenReader.NamePlates;

using WoWData.Buffs;

public class NameplateStatus
{
	public bool Exists { get; set; }

	public bool IsDead { get; set; }

	public bool CanAttack { get; set; }

	public bool IsInCombat { get; set; }

	public bool IsThreat { get; set; }

	public bool IsCasting { get; set; }

	public bool CanInterruptCast { get; set; }

	public bool IsChanneling { get; set; }

	public bool CanInterruptChannel { get; set; }

	public bool IsInterruptible { get; set; }

	public bool InMeleeRange { get; set; }

	public bool In6YardRange { get; set; }

	public bool In8YardRange { get; set; }

	public bool In10YardRange { get; set; }

	public bool In15YardRange { get; set; }

	public bool In20YardRange { get; set; }

	public bool In25YardRange { get; set; }

	public bool In30YardRange { get; set; }

	public bool In35YardRange { get; set; }

	public bool In40YardRange { get; set; }

	public bool In70YardRange { get; set; }

	public bool In80YardRange { get; set; }

	public bool In100YardRange { get; set; }

	public uint CurrentHealth { get; set; }

	public uint MaxHealth { get; set; }

	public List<Buff> PlayerDebuffs { get; set; } = new();

	public static NameplateStatus ArcaneMageNameplate()
	{
		return new NameplateStatus()
		{
			PlayerDebuffs = PlayerEnemyBuffs.ArcaneMageEnemyDebuffList(),
		};
	}

	public static NameplateStatus GenerateNameplateBySpec(Specializations spec)
	{
		switch (spec)
		{
			case Specializations.Arcane_Mage:
				return ArcaneMageNameplate();
			default:
				return new NameplateStatus();
		}
	}
}