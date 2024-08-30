namespace WoWData.ExtensionMethods;

public static class BinaryExtension
{
	public static bool[] ToBool(this byte b)
	{
		bool[] result = new bool[8];
		for (int i = 0; i < 8; i++)
		{
			result[i] = (b & (0b10000000 >> i)) != 0;
		}

		return result;
	}
}