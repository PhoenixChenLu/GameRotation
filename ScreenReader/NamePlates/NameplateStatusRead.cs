using System.Drawing;
using WoWData.Buffs;

namespace ScreenReader.NamePlates;

public static class NameplateStatusRead
{
	public static int Height = 3;


	public static void ReadFromBitmap(this NameplateStatus status, Bitmap bmp, int startX, int startY, DateTime currentTime)
	{
		int scanX = startX;
		int scanY = startY;
		Color[] Colors = new Color[20];
		int i = 0;
		while (scanY < bmp.Height && i < 15)
		{
			Colors[i] = bmp.GetPixel(scanX, scanY);
			bmp.SetPixel(scanX, scanY, Color.Red);
			i++;
			scanY += Height;
		}

		bool[] bools1 = Functions.ColorToBool(Colors[0]);
		bool[] bools2 = Functions.ColorToBool(Colors[1]);
		bool[] bools3 = Functions.ColorToBool(Colors[2]);

		uint currentHealth = Functions.ColorToUint(Colors[3], Colors[4]);
		uint maxHealth = Functions.ColorToUint(Colors[5], Colors[6]);

		status.Exists = bools1[0];
		if (!status.Exists)
		{
			return;
		}

		status.IsDead = bools1[1];
		status.CanAttack = bools1[2];
		status.IsInCombat = bools1[3];
		status.IsThreat = bools1[4];
		status.IsCasting = bools1[5];
		status.CanInterruptCast = bools1[6];
		status.IsChanneling = bools1[7];
		status.CanInterruptChannel = bools2[0];
		status.IsInterruptible = bools2[1];
		status.InMeleeRange = bools2[2];
		status.In6YardRange = bools2[3];
		status.In8YardRange = bools2[4];
		status.In10YardRange = bools2[5];
		status.In15YardRange = bools2[6];
		status.In20YardRange = bools2[7];
		status.In25YardRange = bools3[0];
		status.In30YardRange = bools3[1];
		status.In35YardRange = bools3[2];
		status.In40YardRange = bools3[3];
		status.In70YardRange = bools3[4];
		status.In80YardRange = bools3[5];
		status.In100YardRange = bools3[6];


		status.CurrentHealth = currentHealth;
		status.MaxHealth = maxHealth;


		for (int j = 0; j < status.PlayerDebuffs.Count; j++)
		{
			status.PlayerDebuffs[j].UpdateFromColorAndCurrentTime(Colors[7 + j], currentTime);
		}
	}
}