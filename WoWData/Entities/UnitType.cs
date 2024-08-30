using System.Runtime.Serialization;

namespace WoWData.Entities;

public enum UnitType : int
{
	/// <summary>
	/// 玩家自己
	/// </summary>
	[EnumMember(Value = "玩家自己")] Self = -1,

	/// <summary>
	/// 玩家
	/// </summary>
	[EnumMember(Value = "玩家")] Player = 0,

	/// <summary>
	/// 目标
	/// </summary>
	[EnumMember(Value = "目标")] Target = 1,

	/// <summary>
	/// 焦点
	/// </summary>
	[EnumMember(Value = "焦点")] Focus = 2,

	/// <summary>
	/// 鼠标悬停
	/// </summary>
	[EnumMember(Value = "鼠标悬停")] Mouseover = 3,

	/// <summary>
	/// 首领1
	/// </summary>
	[EnumMember(Value = "首领1")] Boss1 = 4,

	/// <summary>
	/// 首领2
	/// </summary>
	[EnumMember(Value = "首领2")] Boss2 = 5,

	/// <summary>
	/// 首领3
	/// </summary>
	[EnumMember(Value = "首领3")] Boss3 = 6,

	/// <summary>
	/// 首领4
	/// </summary>
	[EnumMember(Value = "首领4")] Boss4 = 7,

	/// <summary>
	/// 首领5
	/// </summary>
	[EnumMember(Value = "首领5")] Boss5 = 8,

	/// <summary>
	/// 首领6
	/// </summary>
	[EnumMember(Value = "首领6")] Boss6 = 9,

	/// <summary>
	/// 首领7
	/// </summary>
	[EnumMember(Value = "首领7")] Boss7 = 10,

	/// <summary>
	/// 首领8
	/// </summary>
	[EnumMember(Value = "首领8")] Boss8 = 11,
}