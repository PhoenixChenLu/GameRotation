namespace GameRotation.Controls;

public partial class Icon
{
	private string _imageSource;

	public string ImageSource
	{
		get => _imageSource;
		set => SetField(ref _imageSource, value);
	}

	private string _cooldownTimerText;

	public string CooldownTimerText
	{
		get => _cooldownTimerText;
		set => SetField(ref _cooldownTimerText, value);
	}

	private string _stackCountText;

	public string StackCountText
	{
		get => _stackCountText;
		set => SetField(ref _stackCountText, value);
	}

	private int _timerFontSize;

	public int TimerFontSize
	{
		get => _timerFontSize;
		set => SetField(ref _timerFontSize, value);
	}

	private int _stackCountFontSize;

	public int StackCountFontSize
	{
		get => _stackCountFontSize;
		set => SetField(ref _stackCountFontSize, value);
	}

	private void InitializeFontSize()
	{
		TimerFontSize = (int)(Height / 2);
		StackCountFontSize = (int)(Height / 4);
	}

	private string _imageFileName;
}