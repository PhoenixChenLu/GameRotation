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

	#region 玩家状态

	private Color _playerAliveColor = Colors.Red;

	public Color PlayerAliveColor
	{
		get => _playerAliveColor;
		set => SetField(ref _playerAliveColor, value);
	}

	private Color _playerInCombatColor = Colors.Red;

	public Color PlayerInCombatColor
	{
		get => _playerInCombatColor;
		set => SetField(ref _playerInCombatColor, value);
	}

	private Color _playerMountedColor = Colors.Red;

	public Color PlayerMountedColor
	{
		get => _playerMountedColor;
		set => SetField(ref _playerMountedColor, value);
	}

	private Color _playerInVehicleColor = Colors.Red;

	public Color PlayerInVehicleColor
	{
		get => _playerInVehicleColor;
		set => SetField(ref _playerInVehicleColor, value);
	}

	private Color _playerJumpingColor = Colors.Red;

	public Color PlayerJumpingColor
	{
		get => _playerJumpingColor;
		set => SetField(ref _playerJumpingColor, value);
	}

	private Color _playerMovingColor = Colors.Red;

	public Color PlayerMovingColor
	{
		get => _playerMovingColor;
		set => SetField(ref _playerMovingColor, value);
	}

	private Color _playerIsCastingColor = Colors.Red;

	public Color PlayerIsCastingColor
	{
		get => _playerIsCastingColor;
		set => SetField(ref _playerIsCastingColor, value);
	}

	private Color _playerIsChannelingColor = Colors.Red;

	public Color PlayerIsChannelingColor
	{
		get => _playerIsChannelingColor;
		set => SetField(ref _playerIsChannelingColor, value);
	}

	#endregion

	#region 生命值和法力值

	private string _playerCurrentHealth = "0";

	public string PlayerCurrentHealth
	{
		get => _playerCurrentHealth;
		set => SetField(ref _playerCurrentHealth, value);
	}

	private string _playerMaxHealth = "0";

	public string PlayerMaxHealth
	{
		get => _playerMaxHealth;
		set => SetField(ref _playerMaxHealth, value);
	}

	private string _playerCurrentPower = "0";

	public string PlayerCurrentPower
	{
		get => _playerCurrentPower;
		set => SetField(ref _playerCurrentPower, value);
	}

	private string _playerMaxPower = "0";

	public string PlayerMaxPower
	{
		get => _playerMaxPower;
		set => SetField(ref _playerMaxPower, value);
	}

	#endregion

	#region 公共冷却

	private string _playerGlobalCooldown = "0";

	public string PlayerGlobalCooldown
	{
		get => _playerGlobalCooldown;
		set => SetField(ref _playerGlobalCooldown, value);
	}

	#endregion

	#region 施法和引导剩余时间

	private string _playerCastEndTime = "0";

	public string PlayerCastEndTime
	{
		get => _playerCastEndTime;
		set => SetField(ref _playerCastEndTime, value);
	}

	private string _playerCastRemainingTime = "0";

	public string PlayerCastRemainingTime
	{
		get => _playerCastRemainingTime;
		set => SetField(ref _playerCastRemainingTime, value);
	}

	#endregion
}