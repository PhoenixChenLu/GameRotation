using System.Windows.Media;

namespace GameRotation.Controls;

public partial class PlayerStatusControl
{
	#region 当前时间

	private string _currentTime = "00:00:00";

	public string CurrentTime
	{
		get => _currentTime;
		set => SetField(ref _currentTime, value);
	}

	private string _currentMillisecond = "0";

	public string CurrentMillisecond
	{
		get => _currentMillisecond;
		set => SetField(ref _currentMillisecond, value);
	}

	#endregion

	#region 生命值和法力值

	private uint _playerCurrentHealthValue;

	public uint PlayerCurrentHealthValue
	{
		get => _playerCurrentHealthValue;
		set => SetField(ref _playerCurrentHealthValue, value);
	}

	private uint _playerMaxHealthValue;

	public uint PlayerMaxHealthValue
	{
		get => _playerMaxHealthValue;
		set => SetField(ref _playerMaxHealthValue, value);
	}

	private uint _playerCurrentPowerValue;

	public uint PlayerCurrentPowerValue
	{
		get => _playerCurrentPowerValue;
		set => SetField(ref _playerCurrentPowerValue, value);
	}

	private uint _playerMaxPowerValue;

	public uint PlayerMaxPowerValue
	{
		get => _playerMaxPowerValue;
		set => SetField(ref _playerMaxPowerValue, value);
	}

	private string _playerHealthInfoString = "0/0";

	public string PlayerHealthInfoString
	{
		get => _playerHealthInfoString;
		set => SetField(ref _playerHealthInfoString, value);
	}

	private string _playerHealthPercentageString = "0%";

	public string PlayerHealthPercentageString
	{
		get => _playerHealthPercentageString;
		set => SetField(ref _playerHealthPercentageString, value);
	}

	private string _playerPowerInfoString = "0/0";

	public string PlayerPowerInfoString
	{
		get => _playerPowerInfoString;
		set => SetField(ref _playerPowerInfoString, value);
	}

	private string _playerPowerPercentageString = "0%";

	public string PlayerPowerPercentageString
	{
		get => _playerPowerPercentageString;
		set => SetField(ref _playerPowerPercentageString, value);
	}

	#endregion

	#region 公共冷却

	private string _playerGlobalCooldownImageSource;

	public string PlayerGlobalCooldownImageSource
	{
		get => _playerGlobalCooldownImageSource;
		set => SetField(ref _playerGlobalCooldownImageSource, value);
	}

	public string _playerGlobalCooldownTimerText;

	public string PlayerGlobalCooldownTimerText
	{
		get => _playerGlobalCooldownTimerText;
		set => SetField(ref _playerGlobalCooldownTimerText, value);
	}

	#endregion

	#region 施法和引导剩余时间

	private string _playerIsCastingImageSource;

	public string PlayerIsCastingImageSource
	{
		get => _playerIsCastingImageSource;
		set => SetField(ref _playerIsCastingImageSource, value);
	}

	private string _playerCastingTimerText;

	public string PlayerCastingTimerText
	{
		get => _playerCastingTimerText;
		set => SetField(ref _playerCastingTimerText, value);
	}

	private string _playerIsChannelingImageSource;

	public string PlayerIsChannelingImageSource
	{
		get => _playerIsChannelingImageSource;
		set => SetField(ref _playerIsChannelingImageSource, value);
	}

	private string _playerChannelingTimerText;

	public string PlayerChannelingTimerText
	{
		get => _playerChannelingTimerText;
		set => SetField(ref _playerChannelingTimerText, value);
	}

	#endregion
}