using ScreenReader.NamePlates;
using ScreenReader.Player;

namespace GameRotation.Controls;

public partial class SingleNamePlateControl
{
	private void InitializeStatusIcons()
	{
		ExistIcon.SetIconName("exists");
		AliveIcon.SetIconName("alive");
		CanAttackIcon.SetIconName("canattack");
		InCombatIcon.SetIconName("combat");
		ThreatIcon.SetIconName("threat");
		CastingIcon.SetIconName("casting");
		ChannelingIcon.SetIconName("channeling");
		CanInterruptIcon.SetIconName("caninterrupt");
	}

	private void UpdateFromNameplate(NameplateStatus status)
	{
		if (!status.Exists)
		{
			SetNotExist();
			return;
		}

		ExistIcon.DispatchSwitchLight(true);
		AliveIcon.DispatchSwitchLight(!status.IsDead);
		CanAttackIcon.DispatchSwitchLight(status.CanAttack);
		InCombatIcon.DispatchSwitchLight(status.IsInCombat);
		ThreatIcon.DispatchSwitchLight(status.IsThreat);
		CastingIcon.DispatchSwitchLight(status.IsCasting);
		ChannelingIcon.DispatchSwitchLight(status.IsChanneling);
		CanInterruptIcon.DispatchSwitchLight(status.IsInterruptible);

		HealthBar.Maximum = status.MaxHealth;
		HealthBar.Value = (int)status.CurrentHealth;

		HealthText.Text = status.CurrentHealth.ToChineseString() + $"-{status.HealthPercentage:P2}";

		DistanceBar.Value = status.InMeleeRange ? 1 : status.In6YardRange ? 2 : status.In8YardRange ? 3 : status.In10YardRange ? 3 : status.In15YardRange ? 4 : status.In20YardRange ? 5 : status.In25YardRange ? 6 : status.In30YardRange ? 7 : status.In35YardRange ? 8 : status.In40YardRange ? 9 : status.In70YardRange ? 10 : status.In80YardRange ? 11 : status.In100YardRange ? 12 : 13;

		DistanceText.Text = status.InMeleeRange ? "<=5" : status.In6YardRange ? "5-6" : status.In8YardRange ? "6-8" : status.In10YardRange ? "8-10" : status.In15YardRange ? "10-15" : status.In20YardRange ? "15-20" : status.In25YardRange ? "20-25" : status.In30YardRange ? "25-30" : status.In35YardRange ? "30-35" : status.In40YardRange ? "35-40" : status.In70YardRange ? "40-70" : status.In80YardRange ? "70-80" : status.In100YardRange ? "80-100" : ">100";

		for (int i = 0; i < status.PlayerDebuffs.Count; i++)
		{
			DebuffIcons[i].SetIconName(status.PlayerDebuffs[i].Id.ToString());
			DebuffIcons[i].DispatchSwitchLight(status.PlayerDebuffs[i].Exists);
			DebuffIcons[i].DispatchSetCoolDown(status.PlayerDebuffs[i].RemainingTime);
			DebuffIcons[i].DispatchSetStackCount(status.PlayerDebuffs[i].Stackable ? status.PlayerDebuffs[i].CurrentStack : 0);
		}
	}

	public void DispatchUpdateFromNameplate(NameplateStatus status)
	{
		Dispatcher.Invoke(() => UpdateFromNameplate(status));
	}

	private void SetNotExist()
	{
		ExistIcon.DispatchSwitchLight(false);
		AliveIcon.DispatchSwitchLight(false);
		CanAttackIcon.DispatchSwitchLight(false);
		InCombatIcon.DispatchSwitchLight(false);
		ThreatIcon.DispatchSwitchLight(false);
		CastingIcon.DispatchSwitchLight(false);
		ChannelingIcon.DispatchSwitchLight(false);
		CanInterruptIcon.DispatchSwitchLight(false);

		foreach (var icon in DebuffIcons)
		{
			icon.DispatchSwitchLight(false);
			icon.DispatchSetCoolDown(0);
			icon.DispatchSetStackCount(0);
		}
	}
}