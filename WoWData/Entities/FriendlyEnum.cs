using System.Runtime.Serialization;

namespace WoWData.Entities;

public enum FriendlyEnum : byte
{
	/// <summary>
	/// 均可
	/// </summary>
	[EnumMember(Value = "均可")] DoesNotMatter = 0,

	/// <summary>
	/// 友好
	/// </summary>
	[EnumMember(Value = "友好")] Friendly = 1,

	/// <summary>
	/// 敌对
	/// </summary>
	[EnumMember(Value = "敌对")] Hostile = 2,
}