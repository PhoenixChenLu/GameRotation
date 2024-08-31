using System.Drawing;
using ScreenReader.NamePlates;
using ScreenReader.Player;
using WoWData.Entities;

namespace ScreenReader;

public partial class AllInfo
{
	public Bitmap Image { get; private set; }

	private bool _initialized = false;

	private uint _currentTick;

	public uint CurrentTick
	{
		get => _currentTick;
		set
		{
			if (_currentTick != value)
			{
				_currentTick = value;
				CurrentTickChanged?.Invoke(value);
			}
		}
	}

	public DateTime CurrentTime { get; private set; }

	public event Action<uint> CurrentTickChanged;

	private void UpdateTime()
	{
		if (Image is null) return;
		Color high = Image.GetPixel(1, 1), low = Image.GetPixel(4, 1);
		uint ticks = (uint)(high.R << 16 | high.G << 8 | high.B) << 24 | (uint)(low.R << 16 | low.G << 8 | low.B);
		CurrentTime = Functions.SystemStartTime.AddMilliseconds(ticks);
		CurrentTick = ticks;
	}

	private void Initialize()
	{
		_initialized = true;
		SpecializationChanged += InitializeFromSpecialization;
		CurrentTickChanged += ReadDataFromImage;
	}

	private void InitializeFromSpecialization(Specializations specialization)
	{
		NameplateStatus ??= new NameplateStatus[20];
		
		for (int i = 0; i < 20; i++)
		{
			NameplateStatus[i] = NamePlates.NameplateStatus.GenerateNameplateBySpec(specialization);
		}
	}

	public void UpdateFromImage(Bitmap bmp)
	{
		if (!_initialized)
			Initialize();
		Image = bmp;
		UpdateTime();
	}

	public event Action<AllInfo> DataUpdated;

	private void ReadDataFromImage(uint ticks)
	{
		UpdateTime();
		UpdatePlayerStatus(ticks);
		UpdateNameplateStatus(ticks);
		DataUpdated?.Invoke(this);
	}
}