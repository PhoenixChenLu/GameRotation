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

	private Icon[] WatchingSpellIcons = new Icon[30];

	private void InitializePlayerSpellIcons()
	{
		WatchingSpellIcons[0] = WatchingSpellIcon1;
		WatchingSpellIcons[1] = WatchingSpellIcon2;
		WatchingSpellIcons[2] = WatchingSpellIcon3;
		WatchingSpellIcons[3] = WatchingSpellIcon4;
		WatchingSpellIcons[4] = WatchingSpellIcon5;
		WatchingSpellIcons[5] = WatchingSpellIcon6;
		WatchingSpellIcons[6] = WatchingSpellIcon7;
		WatchingSpellIcons[7] = WatchingSpellIcon8;
		WatchingSpellIcons[8] = WatchingSpellIcon9;
		WatchingSpellIcons[9] = WatchingSpellIcon10;
		WatchingSpellIcons[10] = WatchingSpellIcon11;
		WatchingSpellIcons[11] = WatchingSpellIcon12;
		WatchingSpellIcons[12] = WatchingSpellIcon13;
		WatchingSpellIcons[13] = WatchingSpellIcon14;
		WatchingSpellIcons[14] = WatchingSpellIcon15;
		WatchingSpellIcons[15] = WatchingSpellIcon16;
		WatchingSpellIcons[16] = WatchingSpellIcon17;
		WatchingSpellIcons[17] = WatchingSpellIcon18;
		WatchingSpellIcons[18] = WatchingSpellIcon19;
		WatchingSpellIcons[19] = WatchingSpellIcon20;
		WatchingSpellIcons[20] = WatchingSpellIcon21;
		WatchingSpellIcons[21] = WatchingSpellIcon22;
		WatchingSpellIcons[22] = WatchingSpellIcon23;
		WatchingSpellIcons[23] = WatchingSpellIcon24;
		WatchingSpellIcons[24] = WatchingSpellIcon25;
		WatchingSpellIcons[25] = WatchingSpellIcon26;
		WatchingSpellIcons[26] = WatchingSpellIcon27;
		WatchingSpellIcons[27] = WatchingSpellIcon28;
		WatchingSpellIcons[28] = WatchingSpellIcon29;
		WatchingSpellIcons[29] = WatchingSpellIcon30;
	}

	#endregion

	private Icon[] AllSpellIcons = new Icon[50];

	private void InitializeAllSpellIcons()
	{
		AllSpellIcons[0] = AllSpellIcon1;
		AllSpellIcons[1] = AllSpellIcon2;
		AllSpellIcons[2] = AllSpellIcon3;
		AllSpellIcons[3] = AllSpellIcon4;
		AllSpellIcons[4] = AllSpellIcon5;
		AllSpellIcons[5] = AllSpellIcon6;
		AllSpellIcons[6] = AllSpellIcon7;
		AllSpellIcons[7] = AllSpellIcon8;
		AllSpellIcons[8] = AllSpellIcon9;
		AllSpellIcons[9] = AllSpellIcon10;
		AllSpellIcons[10] = AllSpellIcon11;
		AllSpellIcons[11] = AllSpellIcon12;
		AllSpellIcons[12] = AllSpellIcon13;
		AllSpellIcons[13] = AllSpellIcon14;
		AllSpellIcons[14] = AllSpellIcon15;
		AllSpellIcons[15] = AllSpellIcon16;
		AllSpellIcons[16] = AllSpellIcon17;
		AllSpellIcons[17] = AllSpellIcon18;
		AllSpellIcons[18] = AllSpellIcon19;
		AllSpellIcons[19] = AllSpellIcon20;
		AllSpellIcons[20] = AllSpellIcon21;
		AllSpellIcons[21] = AllSpellIcon22;
		AllSpellIcons[22] = AllSpellIcon23;
		AllSpellIcons[23] = AllSpellIcon24;
		AllSpellIcons[24] = AllSpellIcon25;
		AllSpellIcons[25] = AllSpellIcon26;
		AllSpellIcons[26] = AllSpellIcon27;
		AllSpellIcons[27] = AllSpellIcon28;
		AllSpellIcons[28] = AllSpellIcon29;
		AllSpellIcons[29] = AllSpellIcon30;
		AllSpellIcons[30] = AllSpellIcon31;
		AllSpellIcons[31] = AllSpellIcon32;
		AllSpellIcons[32] = AllSpellIcon33;
		AllSpellIcons[33] = AllSpellIcon34;
		AllSpellIcons[34] = AllSpellIcon35;
		AllSpellIcons[35] = AllSpellIcon36;
		AllSpellIcons[36] = AllSpellIcon37;
		AllSpellIcons[37] = AllSpellIcon38;
		AllSpellIcons[38] = AllSpellIcon39;
		AllSpellIcons[39] = AllSpellIcon40;
		AllSpellIcons[40] = AllSpellIcon41;
		AllSpellIcons[41] = AllSpellIcon42;
		AllSpellIcons[42] = AllSpellIcon43;
		AllSpellIcons[43] = AllSpellIcon44;
		AllSpellIcons[44] = AllSpellIcon45;
		AllSpellIcons[45] = AllSpellIcon46;
		AllSpellIcons[46] = AllSpellIcon47;
		AllSpellIcons[47] = AllSpellIcon48;
		AllSpellIcons[48] = AllSpellIcon49;
		AllSpellIcons[49] = AllSpellIcon50;
	}
}