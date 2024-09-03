using GameRotation.Entities;
using WoWData.Buffs;
using WoWData.Spells;

namespace GameRotation.Controls;

public partial class Icon
{
	private void UpdateFromBuff(Buff buff)
	{
		SetIconName(buff.Id.ToString());
		if (buff.Exists)
		{
			SetCoolDown(buff.DontShowTime ? 0 : buff.RemainingTime);
			SwitchLight(true);
			if (buff.Stackable)
				SetStackCount(buff.CurrentStack);
		}
		else
		{
			CooldownTimerText = string.Empty;
			StackCountText = string.Empty;
			SwitchLight(false);
		}
	}

	public void DispatchUpdateFromBuff(Buff buff)
	{
		Dispatcher.Invoke(() => UpdateFromBuff(buff));
	}

	private void UpdateFromSpell(Spell spell)
	{
		SetIconName(spell.Id.ToString());
		SwitchLight(spell.CooldownRemaining == 0);
		SetCoolDown(spell.CooldownRemaining);
	}
	
	public void DispatchUpdateFromSpell(Spell spell)
	{
		Dispatcher.Invoke(() => UpdateFromSpell(spell));
	}

	private void UpdateFromSpellKeyBinding(Spell spell)
	{
		SetIconName(spell.Id.ToString());
		SwitchLight(true);
		StackCountText = spell.KeyBinding.ToString();
	}
	
	public void DispatchUpdateFromSpellKeyBinding(Spell spell)
	{
		Dispatcher.Invoke(() => UpdateFromSpellKeyBinding(spell));
	}

	public void SetIconName(string iconName)
	{
		_imageFileName = iconName;
		SwitchLight(true);
	}

	private void SetCoolDown(DateTime endTime)
	{
		TimeSpan remainingTime = endTime - DateTime.Now;
		if (remainingTime < TimeSpan.Zero)
		{
			CooldownTimerText = string.Empty;
		}
		else
		{
			CooldownTimerText = remainingTime < TimeSpan.FromMinutes(1) ? remainingTime.TotalSeconds.ToString("F1") : remainingTime.TotalMinutes.ToString("F2") + "m";
		}
	}

	public void DispatchSetCoolDown(DateTime endTime)
	{
		Dispatcher.Invoke(() => SetCoolDown(endTime));
	}

	private void SetCoolDown(uint coolDown)
	{
		if (coolDown > 0)
			CooldownTimerText = coolDown < 60000 ? ((double)coolDown / 1000.0).ToString("F1") : TimeSpan.FromMilliseconds(coolDown).TotalMinutes.ToString("F2") + "m";
		else
			CooldownTimerText = string.Empty;
	}

	public void DispatchSetCoolDown(uint coolDown)
	{
		Dispatcher.Invoke(() => SetCoolDown(coolDown));
	}

	private void SetStackCount(int stackCount)
	{
		StackCountText = stackCount > 1 ? stackCount.ToString() : string.Empty;
	}

	public void DispatchSetStackCount(int stackCount)
	{
		Dispatcher.Invoke(() => SetStackCount(stackCount));
	}

	private void SwitchLight(bool isOn)
	{
		if (_imageFileName is null) return;
		ImageSource = isOn ? Extensions.IconFolderPath + _imageFileName + ".jpg" : Extensions.IconFolderPath + _imageFileName + "_bw.jpg";
	}

	public void DispatchSwitchLight(bool isOn)
	{
		Dispatcher.Invoke(() => SwitchLight(isOn));
	}
}