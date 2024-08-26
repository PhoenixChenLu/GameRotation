namespace KeyboardSimulator.Entities;

public enum MapType : uint
{
	/// <summary>
	/// 将虚拟键码转换为扫描码
	/// </summary>
	MAPVK_VK_TO_VSC = 0x0,
	
	/// <summary>
	/// 将扫描码转换为虚拟键码
	/// </summary>
	MAPVK_VSC_TO_VK = 0x1,
	
	/// <summary>
	/// 将虚拟键码转换为字符
	/// </summary>
	MAPVK_VK_TO_CHAR = 0x2,
	
	/// <summary>
	/// 将扫描码转换为虚拟键码
	/// </summary>
	MAPVK_VSC_TO_VK_EX = 0x3,
	
	/// <summary>
	/// 将虚拟键码转换为扫描码
	/// </summary>
	MAPVK_VK_TO_VSC_EX = 0x4
}