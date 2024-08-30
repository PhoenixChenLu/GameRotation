namespace ScreenReader.Player;

public class PlayerStatus
{
	public uint CurrentTick { get; set; }

	public DateTime CurrentTime => Functions.SystemStartTime + TimeSpan.FromMilliseconds(CurrentTick);

	public bool PlayerAlive { get; set; }

	public bool PlayerInCombat { get; set; }

	public bool PlayerMounted { get; set; }

	public bool PlayerInVehicle { get; set; }

	public bool PlayerJumping { get; set; }

	public bool PlayerMoving { get; set; }

	public bool PlayerCasting { get; set; }

	public bool PlayerChanneling { get; set; }

	public uint PlayerHealth { get; set; }

	public uint PlayerMaxHealth { get; set; }

	public uint PlayerPower { get; set; }

	public uint PlayerMaxPower { get; set; }

	public uint PlayerRemainingGlobalCooldownTicks { get; set; }

	public TimeSpan PlayerRemainingGlobalCooldown => TimeSpan.FromMilliseconds(PlayerRemainingGlobalCooldownTicks);

	public uint PlayerRemainingCastTicks { get; set; }

	public DateTime PlayerCastEndTime => Functions.SystemStartTime + TimeSpan.FromMilliseconds(PlayerRemainingCastTicks);

	public uint PlayerRemainingChannelTicks { get; set; }

	public DateTime PlayerChannelEndTime => Functions.SystemStartTime + TimeSpan.FromMilliseconds(PlayerRemainingChannelTicks);
}