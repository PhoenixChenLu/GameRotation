using WoWData.Entities;

namespace WoWData.Buffs;

public static partial class PlayerEnemyBuffs
{
	public static List<Buff> ArcaneMageEnemyDebuffList()
	{
		List<Buff> debuffList = new();
		debuffList.Add(GravityLapse());
		debuffList.Add(TouchOfTheMagi());
		debuffList.Add(MagisSpark());
		debuffList.Add(ArcaneDebilitation());
		return debuffList;
	}

	public static Buff Polymorph()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 118,
			Name = "Polymorph",
			ChineseName = "变形术",
			Description = "变形术",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff FrostNova()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 122,
			Name = "Frost Nova",
			ChineseName = "冰霜新星",
			Description = "无法移动",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ConeOfCold()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 212792,
			Name = "Cone of Cold",
			ChineseName = "冰锥术",
			Description = "减速",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff GravityLapse()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 449700,
			Name = "Gravity Lapse",
			ChineseName = "引力失效",
			Description = "引力失效",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff TouchOfTheMagi()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 210824,
			Name = "Touch of the Magi",
			ChineseName = "大法师之触",
			Description = "大法师之触",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff MagisSpark()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 453912,
			Name = "Magi's Sparks",
			ChineseName = "大法师的火花",
			Description = "大法师的火花",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ArcaneDebilitation()
	{
		return new Buff()
		{
			FromType = UnitType.Player,
			ToType = UnitType.Enemy,
			Id = 31589,
			Name = "Arcane Debilitation",
			ChineseName = "奥术衰竭",
			Description = "奥弹命中时产生，每层都能提高奥术飞弹、奥术冲击和奥术弹幕对目标造成的伤害",
			Stackable = true,
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}
}