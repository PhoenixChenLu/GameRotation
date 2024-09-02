namespace WoWData.Spells;

public static partial class PlayerSpells
{
	public static List<Spell> ArcaneMageSpells()
	{
		List<Spell> spells = new List<Spell>();
		spells.Add(ConeOfCold());
		spells.Add(FrostNova());
		spells.Add(BlastWave());
		spells.Add(Polymorph());
		spells.Add(ShiftingPower());
		spells.Add(ArcaneIntellect());
		spells.Add(ArcaneExplosion());
		spells.Add(IceBlock());
		spells.Add(FrostBolt());
		spells.Add(GravityLapse());
		spells.Add(GreaterInvisibility());
		spells.Add(AlterTime());
		spells.Add(TimeWarp());
		spells.Add(CounterSpell());
		spells.Add(SpellSteal());
		spells.Add(FireBlast());
		spells.Add(SlowFall());
		spells.Add(MassBarrier());
		spells.Add(MirrorImage());
		spells.Add(Shimmer());
		spells.Add(Displacement());
		spells.Add(Evocation());
		spells.Add(TouchOfTheMagi());
		spells.Add(ArcaneBlast());
		spells.Add(ChargedOrb());
		spells.Add(ArcaneBarrage());
		spells.Add(ArcaneSurge());
		spells.Add(ArcaneMissiles());
		spells.Add(PrismaticBarrier());
		return spells;
	}

	public static List<Spell> ArcaneWatchingSpells(List<Spell> allSpells)
	{
		List<int> watchingIds = new List<int>
		{
			120, 122, 157981, 382440, 12472, 449700, 110959, 342245, 80353, 2139,
			319836, 414660, 55342, 212653, 12051, 321507, 153626, 365350, 235450
		};

		return watchingIds.Select(id => allSpells.Single(spell => spell.Id == id)).ToList();
	}

	public static Spell ConeOfCold()
	{
		return new Spell()
		{
			Name = "Cone of Cold",
			ChineseName = "冰锥术",
			Id = 120,
			Cooldown = TimeSpan.FromSeconds(12),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 100000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell FrostNova()
	{
		return new Spell()
		{
			Name = "Frost Nova",
			ChineseName = "冰霜新星",
			Id = 122,
			Cooldown = TimeSpan.FromSeconds(30),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 50000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell BlastWave()
	{
		return new Spell()
		{
			Name = "Blast Wave",
			ChineseName = "冲击波",
			Id = 157981,
			Cooldown = TimeSpan.FromSeconds(30),
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell Polymorph()
	{
		return new Spell()
		{
			Name = "Polymorph",
			ChineseName = "变形术",
			Id = 118,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 100000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = false,
			RequiresCasting = true,
			RequiresChanneling = false,
		};
	}

	public static Spell ShiftingPower()
	{
		return new Spell()
		{
			Name = "Shifting Power",
			ChineseName = "变易幻能",
			Id = 382440,
			Cooldown = TimeSpan.FromSeconds(60),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 125000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = false,
			RequiresCasting = true,
			RequiresChanneling = false,
		};
	}

	public static Spell ArcaneIntellect()
	{
		return new Spell()
		{
			Name = "Arcane Intellect",
			ChineseName = "奥术智慧",
			Id = 1459,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 100000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = false,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell ArcaneExplosion()
	{
		return new Spell()
		{
			Name = "Arcane Explosion",
			ChineseName = "魔爆术",
			Id = 1449,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 250000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell IceBlock()
	{
		return new Spell()
		{
			Name = "Ice Block",
			ChineseName = "寒冰屏障",
			Id = 12472,
			Cooldown = TimeSpan.FromSeconds(240),
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell FrostBolt()
	{
		return new Spell()
		{
			Name = "Frost Bolt",
			ChineseName = "寒冰箭",
			Id = 116,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 50000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = false,
			RequiresCasting = true,
			RequiresChanneling = false,
		};
	}

	public static Spell GravityLapse()
	{
		return new Spell()
		{
			Name = "Gravity Lapse",
			ChineseName = "引力失效",
			Id = 449700,
			Cooldown = TimeSpan.FromSeconds(30),
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell GreaterInvisibility()
	{
		return new Spell()
		{
			Name = "Greater Invisibility",
			ChineseName = "强化隐形术",
			Id = 110959,
			Cooldown = TimeSpan.FromSeconds(120),
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell AlterTime()
	{
		return new Spell()
		{
			Name = "Alter Time",
			ChineseName = "操控时间",
			Id = 342245,
			Cooldown = TimeSpan.FromSeconds(45),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 25000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell TimeWarp()
	{
		return new Spell()
		{
			Name = "Time Warp",
			ChineseName = "时间扭曲",
			Id = 80353,
			Cooldown = TimeSpan.FromSeconds(300),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 100000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = false,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell CounterSpell()
	{
		return new Spell()
		{
			Name = "Counter Spell",
			ChineseName = "法术反制",
			Id = 2139,
			Cooldown = TimeSpan.FromSeconds(24),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 50000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = false,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
			CanBeCastWhileCasting = true,
		};
	}

	public static Spell SpellSteal()
	{
		return new Spell()
		{
			Name = "Spell Steal",
			ChineseName = "法术吸取",
			Id = 30449,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 173250 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell FireBlast()
	{
		return new Spell()
		{
			Name = "Fire Blast",
			ChineseName = "火焰冲击",
			Id = 319836,
			Cooldown = TimeSpan.FromSeconds(15),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 25000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell SlowFall()
	{
		return new Spell()
		{
			Name = "Slow Fall",
			ChineseName = "缓落术",
			Id = 130,
			Cooldown = TimeSpan.Zero,
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell MassBarrier()
	{
		return new Spell()
		{
			Name = "Mass Barrier",
			ChineseName = "群体屏障",
			Id = 414660,
			Cooldown = TimeSpan.FromSeconds(180),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 300000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell MirrorImage()
	{
		return new Spell()
		{
			Name = "Mirror Image",
			ChineseName = "镜像",
			Id = 55342,
			Cooldown = TimeSpan.FromSeconds(120),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 50000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell Shimmer()
	{
		return new Spell()
		{
			Name = "Shimmer",
			ChineseName = "闪光术",
			Id = 212653,
			Cooldown = TimeSpan.FromSeconds(21),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 50000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
			CanBeCastWhileCasting = true,
		};
	}

	public static Spell Displacement()
	{
		return new Spell()
		{
			Name = "Displacement",
			ChineseName = "闪回",
			Id = 1953,
			Cooldown = TimeSpan.FromSeconds(45),
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell Evocation()
	{
		return new Spell()
		{
			Name = "Evocation",
			ChineseName = "唤醒",
			Id = 12051,
			Cooldown = TimeSpan.FromSeconds(90),
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = true,
		};
	}

	public static Spell TouchOfTheMagi()
	{
		return new Spell()
		{
			Name = "Touch of the Magi",
			ChineseName = "魔法之触",
			Id = 321507,
			Cooldown = TimeSpan.FromSeconds(45),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 125000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = false,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell ArcaneBlast()
	{
		return new Spell()
		{
			Name = "Arcane Blast",
			ChineseName = "奥术冲击",
			Id = 30451,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 68750 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = false,
			RequiresCasting = true,
			RequiresChanneling = false,
		};
	}

	public static Spell ChargedOrb()
	{
		return new Spell()
		{
			Name = "Charged Orb",
			ChineseName = "奥术宝珠",
			Id = 153626,
			Cooldown = TimeSpan.FromSeconds(30),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 25000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = false,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell ArcaneBarrage()
	{
		return new Spell()
		{
			Name = "Arcane Barrage",
			ChineseName = "奥术弹幕",
			Id = 44425,
			Cooldown = TimeSpan.Zero,
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}

	public static Spell ArcaneSurge()
	{
		return new Spell()
		{
			Name = "Arcane Surge",
			ChineseName = "奥术涌动",
			Id = 365350,
			Cooldown = TimeSpan.FromSeconds(90),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = int.MaxValue },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = false,
			RequiresCasting = true,
			RequiresChanneling = false,
		};
	}

	public static Spell ArcaneMissiles()
	{
		return new Spell()
		{
			Name = "Arcane Missiles",
			ChineseName = "奥术飞弹",
			Id = 5143,
			Cooldown = TimeSpan.Zero,
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 375000 },
			RequiresTarget = true,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = true,
		};
	}

	public static Spell PrismaticBarrier()
	{
		return new Spell()
		{
			Name = "Prismatic Barrier",
			ChineseName = "棱光护体",
			Id = 235450,
			Cooldown = TimeSpan.FromSeconds(25),
			PowerCost1 = new PowerChange() { PowerType = PowerType.Mana, Value = 75000 },
			RequiresTarget = false,
			RequiresTargetArea = false,
			TriggerGlobalCooldown = true,
			CanBeCastWhileMoving = true,
			RequiresCasting = false,
			RequiresChanneling = false,
		};
	}
}