using ScreenReader.NamePlates;

namespace ScreenReader;

public partial class AllInfo
{
	public NameplateStatus[] NameplateStatus { get; set; }

	private void UpdateNameplateStatus(uint ticks)
	{
		for (int i = 0; i < 20; i++)
		{
			int xShift = (i % 20) * 3;
			int yShift = (i / 20) * 45;
			NameplateStatus[i].ReadFromBitmap(Image, xShift + 1, yShift + 7, CurrentTime);
		}
	}
}