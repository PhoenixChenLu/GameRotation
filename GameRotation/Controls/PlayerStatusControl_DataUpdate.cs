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

	private void SetPlayerStatus(bool playerAlive, bool playerInCombat, bool playerMounted, bool playerInVehicle, bool playerJumping, bool playerMoving, bool playerCasting, bool playerChanneling)
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

	private void SetPlayerHealth(uint currentHealth, uint maxHealth)
	{
		PlayerHealthInfoString = $"{currentHealth}/{maxHealth}";
		PlayerHealthPercentageString = $"{(double)currentHealth / (double)maxHealth:P}";
		PlayerCurrentHealthValue = currentHealth;
		PlayerMaxHealthValue = maxHealth;
	}

	private void SetPlayerPower(uint currentPower, uint maxPower)
	{
		PlayerPowerInfoString = $"{currentPower}/{maxPower}";
		PlayerPowerPercentageString = $"{(double)currentPower / (double)maxPower:P}";
		PlayerCurrentPowerValue = currentPower;
		PlayerMaxPowerValue = maxPower;
	}

	private void SetPlayerGlobalCooldown(uint globalCooldown)
	{
		GlobalCooldownIcon.DispatchSwitchLight(globalCooldown > 0);
		GlobalCooldownIcon.DispatchSetCoolDown(globalCooldown);
	}


	private void SetPlayerCastTime(PlayerStatus status)
	{
		CastingIcon.DispatchSwitchLight(status.PlayerCasting);
		CastingIcon.DispatchSetCoolDown(status.PlayerCasting ? status.PlayerRemainingCastTick : 0);
	}

	private void SetPlayerChannelTime(PlayerStatus status)
	{
		ChannelingIcon.DispatchSwitchLight(status.PlayerChanneling);
		ChannelingIcon.DispatchSetCoolDown(status.PlayerChanneling ? status.PlayerRemainingChannelTick : 0);
	}

	private void SetPlayerBuffs(PlayerStatus status)
	{
		for (int i = 0; i < status.PlayerBuffList.Count; i++)
		{
			PlayerBuffIcons[i].DispatchUpdateFromBuff(status.PlayerBuffList[i]);
		}
	}

	private void SetPlayerSpells(PlayerStatus status)
	{
		for (int i = 0; i < status.PlayerWatchedSpellList.Count; i++)
		{
			PlayerSpellIcons[i].DispatchUpdateFromSpell(status.PlayerWatchedSpellList[i]);
		}
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
		SetPlayerBuffs(playerStatus);
		SetPlayerSpells(playerStatus);
		SetPlayerSpells(playerStatus);
	}

	public void DispatcherUpdateFromPlayerStatus(PlayerStatus playerStatus)
	{
		Dispatcher.BeginInvoke(() => UpdateFromPlayerStatus(playerStatus));
	}
}