using System.Drawing;
using ScreenReader.NamePlates;

namespace ScreenReader;

public partial class AllInfo
{
	public NameplateStatus[] NameplateStatus { get; set; }

	public int TargetIndex { get; set; }

	public int FocusIndex { get; set; }

	public int MouseoverIndex { get; set; }

	public int Boss1Index { get; set; }

	public int Boss2Index { get; set; }

	public int Boss3Index { get; set; }

	public int Boss4Index { get; set; }

	public int Boss5Index { get; set; }

	public int Boss6Index { get; set; }

	public int Boss7Index { get; set; }

	public int Boss8Index { get; set; }

	public NameplateStatus TargetNameplate => TargetIndex > 0 ? NameplateStatus[TargetIndex - 1] : null;

	public NameplateStatus FocusNameplate => FocusIndex > 0 ? NameplateStatus[FocusIndex - 1] : null;

	public NameplateStatus MouseoverNameplate => MouseoverIndex > 0 ? NameplateStatus[MouseoverIndex - 1] : null;

	public NameplateStatus Boss1Nameplate => Boss1Index > 0 ? NameplateStatus[Boss1Index - 1] : null;

	public NameplateStatus Boss2Nameplate => Boss2Index > 0 ? NameplateStatus[Boss2Index - 1] : null;

	public NameplateStatus Boss3Nameplate => Boss3Index > 0 ? NameplateStatus[Boss3Index - 1] : null;

	public NameplateStatus Boss4Nameplate => Boss4Index > 0 ? NameplateStatus[Boss4Index - 1] : null;

	public NameplateStatus Boss5Nameplate => Boss5Index > 0 ? NameplateStatus[Boss5Index - 1] : null;

	public NameplateStatus Boss6Nameplate => Boss6Index > 0 ? NameplateStatus[Boss6Index - 1] : null;

	public NameplateStatus Boss7Nameplate => Boss7Index > 0 ? NameplateStatus[Boss7Index - 1] : null;

	public NameplateStatus Boss8Nameplate => Boss8Index > 0 ? NameplateStatus[Boss8Index - 1] : null;

	private void UpdateNameplateStatus(uint ticks)
	{
		for (int i = 0; i < 20; i++)
		{
			int xShift = (i % 20) * 3;
			int yShift = (i / 20) * 45;
			NameplateStatus[i].ReadFromBitmap(Image, CurrentTime, xShift + 1, yShift + 10);
		}

		UpdateSpecialUnitIndex();
	}

	private void UpdateSpecialUnitIndex()
	{
		int startX = 1 + 20 * 3, startY = 10;
		Color color1 = Image.GetPixel(startX, startY);
		Color color2 = Image.GetPixel(startX + 3, startY);
		Color color3 = Image.GetPixel(startX + 6, startY);
		Color color4 = Image.GetPixel(startX + 9, startY);

		TargetIndex = color1.R;
		FocusIndex = color1.G;
		MouseoverIndex = color1.B;
		Boss1Index = color2.R;
		Boss2Index = color2.G;
		Boss3Index = color2.B;
		Boss4Index = color3.R;
		Boss5Index = color3.G;
		Boss6Index = color3.B;
		Boss7Index = color4.R;
		Boss8Index = color4.G;
	}
}