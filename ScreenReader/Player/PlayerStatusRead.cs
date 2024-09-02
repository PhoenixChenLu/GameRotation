using System.Drawing;
using WoWData.Entities;

namespace ScreenReader.Player;

public static class PlayerStatusRead
{
	public static int Width = 3;
	public static int Height = 3;

	public static void ReadFromBitmap(this PlayerStatus status, Bitmap bmp, DateTime currentTime, int startX = 1, int startY = 1)
	{
		int scanX = startX;
		int scanY = startY;
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
		uint playerCastEndTick = Functions.ColorToUint(colors[12], colors[13]);
		uint playerChannelEndTick = Functions.ColorToUint(colors[14], colors[15]);
		Specializations specialization = SpecializationDict.GetSpecialization(colors[16].R, colors[16].G);
		uint playerHaste = Functions.ColorToUint(colors[17]);

		status.CurrentTick = currentTick;
		status.PlayerAlive = playerAlive;
		status.PlayerInCombat = playerInCombat;
		status.PlayerMounted = playerMounted;
		status.PlayerInVehicle = playerInVehicle;
		status.PlayerJumping = playerJumping;
		status.PlayerMoving = playerMoving;
		status.PlayerCasting = playerCasting;
		status.PlayerChanneling = playerChanneling;
		status.PlayerHealth = playerHealth;
		status.PlayerMaxHealth = playerMaxHealth;
		status.PlayerPower = playerPower;
		status.PlayerMaxPower = playerMaxPower;
		status.PlayerRemainingGlobalCooldownTicks = playerRemainingGCD;
		status.PlayerCastEndTick = playerCastEndTick;
		status.PlayerChannelEndTick = playerChannelEndTick;
		status.Specialization = specialization;
		status.PlayerHaste = playerHaste / 1000.0;

		scanY = startY + Height;
		for (int j = 0; j < status.PlayerBuffList.Count; j++)
		{
			scanX = startX + j * Width;
			Color color = bmp.GetPixel(scanX, scanY);
			status.PlayerBuffList[j].UpdateFromColorAndCurrentTime(color, currentTime);
		}

		scanY = startY + Height * 2;
		for (int j = 0; j < status.PlayerWatchedSpellList.Count; j++)
		{
			scanX = startX + j * Width;
			Color color = bmp.GetPixel(scanX, scanY);
			status.PlayerWatchedSpellList[j].UpdateFromColor(color);
		}
	}
}