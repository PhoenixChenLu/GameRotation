namespace KeyboardSimulator.Entities;

[Flags]
public enum KeyboardInputFlag : uint
{
	ExtendedKey = 0x0001,
	
	KeyUp = 0x0002,
	
	Unicode = 0x0004,
	
	ScanCode = 0x0008
}