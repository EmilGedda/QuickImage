using System.Collections.Generic;
using System.Windows.Forms;

namespace QuickImage.Classes
{
	internal class Hotkey
	{
		public enum HotkeyType
		{
			CaptureWindow,
			CaptureScreen,
			ShowOverlay
		};

		public static Dictionary<string, Keys> ValidKeys = new Dictionary<string, Keys>
		{
			{"A", Keys.A},
			{"B", Keys.B},
			{"C", Keys.C},
			{"D", Keys.D},
			{"E", Keys.E},
			{"F", Keys.F},
			{"G", Keys.G},
			{"H", Keys.H},
			{"I", Keys.I},
			{"J", Keys.J},
			{"K", Keys.K},
			{"L", Keys.L},
			{"M", Keys.M},
			{"N", Keys.N},
			{"O", Keys.O},
			{"P", Keys.P},
			{"Q", Keys.Q},
			{"R", Keys.R},
			{"S", Keys.S},
			{"T", Keys.T},
			{"U", Keys.U},
			{"V", Keys.V},
			{"W", Keys.W},
			{"X", Keys.X},
			{"Y", Keys.Y},
			{"Z", Keys.Z},
			{"Å", Keys.Oem6},
			{"Ä", Keys.Oem7},
			{"Ö", Keys.Oemtilde},
			{"0", Keys.D0},
			{"1", Keys.D1},
			{"2", Keys.D2},
			{"3", Keys.D3},
			{"4", Keys.D4},
			{"5", Keys.D5},
			{"6", Keys.D6},
			{"7", Keys.D7},
			{"8", Keys.D8},
			{"9", Keys.D9},
			{"F1", Keys.F1},
			{"F2", Keys.F2},
			{"F3", Keys.F3},
			{"F4", Keys.F4},
			{"F5", Keys.F5},
			{"F6", Keys.F6},
			{"F7", Keys.F7},
			{"F8", Keys.F8},
			{"F9", Keys.F9},
			{"F10", Keys.F10},
			{"F11", Keys.F11},
			{"F12", Keys.F12}
		};
	}
}