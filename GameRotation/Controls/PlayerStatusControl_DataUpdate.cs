using System.Windows.Media;
using ScreenReader;

namespace GameRotation.Controls;

public partial class PlayerStatusControl
{
	private static readonly Color PositiveColor = Colors.Green;
	private static readonly Color NegativeColor = Colors.Red;

	public void SetCurrentTime(uint currentTime)
	{
		DateTime currentDateTime = Functions.SystemStartTime + TimeSpan.FromMilliseconds(currentTime);
		CurrentTime = currentDateTime.ToString("HH:mm:ss");
		CurrentMillisecond = currentTime.ToString();
	}

	public void SetPlayerStatus(byte playerStatus)
	{
		bool[] playerStatusArray = Functions.ByteToBool(playerStatus);
		bool playerAlive = playerStatusArray[0];
		bool playerInCombat = playerStatusArray[1];
		bool playerMounted = playerStatusArray[2];
		bool playerInVehicle = playerStatusArray[3];
		bool playerJumping = playerStatusArray[4];
		bool playerMoving = playerStatusArray[5];
		bool playerCasting = playerStatusArray[6];
		bool playerChanneling = playerStatusArray[7];
		PlayerAliveColor = playerAlive ? PositiveColor : NegativeColor;
		PlayerInCombatColor = playerInCombat ? PositiveColor : NegativeColor;
		PlayerMountedColor = playerMounted ? PositiveColor : NegativeColor;
		PlayerInVehicleColor = playerInVehicle ? PositiveColor : NegativeColor;
		PlayerJumpingColor = playerJumping ? PositiveColor : NegativeColor;
		PlayerMovingColor = playerMoving ? PositiveColor : NegativeColor;
		PlayerIsCastingColor = playerCasting ? PositiveColor : NegativeColor;
		PlayerIsChannelingColor = playerChanneling ? PositiveColor : NegativeColor;
	}

	public void SetPlayerStatus(bool playerAlive, bool playerInCombat, bool playerMounted, bool playerInVehicle, bool playerJumping, bool playerMoving, bool playerCasting, bool playerChanneling)
	{
		PlayerAliveColor = playerAlive ? PositiveColor : NegativeColor;
		PlayerInCombatColor = playerInCombat ? PositiveColor : NegativeColor;
		PlayerMountedColor = playerMounted ? PositiveColor : NegativeColor;
		PlayerInVehicleColor = playerInVehicle ? PositiveColor : NegativeColor;
		PlayerJumpingColor = playerJumping ? PositiveColor : NegativeColor;
		PlayerMovingColor = playerMoving ? PositiveColor : NegativeColor;
		PlayerIsCastingColor = playerCasting ? PositiveColor : NegativeColor;
		PlayerIsChannelingColor = playerChanneling ? PositiveColor : NegativeColor;
	}

	public void SetPlayerHealth(uint currentHealth, uint maxHealth)
	{
		PlayerCurrentHealth = currentHealth.ToString();
		PlayerMaxHealth = maxHealth.ToString();
	}

	public void SetPlayerPower(uint currentPower, uint maxPower)
	{
		PlayerCurrentPower = currentPower.ToString();
		PlayerMaxPower = maxPower.ToString();
	}

	public void SetPlayerGlobalCooldown(uint globalCooldown)
	{
		PlayerGlobalCooldown = TimeSpan.FromMilliseconds(globalCooldown).ToString(@"ss\.fff");
	}

	public void SetPlayerCastTime(uint castTime)
	{
		DateTime castEndTime = Functions.SystemStartTime + TimeSpan.FromMilliseconds(castTime);
		TimeSpan castRemainingTime = castEndTime - DateTime.Now;
		PlayerCastEndTime = castEndTime.ToString("HH:mm:ss.fff");
		PlayerCastRemainingTime = castRemainingTime.ToString(@"ss\.fff");
	}

	private void UpdateFromPlayerStatus(PlayerStatus playerStatus)
	{
		SetCurrentTime(playerStatus.CurrentTick);
		SetPlayerStatus(playerStatus.PlayerAlive, playerStatus.PlayerInCombat, playerStatus.PlayerMounted, playerStatus.PlayerInVehicle, playerStatus.PlayerJumping, playerStatus.PlayerMoving, playerStatus.PlayerCasting, playerStatus.PlayerChanneling);
		SetPlayerHealth(playerStatus.PlayerHealth, playerStatus.PlayerMaxHealth);
		SetPlayerPower(playerStatus.PlayerPower, playerStatus.PlayerMaxPower);
		SetPlayerGlobalCooldown(playerStatus.PlayerRemainingGlobalCooldownTicks);
		SetPlayerCastTime(playerStatus.PlayerRemainingCastTicks);
	}

	public void DispatcherUpdateFromPlayerStatus(PlayerStatus playerStatus)
	{
		Dispatcher.BeginInvoke(() => UpdateFromPlayerStatus(playerStatus));
	}
}