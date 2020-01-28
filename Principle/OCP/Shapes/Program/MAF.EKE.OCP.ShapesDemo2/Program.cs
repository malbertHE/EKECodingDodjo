using MAF.EKE.OCP.Shapes;
using System;

namespace MAF.EKE.OCP.ShapesDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Add meg a négyzet egyik oldalának relatív méretét:");
				Console.Write("a = ");
				ushort aOldal;
				if (!ushort.TryParse(Console.ReadLine(), out aOldal) || aOldal < 0)
				{
					Console.WriteLine("A négyzet oldal méretének csak pozitív szám adható!");
					return;
				}

				Square square = Square.CreateSquare(aOldal);
				try
				{
					Console.WriteLine($"A négyzetlap területe = {square.AreaCalculation()}");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			finally
			{
				Console.WriteLine("Kilépés a programból Enter leütésére.");
				Console.ReadLine();
			}
		}
	}
}
