using System;
using System.Runtime.InteropServices;

namespace QuickImage.Classes
{
	internal static class NativeMethods
	{
		[DllImport("user32.dll")]
		public static extern long SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam); 

		[DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
		public static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

		//[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr64", CharSet = CharSet.Auto)]
		//public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
		public static extern int SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);

		//[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr64", CharSet = CharSet.Auto)]
		//public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, long dwNewLong);

		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);


		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public readonly int Left; // x position of upper-left corner
			public readonly int Top; // y position of upper-left corner
			public readonly int Right; // x position of lower-right corner
			public readonly int Bottom; // y position of lower-right corner
		}
	}
}
