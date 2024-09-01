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

		bool[] bools = Functions.ColorToBool(Colors[0]);


		uint currentHealth = Functions.ColorToUint(Colors[1], Colors[2]);
		uint maxHealth = Functions.ColorToUint(Colors[3], Colors[4]);

		status.Exists = bools[0];
		if (!status.Exists)
		{
			return;
		}

		status.IsDead = bools[1];
		status.CanAttack = bools[2];
		status.IsInCombat = bools[3];
		status.IsThreat = bools[4];
		status.IsCasting = bools[5];
		status.CanInterruptCast = bools[6];
		status.IsChanneling = bools[7];
		status.CanInterruptChannel = bools[8];
		status.IsInterruptible = bools[9];
		status.InMeleeRange = bools[10];
		status.In6YardRange = bools[11];
		status.In8YardRange = bools[12];
		status.In10YardRange = bools[13];
		status.In15YardRange = bools[14];
		status.In20YardRange = bools[15];
		status.In25YardRange = bools[16];
		status.In30YardRange = bools[17];
		status.In35YardRange = bools[18];
		status.In40YardRange = bools[19];
		status.In70YardRange = bools[20];
		status.In80YardRange = bools[21];
		status.In100YardRange = bools[22];


		status.CurrentHealth = currentHealth;
		status.MaxHealth = maxHealth;


		for (int j = 0; j < status.PlayerDebuffs.Count; j++)
		{
			status.PlayerDebuffs[j].UpdateFromColorAndCurrentTime(Colors[5 + j], currentTime);
		}
	}

	public static string ToChineseString(this uint number)
	{
		double doubleNumber = (double)number;
		if (doubleNumber > 1000000000000)
			return (doubleNumber / 1000000000000.0).ToString("F2") + "兆";
		if (doubleNumber > 100000000)
			return (doubleNumber / 100000000.0).ToString("F2") + "亿";
		if (doubleNumber > 10000)
			return (doubleNumber / 10000.0).ToString("F2") + "万";
		return number.ToString();
	}
}