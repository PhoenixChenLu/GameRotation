using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameRotation.Controls;

public partial class PlayerStatusControl
{
	private string _imageSourceFolderPath;

	private void InitializeImagePath()
	{
		AliveIcon.SetIconName("alive");
		InCombatIcon.SetIconName("combat");
		MountedIcon.SetIconName("mount");
		InVehicleIcon.SetIconName("invehicle");
		JumpingIcon.SetIconName("jumping");
		MovingIcon.SetIconName("moving");
		CastingIcon.SetIconName("casting");
		ChannelingIcon.SetIconName("channeling");
		GlobalCooldownIcon.SetIconName("gcd");
	}
}