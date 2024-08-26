using System.Drawing;

namespace ScreenReader;

public static class PlayerStatusRead
{
	public static int StartX = 0;
	public static int StartY = 0;
	public static int Width = 3;
	public static int Height = 3;

	public static PlayerStatus ReadPlayerStatus(Bitmap bmp)
	{
		int scanX = StartX + Width / 2;
		int scanY = StartY + Height / 2;
		Color[] colors = new Color[100];
		int i = 0;
		while (scanX < bmp.Width)
		{
			colors[i] = bmp.GetPixel(scanX, scanY);
			bmp.SetPixel(scanX, scanY, Color.Red);
			scanX += Width;
			i++;
		}

		uint currentTick = Functions.ColorToUint(colors[0], colors[1]);
		bool[] playerStatusBools = Functions.ColorToBool(colors[2]);
		bool playerAlive = playerStatusBools[0];
		bool playerInCombat = playerStatusBools[1];
		bool playerMounted = playerStatusBools[2];
		bool playerInVehicle = playerStatusBools[3];
		bool playerJumping = playerStatusBools[4];
		bool playerMoving = playerStatusBools[5];
		bool playerCasting = playerStatusBools[6];
		bool playerChanneling = playerStatusBools[7];
		uint playerHealth = Functions.ColorToUint(colors[3], colors[4]);
		uint playerMaxHealth = Functions.ColorToUint(colors[5], colors[6]);
		uint playerPower = Functions.ColorToUint(colors[7], colors[8]);
		uint playerMaxPower = Functions.ColorToUint(colors[9], colors[10]);
		uint playerRemainingGCD = Functions.ColorToUint(colors[11]);
		uint playerRemainingCastTime = Functions.ColorToUint(colors[12], colors[13]);
		uint playerRemainingChannelTime = Functions.ColorToUint(colors[14], colors[15]);

		return new PlayerStatus
		{
			CurrentTick = currentTick,
			PlayerAlive = playerAlive,
			PlayerInCombat = playerInCombat,
			PlayerMounted = playerMounted,
			PlayerInVehicle = playerInVehicle,
			PlayerJumping = playerJumping,
			PlayerMoving = playerMoving,
			PlayerCasting = playerCasting,
			PlayerChanneling = playerChanneling,
			PlayerHealth = playerHealth,
			PlayerMaxHealth = playerMaxHealth,
			PlayerPower = playerPower,
			PlayerMaxPower = playerMaxPower,
			PlayerRemainingGlobalCooldownTicks = playerRemainingGCD,
			PlayerRemainingCastTicks = playerRemainingCastTime,
			PlayerRemainingChannelTicks = playerRemainingChannelTime
		};
	}
}