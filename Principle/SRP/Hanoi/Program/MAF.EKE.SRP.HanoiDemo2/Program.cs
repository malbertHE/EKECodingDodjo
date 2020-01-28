using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MAF.EKE.SRP.HanoiDemo2
{
	class Program
	{
		const byte c_LinesInConsole = 25;
		const byte c_DemoBoxLeftBarWidth = 3;
		const byte c_RodTopY = 6;
		const byte c_DiskInfoBarWidth = 12;
		const byte c_DiskInfoRightBar = 3;
		const byte c_MaxDiskCount = 15;
		const byte c_MinDiskCount = 1;
		const byte c_RodWidth = 1;
		const char c_RodChar = ' ';
		const string c_InfoTextBegin = "Aktuális lépés: ";

		static Hanoi hanoi;
		static int rodXPositionA;
		static int rodXPositionB;
		static int rodXPositionC;
		static int rodTopY;
		static byte numberOfDisks;
		static byte disksInfoBoxWidth;
		static byte maxDiskSize;
		static int demoBoxLeft;

		static void Main(string[] args)
		{
			SetNumberOfDisks();

			InitDrawHanoi();

			DrawDisks();

			DrawInitialState();

			RunDemo(hanoi.NumberOfSteps);

			Console.ReadKey();
		}

		private static byte GetDiskSize(byte pDiskNo) => (byte)(pDiskNo * 2 + c_RodWidth);

		private static void InitVariables(byte pNumberOfDisks)
		{
			maxDiskSize = GetDiskSize(numberOfDisks);
			disksInfoBoxWidth = (byte)(maxDiskSize + c_DiskInfoBarWidth + c_DiskInfoRightBar);
			demoBoxLeft = disksInfoBoxWidth + c_DemoBoxLeftBarWidth;
			rodXPositionA = demoBoxLeft + numberOfDisks + c_RodWidth;
			rodXPositionB = rodXPositionA + maxDiskSize;
			rodXPositionC = rodXPositionB + maxDiskSize;
			rodTopY = c_RodTopY;
		}

		private static void SetNumberOfDisks()
		{
			Console.WriteLine("Hanoi torony demó program.");
			while (true)
			{
				Console.Write("Kérem adja meg a korongok számát [1,15] intervallumban: ");
				if (!byte.TryParse(Console.ReadLine(), out numberOfDisks) || numberOfDisks < c_MinDiskCount || numberOfDisks > c_MaxDiskCount)
					Console.WriteLine("A megadott érték nem megfelelő!");
				else
				{
					InitVariables(numberOfDisks);
					break;
				}
			}
		}

		private static void InitDrawHanoi()
		{
			InitConsole();

			hanoi = new Hanoi(numberOfDisks);
			Console.WriteLine($"{hanoi.NumberOfDisks} korongszámú Hanoi torny demó");
			Console.WriteLine();
		}

		private static void DrawDisksInfo()
		{
			for (byte i = 1; i <= numberOfDisks; i++)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				ConsoleColor cc = (ConsoleColor)i;
				Console.ForegroundColor = cc;
				Console.Write("Korong {0} = {1}", i, new string(' ', numberOfDisks - i));
				Console.BackgroundColor = cc;
				Console.WriteLine(new string(' ', GetDiskSize(i)));
			}
		}

		private static void DrawSeparatorVerticalLine()
		{
			for (int i = 1; i < c_LinesInConsole - 1; i++)
			{
				Console.SetCursorPosition(disksInfoBoxWidth, i);
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("|");
			}
		}

		private static void DrawDisks()
		{
			DrawDisksInfo();
			DrawSeparatorVerticalLine();
		}

		private static void WriteRodNames()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(rodXPositionA, rodTopY);
			Console.WriteLine(Hanoi.C_RodNameA);
			Console.SetCursorPosition(rodXPositionB, rodTopY);
			Console.WriteLine(Hanoi.C_RodNameB);
			Console.SetCursorPosition(rodXPositionC, rodTopY);
			Console.WriteLine(Hanoi.C_RodNameC);
			rodTopY++;
		}

		private static void DrawingRods()
		{
			Console.BackgroundColor = ConsoleColor.Gray;
			int rodHeight = numberOfDisks + rodTopY + 1;
			for (int i = rodTopY; i < rodHeight; i++)
			{
				Console.SetCursorPosition(rodXPositionA, i);
				Console.WriteLine(c_RodChar);
				Console.SetCursorPosition(rodXPositionB, i);
				Console.WriteLine(c_RodChar);
				Console.SetCursorPosition(rodXPositionC, i);
				Console.WriteLine(c_RodChar);
			}
		}

		private static void DrawRods()
		{
			WriteRodNames();
			DrawingRods();
		}

		private static void DrawDisksInitialState()
		{
			for (byte i = numberOfDisks; i >= 1; i--)
			{
				Thread.Sleep(500);
				Console.SetCursorPosition(rodXPositionA - i, rodTopY + i);
				Console.BackgroundColor = (ConsoleColor)i;
				Console.WriteLine(new string(' ', GetDiskSize(i)));
			}
		}

		private static void DrawInitialState()
        {
			DrawRods();
			DrawDisksInitialState();
        }

		private static void WriteInfoTextBegin()
		{
			Console.SetCursorPosition(demoBoxLeft, 2);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write(c_InfoTextBegin);
		}

		private static void WriteStepInfo(int i)
		{
			Console.SetCursorPosition(demoBoxLeft + c_InfoTextBegin.Length, 2);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write(string.Format("{0}. korong átrakása {1} -> {2}  ", hanoi[i].KorongSzáma, hanoi[i].Rúdról, hanoi[i].Rúdra));
		}

		private static void ClearActualDisk(byte[] abc, int i)
		{
			byte ti = GetRodIndex(hanoi[i].Rúdról);
			Console.SetCursorPosition(GetRodPosition(hanoi[i].Rúdról) - (byte)hanoi[i].KorongSzáma, rodTopY + 1 + numberOfDisks - abc[ti]);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine(new string(' ', (byte)hanoi[i].KorongSzáma * 2 + 1));
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(GetRodPosition(hanoi[i].Rúdról), rodTopY + 1 + numberOfDisks - abc[ti]);
			Console.WriteLine(" ");
			abc[ti]--;
		}

		private static void DrawActualDisk(byte[] abc, int i)
		{
			byte ti = GetRodIndex(hanoi[i].Rúdra);
			abc[ti]++;
			Console.SetCursorPosition(GetRodPosition(hanoi[i].Rúdra) - (byte)hanoi[i].KorongSzáma, rodTopY + 1 + numberOfDisks - abc[ti]);
			Console.BackgroundColor = (ConsoleColor)(byte)hanoi[i].KorongSzáma;
			Console.WriteLine(new string(' ', (byte)hanoi[i].KorongSzáma * 2 + 1));
		}

		private static void RunDemo(int idx)
		{
			WriteInfoTextBegin();

			byte[] abc = new byte[3];
			abc[0] = numberOfDisks; abc[1] = 0; abc[2] = 0;

			for (int i = 0; i < idx; i++)
			{
				WriteStepInfo(i);
				//Thread.Sleep(500);
				ClearActualDisk(abc, i);
				DrawActualDisk(abc, i);
			}
		}

		private static int GetRodPosition(char ch)
		{
			switch (ch)
			{
				case Hanoi.C_RodNameA:
					return rodXPositionA;
				case Hanoi.C_RodNameB:
					return rodXPositionB;
				case Hanoi.C_RodNameC:
					return rodXPositionC;
				default:
					throw new Exception("Ismeretlen nevű oszlop!");
			}
		}

		static byte GetRodIndex(char ch)
		{
			switch (ch)
			{
				case Hanoi.C_RodNameA:
					return 0;
				case Hanoi.C_RodNameB:
					return 1;
				case Hanoi.C_RodNameC:
					return 2;
				default:
					throw new Exception("Ismeretlen nevű oszlop!");
			}
		}


		#region Extern Block

		const int MF_BYCOMMAND = 0x00000000;
		const int SC_CLOSE = 0xF060;
		const int SC_MINIMIZE = 0xF020;
		const int SC_MAXIMIZE = 0xF030;
		const int SC_SIZE = 0xF000;

		[DllImport("user32.dll")]
		static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

		[DllImport("user32.dll")]
		static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("kernel32.dll", ExactSpelling = true)]
		static extern IntPtr GetConsoleWindow();

		private static void InitConsole()
		{
			Console.Clear();
			IntPtr handle = GetConsoleWindow();
			IntPtr sysMenu = GetSystemMenu(handle, false);

			if (handle != IntPtr.Zero)
			{
				DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
				DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
				DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
			}
			int width = ((numberOfDisks * 2) * 4) + 12 + 30;
			if (width < 70)
				width = 70;
			Console.SetWindowSize(width, c_LinesInConsole);
			Console.SetBufferSize(width, c_LinesInConsole);
		}

		#endregion

	}
}
