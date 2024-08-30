using System.Runtime.Serialization;

namespace WoWData;

public enum PowerType : int
{
	/// <summary>
	/// 生命值 
	/// </summary>
	[EnumMember(Value = "生命值")] HealthCost = -2,

	/// <summary>
	/// 无
	/// </summary>
	[EnumMember(Value = "无")] None = -1,

	/// <summary>
	/// 法力值
	/// </summary>
	[EnumMember(Value = "法力值")] Mana = 0,

	/// <summary>
	/// 怒气
	/// </summary>
	[EnumMember(Value = "怒气")] Rage = 1,

	/// <summary>
	/// 集中值
	/// </summary>
	[EnumMember(Value = "集中值")] Focus = 2,

	/// <summary>
	/// 能量
	/// </summary>
	[EnumMember(Value = "能量")] Energy = 3,

	/// <summary>
	/// 连击点
	/// </summary>
	[EnumMember(Value = "连击点")] ComboPoints = 4,

	/// <summary>
	/// 符文
	/// </summary>
	[EnumMember(Value = "符文")] Runes = 5,

	/// <summary>
	/// 符文能量
	/// </summary>
	[EnumMember(Value = "符文能量")] RunicPower = 6,

	/// <summary>
	/// 灵魂碎片
	/// </summary>
	[EnumMember(Value = "灵魂碎片")] SoulShards = 7,

	/// <summary>
	/// 月能
	/// </summary>
	[EnumMember(Value = "月能")] LunarPower = 8,

	/// <summary>
	/// 圣能
	/// </summary>
	[EnumMember(Value = "圣能")] HolyPower = 9,

	/// <summary>
	/// 替代能量
	/// </summary>
	[EnumMember(Value = "替代能量")] Alternate = 10,

	/// <summary>
	/// 漩涡值
	/// </summary>
	[EnumMember(Value = "漩涡值")] Maelstrom = 11,

	/// <summary>
	/// 真气
	/// </summary>
	[EnumMember(Value = "真气")] Chi = 12,

	/// <summary>
	/// 狂乱值
	/// </summary>
	[EnumMember(Value = "狂乱值")] Insanity = 13,

	/// <summary>
	/// 废弃
	/// </summary>
	[EnumMember(Value = "废弃")] Obsolete = 14,

	/// <summary>
	/// 废弃2
	/// </summary>
	[EnumMember(Value = "废弃2")] Obsolete2 = 15,

	/// <summary>
	/// 奥术充能
	/// </summary>
	[EnumMember(Value = "奥术充能")] ArcaneCharges = 16,

	/// <summary>
	/// 愤怒
	/// </summary>
	[EnumMember(Value = "愤怒")] Fury = 17,

	/// <summary>
	/// 痛苦
	/// </summary>
	[EnumMember(Value = "痛苦")] Pain = 18,

	/// <summary>
	/// 精华
	/// </summary>
	[EnumMember(Value = "精华")] Essence = 19,

	/// <summary>
	/// 鲜血符文
	/// </summary>
	[EnumMember(Value = "鲜血符文")] RuneBlood = 20,

	/// <summary>
	/// 冰霜符文
	/// </summary>
	[EnumMember(Value = "冰霜符文")] RuneFrost = 21,

	/// <summary>
	/// 邪恶符文
	/// </summary>
	[EnumMember(Value = "邪恶符文")] RuneUnholy = 22,

	/// <summary>
	/// 替代任务
	/// </summary>
	[EnumMember(Value = "替代任务")] AlternateQuest = 23,

	/// <summary>
	/// 替代遭遇
	/// </summary>
	[EnumMember(Value = "替代遭遇")] AlternateEncounter = 24,

	/// <summary>
	/// 替代坐骑
	/// </summary>
	[EnumMember(Value = "替代坐骑")] AlternateMount = 25,

	/// <summary>
	/// 能量种类数量
	/// </summary>
	[EnumMember(Value = "能量种类数量")] NumPowerTypes = 26
}

public static class PowerTypeExtensions
{
	public static PowerType AsPowerType(this int value)
	{
		return (PowerType)value;
	}
}