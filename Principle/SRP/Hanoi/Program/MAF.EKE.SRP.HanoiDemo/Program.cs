using System;
using System.Collections.Generic;
using System.Threading;

namespace MAF.EKE.SRP.HanoiDemo
{
	class Program
	{
		static byte korongokSzama = 4;

		static void Main(string[] args)
		{
			abc[0] = korongokSzama; abc[1] = 0; abc[2] = 0;
			ResultList = Hanoi(korongokSzama, A, B, C);
			Console.Clear();
			Console.WriteLine("Hanoi tornyai");
			Console.WriteLine();
			for (int i = 0; i < ResultList.Count; i++)
			{
				ResultText.Add(string.Format("{0}. korong átrakása: {1} -> {2}", ResultList[i].Item1, ResultList[i].Item2,
					ResultList[i].Item3));
				Console.WriteLine(ResultText[i]);
			}
			Console.WriteLine();
			for (int i = 1; i <= korongokSzama; i++)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				ConsoleColor cc = (ConsoleColor)i;
				Console.ForegroundColor = cc;
				Console.Write("Korong {0} = {1}", i, new String(' ', korongokSzama - i));
				Console.BackgroundColor = cc;
				Console.WriteLine(new String(' ', i * 2 + 1));
			}
			x = 40;
			d = 2 * korongokSzama + 1;
			int l = korongokSzama + 5 + 1;
			f = 4;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(x, f);
			Console.WriteLine("A");
			Console.SetCursorPosition(x + d, f);
			Console.WriteLine("B");
			Console.SetCursorPosition(x + 2 * d, f);
			Console.WriteLine("C");
			f++;
			Console.BackgroundColor = ConsoleColor.Gray;
			for (int i = f; i < l; i++)
			{
				Console.SetCursorPosition(x, i);
				Console.WriteLine(" ");
				Console.SetCursorPosition(x + d, i);
				Console.WriteLine(" ");
				Console.SetCursorPosition(x + 2 * d, i);
				Console.WriteLine(" ");
			}
			for (int i = korongokSzama; i >= 1; i--)
			{
				Thread.Sleep(500);
				Console.SetCursorPosition(x - i, f + i);
				Console.BackgroundColor = (ConsoleColor)i;
				Console.WriteLine(new String(' ', i * 2 + 1));
			}
			Demo(0);

			Console.ReadKey();
		}

		private static void Demo(int idx)
		{
			if (idx > ResultList.Count - 1) return;
			Console.SetCursorPosition(0, 2 + idx);
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ResultText[idx]);
			Thread.Sleep(1500);
			byte ti = ToronyIndex(ResultList[idx].Item2);
			Console.SetCursorPosition(x + d * ti - (byte)ResultList[idx].Item1, f + 1 + korongokSzama - abc[ti]);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine(new String(' ', (byte)ResultList[idx].Item1 * 2 + 1));
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.SetCursorPosition(x + d * ti, f + 1 + korongokSzama - abc[ti]);
			Console.WriteLine(" ");
			abc[ti]--;
			Thread.Sleep(500);
			ti = ToronyIndex(ResultList[idx].Item3);
			abc[ti]++;
			Console.SetCursorPosition(x + d * ti - (byte)ResultList[idx].Item1, f + 1 + korongokSzama - abc[ti]);
			Console.BackgroundColor = (ConsoleColor)(byte)ResultList[idx].Item1;
			Console.WriteLine(new String(' ', (byte)ResultList[idx].Item1 * 2 + 1));
			Thread.Sleep(500);
			Console.SetCursorPosition(0, 2 + idx);
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine(ResultText[idx]);
			Demo(idx + 1);
		}

		private static byte ToronyIndex(char ch)
		{
			switch (ch)
			{
				case A:
					return 0;
				case B:
					return 1;
				case C:
					return 2;
				default:
					throw new Exception("Ismeretlen nevű oszlop!");
			}
		}

		static List<Tuple<uint, char, char>> Hanoi(uint N, char R1, char R2, char R3)
		{
			List<Tuple<uint, char, char>> rl = new List<Tuple<uint, char, char>>();
			HanoiA(N, R1, R2, R3, rl);
			return rl;
		}

		static void HanoiA(uint N, char R1, char R3, char R2, List<Tuple<uint, char, char>> ResultList)
		{
			if (N < 1) return;
			HanoiA(N - 1, R1, R2, R3, ResultList);
			ResultList.Add(new Tuple<uint, char, char>(N, R1, R3));
			HanoiA(N - 1, R2, R3, R1, ResultList);
		}

		static List<Tuple<uint, char, char>> ResultList;
		static List<string> ResultText = new List<string>();
		static int d;
		static int x;
		static int f;
		static byte[] abc = new byte[3];
		const char A = 'A';
		const char B = 'B';
		const char C = 'C';
	}
}
