using WoWData.Entities;

namespace WoWData.Spells;

public static partial class PlayerSpells
{
	public static (List<Spell> allSpells, List<Spell> watchingSpells) GetPlayerSpellListBySpec(Specializations speciliazation)
	{
		List<Spell> allSpells = speciliazation switch
		{
			Specializations.Arcane_Mage => ArcaneMageSpells(),
			_ => new List<Spell>(),
		};

		List<Spell> watchingSpells = speciliazation switch
		{
			Specializations.Arcane_Mage => ArcaneWatchingSpells(allSpells),
			_ => new List<Spell>(),
		};

		return (allSpells, watchingSpells);
	}
}