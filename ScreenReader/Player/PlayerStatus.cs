using WoWData.Entities;

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

	public double PlayerHealthPercentage => (double)PlayerHealth / (double)PlayerMaxHealth;

	public uint PlayerPower { get; set; }

	public uint PlayerMaxPower { get; set; }

	public double PlayerPowerPercentage => (double)PlayerPower / (double)PlayerMaxPower;

	public uint PlayerRemainingGlobalCooldownTicks { get; set; }

	public TimeSpan PlayerRemainingGlobalCooldown => TimeSpan.FromMilliseconds(PlayerRemainingGlobalCooldownTicks);

	public uint PlayerCastEndTick { get; set; }

	public uint PlayerRemainingCastTick => PlayerCastEndTick > CurrentTick ? PlayerCastEndTick - CurrentTick : 0;

	public DateTime PlayerCastEndTime => Functions.SystemStartTime + TimeSpan.FromMilliseconds(PlayerCastEndTick);

	public uint PlayerChannelEndTick { get; set; }

	public uint PlayerRemainingChannelTick => PlayerChannelEndTick > CurrentTick ? PlayerChannelEndTick - CurrentTick : 0;

	public DateTime PlayerChannelEndTime => Functions.SystemStartTime + TimeSpan.FromMilliseconds(PlayerChannelEndTick);

	public Specializations Specialization { get; set; }
}