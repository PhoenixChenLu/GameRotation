namespace KeyboardSimulator.Entities;

public struct KeyboardInputData
{
	public ushort KeyCode;

	public ushort ScanCode;
	
	public uint Flags;

	public uint Time;
	
	public IntPtr ExtraInfo;
}