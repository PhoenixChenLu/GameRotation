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

	private Icon[] Icons = new Icon[30];

	private void InitializeIcons()
	{
		Icons[0] = BuffIcon1;
		Icons[1] = BuffIcon2;
		Icons[2] = BuffIcon3;
		Icons[3] = BuffIcon4;
		Icons[4] = BuffIcon5;
		Icons[5] = BuffIcon6;
		Icons[6] = BuffIcon7;
		Icons[7] = BuffIcon8;
		Icons[8] = BuffIcon9;
		Icons[9] = BuffIcon10;
		Icons[10] = BuffIcon11;
		Icons[11] = BuffIcon12;
		Icons[12] = BuffIcon13;
		Icons[13] = BuffIcon14;
		Icons[14] = BuffIcon15;
		Icons[15] = BuffIcon16;
		Icons[16] = BuffIcon17;
		Icons[17] = BuffIcon18;
		Icons[18] = BuffIcon19;
		Icons[19] = BuffIcon20;
		Icons[20] = BuffIcon21;
		Icons[21] = BuffIcon22;
		Icons[22] = BuffIcon23;
		Icons[23] = BuffIcon24;
		Icons[24] = BuffIcon25;
		Icons[25] = BuffIcon26;
		Icons[26] = BuffIcon27;
		Icons[27] = BuffIcon28;
		Icons[28] = BuffIcon29;
		Icons[29] = BuffIcon30;
	}
	
	#endregion
	
}