using System.Windows.Media;
using ScreenReader;
using ScreenReader.Player;

namespace GameRotation.Controls;

public partial class PlayerStatusControl
{
	public void SetCurrentTime(uint currentTime)
	{
		DateTime currentDateTime = Functions.SystemStartTime + TimeSpan.FromMilliseconds(currentTime);
		CurrentTime = currentDateTime.ToString("HH:mm:ss");
		CurrentMillisecond = currentTime.ToString();
	}

	public void SetPlayerStatus(bool playerAlive, bool playerInCombat, bool playerMounted, bool playerInVehicle, bool playerJumping, bool playerMoving, bool playerCasting, bool playerChanneling)
	{
		AliveIcon.DispatchSwitchLight(playerAlive);
		InCombatIcon.DispatchSwitchLight(playerInCombat);
		MountedIcon.DispatchSwitchLight(playerMounted);
		InVehicleIcon.DispatchSwitchLight(playerInVehicle);
		JumpingIcon.DispatchSwitchLight(playerJumping);
		MovingIcon.DispatchSwitchLight(playerMoving);
		CastingIcon.DispatchSwitchLight(playerCasting);
		ChannelingIcon.DispatchSwitchLight(playerChanneling);
	}

	public void SetPlayerHealth(uint currentHealth, uint maxHealth)
	{
		PlayerHealthInfoString = $"{currentHealth}/{maxHealth}";
		PlayerHealthPercentageString = $"{(double)currentHealth / (double)maxHealth:P}";
		PlayerCurrentHealthValue = currentHealth;
		PlayerMaxHealthValue = maxHealth;
	}

	public void SetPlayerPower(uint currentPower, uint maxPower)
	{
		PlayerPowerInfoString = $"{currentPower}/{maxPower}";
		PlayerPowerPercentageString = $"{(double)currentPower / (double)maxPower:P}";
		PlayerCurrentPowerValue = currentPower;
		PlayerMaxPowerValue = maxPower;
	}

	public void SetPlayerGlobalCooldown(uint globalCooldown)
	{
		GlobalCooldownIcon.DispatchSwitchLight(globalCooldown > 0);
		GlobalCooldownIcon.DispatchSetCoolDown(globalCooldown);
	}


	public void SetPlayerCastTime(PlayerStatus status)
	{
		CastingIcon.DispatchSwitchLight(status.PlayerCasting);
		CastingIcon.DispatchSetCoolDown(status.PlayerCasting ? status.PlayerRemainingCastTick : 0);
	}

	public void SetPlayerChannelTime(PlayerStatus status)
	{
		ChannelingIcon.DispatchSwitchLight(status.PlayerChanneling);
		ChannelingIcon.DispatchSetCoolDown(status.PlayerChanneling ? status.PlayerRemainingChannelTick : 0);
	}

	private void UpdateFromPlayerStatus(PlayerStatus playerStatus)
	{
		SetCurrentTime(playerStatus.CurrentTick);
		SetPlayerStatus(playerStatus.PlayerAlive, playerStatus.PlayerInCombat, playerStatus.PlayerMounted, playerStatus.PlayerInVehicle, playerStatus.PlayerJumping, playerStatus.PlayerMoving, playerStatus.PlayerCasting, playerStatus.PlayerChanneling);
		SetPlayerHealth(playerStatus.PlayerHealth, playerStatus.PlayerMaxHealth);
		SetPlayerPower(playerStatus.PlayerPower, playerStatus.PlayerMaxPower);
		SetPlayerGlobalCooldown(playerStatus.PlayerRemainingGlobalCooldownTicks);
		SetPlayerCastTime(playerStatus);
		SetPlayerChannelTime(playerStatus);
	}

	public void DispatcherUpdateFromPlayerStatus(PlayerStatus playerStatus)
	{
		Dispatcher.BeginInvoke(() => UpdateFromPlayerStatus(playerStatus));
	}
}