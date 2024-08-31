using System.Runtime.Serialization;

namespace WoWData.Entities;

public enum Class : byte
{
	/// <summary>
	/// 战士 
	/// </summary>
	[EnumMember(Value = "战士")] Warrior = 1,

	/// <summary>
	/// 圣骑士
	/// </summary>
	[EnumMember(Value = "圣骑士")] Paladin = 2,

	/// <summary>
	/// 猎人
	/// </summary>
	[EnumMember(Value = "猎人")] Hunter = 3,

	/// <summary>
	/// 盗贼
	/// </summary>
	[EnumMember(Value = "盗贼")] Rogue = 4,

	/// <summary>
	/// 牧师
	/// </summary>
	[EnumMember(Value = "牧师")] Priest = 5,

	/// <summary>
	/// 死亡骑士
	/// </summary>
	[EnumMember(Value = "死亡骑士")] DeathKnight = 6,

	/// <summary>
	/// 萨满祭司
	/// </summary>
	[EnumMember(Value = "萨满祭司")] Shaman = 7,

	/// <summary>
	/// 法师
	/// </summary>
	[EnumMember(Value = "法师")] Mage = 8,

	/// <summary>
	/// 术士
	/// </summary>
	[EnumMember(Value = "术士")] Warlock = 9,

	/// <summary>
	/// 武僧
	/// </summary>
	[EnumMember(Value = "武僧")] Monk = 10,

	/// <summary>
	/// 德鲁伊
	/// </summary>
	[EnumMember(Value = "德鲁伊")] Druid = 11,

	/// <summary>
	/// 恶魔猎手
	/// </summary>
	[EnumMember(Value = "恶魔猎手")] DemonHunter = 12,

	/// <summary>
	/// 唤魔师
	/// </summary>
	[EnumMember(Value = "唤魔师")] Evoker = 13,
}

public static class ClassExtensions
{
	public static string ToChinese(this Class @class)
	{
		return @class switch
		{
			Class.Warrior => "战士",
			Class.Paladin => "圣骑士",
			Class.Hunter => "猎人",
			Class.Rogue => "盗贼",
			Class.Priest => "牧师",
			Class.DeathKnight => "死亡骑士",
			Class.Shaman => "萨满祭司",
			Class.Mage => "法师",
			Class.Warlock => "术士",
			Class.Monk => "武僧",
			Class.Druid => "德鲁伊",
			Class.DemonHunter => "恶魔猎手",
			Class.Evoker => "唤魔师",
			_ => throw new ArgumentOutOfRangeException(nameof(@class), @class, null),
		};
	}

	public static Class FromChinese(string chinese)
	{
		return chinese switch
		{
			"战士" => Class.Warrior,
			"圣骑士" => Class.Paladin,
			"猎人" => Class.Hunter,
			"盗贼" => Class.Rogue,
			"牧师" => Class.Priest,
			"死亡骑士" => Class.DeathKnight,
			"萨满祭司" => Class.Shaman,
			"法师" => Class.Mage,
			"术士" => Class.Warlock,
			"武僧" => Class.Monk,
			"德鲁伊" => Class.Druid,
			"恶魔猎手" => Class.DemonHunter,
			"唤魔师" => Class.Evoker,
			_ => throw new ArgumentOutOfRangeException(nameof(chinese), chinese, null),
		};
	}

	public static Class AsClass(this byte value)
	{
		return (Class)value;
	}

	public static Class AsClass(this int value)
	{
		return (Class)value;
	}
}