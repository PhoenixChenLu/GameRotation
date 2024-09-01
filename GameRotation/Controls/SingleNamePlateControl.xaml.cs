using System.Windows.Controls;

namespace GameRotation.Controls;

public partial class SingleNamePlateControl : UserControl
{
	public SingleNamePlateControl()
	{
		InitializeComponent();
		InitializeSelfIcons();
		InitializeStatusIcons();
		SetNotExist();
	}
}