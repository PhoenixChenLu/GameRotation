using System.Runtime.Serialization;

namespace WoWData.Entities;

public class UnitType
{
	public FriendlyEnum FriendlyType { get; set; }

	public PlayerEnum PlayerType { get; set; }

	/// <summary>
	/// 敌方玩家
	/// </summary>
	public static UnitType EnemyPlayer = new UnitType()
	{
		FriendlyType = FriendlyEnum.Hostile,
		PlayerType = PlayerEnum.PlayerExceptSelf,
	};
	
	public static UnitType Self = new UnitType()
	{
		FriendlyType = FriendlyEnum.Friendly,
		PlayerType = PlayerEnum.PlayerSelf,
	};
	
	public static UnitType Player = new UnitType()
	{
		FriendlyType = FriendlyEnum.DoesNotMatter,
		PlayerType = PlayerEnum.Player,
	};
	
	public static UnitType Enemy = new UnitType()
	{
		FriendlyType = FriendlyEnum.Hostile,
		PlayerType = PlayerEnum.DoesNotMatter,
	};
	
	public static UnitType EnemyNPC = new UnitType()
	{
		FriendlyType = FriendlyEnum.Hostile,
		PlayerType = PlayerEnum.NPC,
	};
	
	public static UnitType Empty = new UnitType()
	{
		FriendlyType = FriendlyEnum.DoesNotMatter,
		PlayerType = PlayerEnum.DoesNotMatter,
	};
}