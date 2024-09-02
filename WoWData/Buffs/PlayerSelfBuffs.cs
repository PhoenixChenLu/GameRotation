using WoWData.Entities;

namespace WoWData.Buffs;

public static partial class PlayerSelfBuffs
{
	public static List<Buff> GetPlayerBuffListBySpec(Specializations speciliazation)
	{
		return speciliazation switch
		{
			Specializations.Arcane_Mage => ArcaneMageSelfBuffList(),
			_ => new List<Buff>()
		};
	}
}