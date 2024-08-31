namespace WoWData.Entities;

public static class SpecializationDict
{
	public static Specializations[][] ClassSpecializations = new Specializations[][]
	{
		new Specializations[] { Specializations.Protection_Warrior, Specializations.Fury_Warrior, Specializations.Arms_Warrior },
		new Specializations[] { Specializations.Holy_Paladin, Specializations.Protection_Paladin, Specializations.Retribution_Paladin },
		new Specializations[] { Specializations.BeastMastery_Hunter, Specializations.Marksmanship_Hunter, Specializations.Survival_Hunter },
		new Specializations[] { Specializations.Assassination_Rogue, Specializations.Outlaw_Rogue, Specializations.Subtlety_Rogue },
		new Specializations[] { Specializations.Discipline_Priest, Specializations.Holy_Priest, Specializations.Shadow_Priest },
		new Specializations[] { Specializations.Blood_DeathKnight, Specializations.Frost_DeathKnight, Specializations.Unholy_DeathKnight },
		new Specializations[] { Specializations.Elemental_Shaman, Specializations.Enhancement_Shaman, Specializations.Restoration_Shaman },
		new Specializations[] { Specializations.Arcane_Mage, Specializations.Fire_Mage, Specializations.Frost_Mage },
		new Specializations[] { Specializations.Affliction_Warlock, Specializations.Demonology_Warlock, Specializations.Destruction_Warlock },
		new Specializations[] { Specializations.Brewmaster_Monk, Specializations.Mistweaver_Monk, Specializations.Windwalker_Monk },
		new Specializations[] { Specializations.Balance_Druid, Specializations.Feral_Druid, Specializations.Guardian_Druid, Specializations.Restoration_Druid },
		new Specializations[] { Specializations.Havoc_DemonHunter, Specializations.Vengeance_DemonHunter },
		new Specializations[] { Specializations.Augmentation_Evoker, Specializations.Preservation_Evoker, Specializations.Devastation_Evoker }
	};

	public static Specializations GetSpecialization(Class @class, byte index)
	{
		try
		{
			return ClassSpecializations[(byte)@class - 1][index - 1];
		}
		catch
		{
			return Specializations.Arcane_Mage;
		}
	}

	public static Specializations GetSpecialization(byte classIndex, byte index)
	{
		return ClassSpecializations[classIndex - 1][index - 1];
	}
}