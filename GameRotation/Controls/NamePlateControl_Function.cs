using ScreenReader;

namespace GameRotation.Controls;

public partial class NamePlateControl
{
	public void UpdateFromAllInfo(AllInfo info)
	{
		for (var i = 0; i < 20; i++)
		{
			SingleNamePlateControls[i].DispatchUpdateFromNameplate(info.NameplateStatus[i]);
		}
	}
}