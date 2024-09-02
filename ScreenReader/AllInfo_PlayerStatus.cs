using System.Drawing;
using System.Net.Mime;
using ScreenReader.Player;
using WoWData.Entities;

namespace ScreenReader;

public partial class AllInfo
{
	private Specializations _specialization = Specializations.None;

	public Specializations Specialization
	{
		get => _specialization;
		set
		{
			if (_specialization != value)
			{
				_specialization = value;
				SpecializationChanged?.Invoke(value);
			}
		}
	}

	public event Action<Specializations> SpecializationChanged;

	public PlayerStatus? PlayerStatus { get; set; }

	private void UpdatePlayerStatus(uint ticks)
	{
		PlayerStatus.ReadFromBitmap(Image, CurrentTime);
	}

	private void UpdateSpecialization(uint ticks)
	{
		if (Image is null) Specialization = Specializations.None;
		Color specColor = Image.GetPixel(49, 1);
		Specialization = SpecializationDict.GetSpecialization(specColor.R, specColor.G);
	}
}