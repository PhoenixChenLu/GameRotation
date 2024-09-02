using System.Windows.Media;
using WoWData.Buffs;

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

	#region 玩家Buff图标

	private Icon[] PlayerBuffIcons = new Icon[30];

	private void InitializePlayerBuffIcons()
	{
		PlayerBuffIcons[0] = BuffIcon1;
		PlayerBuffIcons[1] = BuffIcon2;
		PlayerBuffIcons[2] = BuffIcon3;
		PlayerBuffIcons[3] = BuffIcon4;
		PlayerBuffIcons[4] = BuffIcon5;
		PlayerBuffIcons[5] = BuffIcon6;
		PlayerBuffIcons[6] = BuffIcon7;
		PlayerBuffIcons[7] = BuffIcon8;
		PlayerBuffIcons[8] = BuffIcon9;
		PlayerBuffIcons[9] = BuffIcon10;
		PlayerBuffIcons[10] = BuffIcon11;
		PlayerBuffIcons[11] = BuffIcon12;
		PlayerBuffIcons[12] = BuffIcon13;
		PlayerBuffIcons[13] = BuffIcon14;
		PlayerBuffIcons[14] = BuffIcon15;
		PlayerBuffIcons[15] = BuffIcon16;
		PlayerBuffIcons[16] = BuffIcon17;
		PlayerBuffIcons[17] = BuffIcon18;
		PlayerBuffIcons[18] = BuffIcon19;
		PlayerBuffIcons[19] = BuffIcon20;
		PlayerBuffIcons[20] = BuffIcon21;
		PlayerBuffIcons[21] = BuffIcon22;
		PlayerBuffIcons[22] = BuffIcon23;
		PlayerBuffIcons[23] = BuffIcon24;
		PlayerBuffIcons[24] = BuffIcon25;
		PlayerBuffIcons[25] = BuffIcon26;
		PlayerBuffIcons[26] = BuffIcon27;
		PlayerBuffIcons[27] = BuffIcon28;
		PlayerBuffIcons[28] = BuffIcon29;
		PlayerBuffIcons[29] = BuffIcon30;
	}

	private Icon[] PlayerSpellIcons = new Icon[30];

	private void InitializePlayerSpellIcons()
	{
		PlayerSpellIcons[0] = PlayerSpellIcon1;
		PlayerSpellIcons[1] = PlayerSpellIcon2;
		PlayerSpellIcons[2] = PlayerSpellIcon3;
		PlayerSpellIcons[3] = PlayerSpellIcon4;
		PlayerSpellIcons[4] = PlayerSpellIcon5;
		PlayerSpellIcons[5] = PlayerSpellIcon6;
		PlayerSpellIcons[6] = PlayerSpellIcon7;
		PlayerSpellIcons[7] = PlayerSpellIcon8;
		PlayerSpellIcons[8] = PlayerSpellIcon9;
		PlayerSpellIcons[9] = PlayerSpellIcon10;
		PlayerSpellIcons[10] = PlayerSpellIcon11;
		PlayerSpellIcons[11] = PlayerSpellIcon12;
		PlayerSpellIcons[12] = PlayerSpellIcon13;
		PlayerSpellIcons[13] = PlayerSpellIcon14;
		PlayerSpellIcons[14] = PlayerSpellIcon15;
		PlayerSpellIcons[15] = PlayerSpellIcon16;
		PlayerSpellIcons[16] = PlayerSpellIcon17;
		PlayerSpellIcons[17] = PlayerSpellIcon18;
		PlayerSpellIcons[18] = PlayerSpellIcon19;
		PlayerSpellIcons[19] = PlayerSpellIcon20;
		PlayerSpellIcons[20] = PlayerSpellIcon21;
		PlayerSpellIcons[21] = PlayerSpellIcon22;
		PlayerSpellIcons[22] = PlayerSpellIcon23;
		PlayerSpellIcons[23] = PlayerSpellIcon24;
		PlayerSpellIcons[24] = PlayerSpellIcon25;
		PlayerSpellIcons[25] = PlayerSpellIcon26;
		PlayerSpellIcons[26] = PlayerSpellIcon27;
		PlayerSpellIcons[27] = PlayerSpellIcon28;
		PlayerSpellIcons[28] = PlayerSpellIcon29;
		PlayerSpellIcons[29] = PlayerSpellIcon30;
	}

	#endregion
}