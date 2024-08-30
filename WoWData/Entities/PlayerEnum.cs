using System.Runtime.Serialization;

namespace WoWData.Entities;

public enum PlayerEnum : byte
{
	/// <summary>
	/// 均可
	/// </summary>
	[EnumMember(Value = "均可")] DoesNotMatter = 0,

	/// <summary>
	/// 玩家
	/// </summary>
	[EnumMember(Value = "玩家")] Player = 1,

	/// <summary>
	/// NPC
	/// </summary>
	[EnumMember(Value = "NPC")] NPC = 2,

	/// <summary>
	/// 玩家自己
	/// </summary>
	[EnumMember(Value = "玩家自己")] PlayerSelf = 3,

	/// <summary>
	/// 除玩家自己外
	/// </summary>
	[EnumMember(Value = "除玩家自己外")] PlayerExceptSelf = 4,
}