using System;

namespace MAF.EKE.OCP.ShapesDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Add meg a négyzet egyik oldalának relatív méretét:");
			Console.Write("a = ");
			uint aOldal;
			if (!uint.TryParse(Console.ReadLine(), out aOldal))
			{
				Console.WriteLine("A négyzet oldal méretének csak pozitív egész szám adható!");
				return;
			}

			Console.WriteLine("A négyzetlap területe = " + aOldal * aOldal);

			Console.ReadLine();
		}
	}
}
