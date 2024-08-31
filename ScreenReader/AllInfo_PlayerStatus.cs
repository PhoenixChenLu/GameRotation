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
		PlayerStatus = PlayerStatusRead.ReadPlayerStatus(Image);
		Specialization = PlayerStatus?.Specialization ?? Specializations.None;
	}
}