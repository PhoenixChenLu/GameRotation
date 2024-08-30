using WoWData.Entities;

namespace WoWData.Buffs;

public static partial class PlayerSelfBuffs
{
	public static Buff ArcaneIntellect()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 1459,
			Name = "Arcane Intellect",
			ChineseName = "奥术智慧",
			Description = "提高智力",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ArcaneFamiliar()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 210126,
			Name = "Arcane Familiar",
			ChineseName = "奥术魔宠",
			Description = "奥术魔宠召唤buff，使法力值上限提高10%，持续1小时",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}
	
	public static Buff SpellFireSpheres_Generating()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 449400,
			Name = "Spellfire Spheres",
			ChineseName = "法术火焰宝珠",
			Description = "法术火焰宝珠正在积聚，满6层后会生成一个法术火焰宝珠",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}
	
	public static Buff SpellFireSpheres_Generated()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 448604,
			Name = "Spellfire Spheres",
			ChineseName = "法术火焰宝珠",
			Description = "已经生成的法术火焰宝珠，提供伤害加成，并且共给奥术凤凰消耗",
			Stackable = true,
			MaxStack = 3,
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff BurdenOfPower()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 451049,
			Name = "Burden of Power",
			ChineseName = "力量的重担",
			Description = "下一个奥术冲击或者奥术弹幕的伤害提高30%",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ArcaneHarmony()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 384455,
			Name = "Arcane Harmony",
			ChineseName = "奥术祥和",
			Description = "奥术飞弹每次命中敌人后，都会使下一个奥术弹幕的伤害提高5%，最多叠加20次",
			CurrentStack = 0,
			Stackable = true,
			MaxStack = 20,
			EndDateTime = DateTime.MinValue
		};
	}
	
	public static Buff IncantersFlow()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 116267,
			Name = "Incanter's Flow",
			ChineseName = "咒术洪流",
			Description = "战斗时每层提高2%的法术伤害，最多叠加5次",
			CurrentStack = 0,
			Stackable = true,
			MaxStack = 5,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ManaCascade()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 449322,
			Name = "Mana Cascade",
			ChineseName = "法力涌流",
			Description = "奥冲或奥术弹幕每层使急速提高1%,持续10秒，最多叠加10次",
			CurrentStack = 0,
			Stackable = true,
			MaxStack = 10,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ArcaneTempo()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 383997,
			Name = "Arcane Tempo",
			ChineseName = "奥术迅疾",
			Description = "每次施放奥术弹幕都会使急速提高2%，最多叠加5次",
			CurrentStack = 0,
			Stackable = true,
			MaxStack = 5,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff AetherAttunement_Generating()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 458388,
			Name = "Aether Attunement",
			ChineseName = "以太调谐",
			Description = "每三次释放奥术飞弹，下一个奥术飞弹的伤害翻倍且变为AOE",
			CurrentStack = 0,
			Stackable = true,
			MaxStack = 2,
			EndDateTime = DateTime.MinValue
		};
	}
	
	public static Buff AetherAttunement_Generated()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 453601,
			Name = "Aether Attunement",
			ChineseName = "以太调谐",
			Description = "已经生成的以太调谐，下一个奥术飞弹的伤害翻倍且变为AOE",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}
	
	public static Buff GloriousIncandescence()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 451073,
			Name = "Glorious Incandescence",
			ChineseName = "白炽耀焰",
			Description = "消耗力量的重担之后，下一个奥术弹幕会召唤流星并产生4层奥术充能",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff BigBrained()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 461531,
			Name = "Big-Brained",
			ChineseName = "清晰头脑",
			Description = "获得节能施法使智力提高1%，持续8秒，可叠加",
			CurrentStack = 0,
			Stackable = true,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ClearCasting()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 263725,
			Name = "Clear Casting",
			ChineseName = "节能施法",
			Description = "下一个奥术飞弹和奥爆的法力消耗减少100%",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff NetherPrecision()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 383783,
			Name = "Nether Precision",
			ChineseName = "虚空精准",
			Description = "施放奥术飞弹之后下两个奥冲和奥术弹幕的伤害提高",
			CurrentStack = 0,
			Stackable = true,
			MaxStack = 2,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff SiphonStorm()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 384267,
			Name = "Siphon Storm",
			ChineseName = "风暴虹吸",
			Description = "施放唤醒之后获得，每层使智力提高2%",
			CurrentStack = 0,
			Stackable = true,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ArcaneSurge()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 365362,
			Name = "Arcane Surge",
			ChineseName = "奥术涌动",
			Description = "魔法恢复速大幅度度提高，法伤提高",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}

	public static Buff ArcanePhoenix()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 448659,
			Name = "Arcane Phoenix",
			ChineseName = "奥术凤凰",
			Description = "和奥术涌动同步，消耗火焰宝珠施放特殊法术",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}
	
	public static Buff ArcaneSoul()
	{
		return new Buff()
		{
			FromType = UnitType.Self,
			ToType = UnitType.Self,
			Id = 451038,
			Name = "Arcane Soul",
			ChineseName = "奥术之魂",
			Description = "凤凰结束之后持续3秒，凤凰每施放过一个特殊法术延长0.5秒，期间奥术弹幕产生节能施法和4个充能",
			CurrentStack = 0,
			EndDateTime = DateTime.MinValue
		};
	}
}