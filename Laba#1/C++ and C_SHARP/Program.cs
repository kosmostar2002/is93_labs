﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
	class Program
    {
		static void Counter(ref int a)
		{
			int Ai;
			for (int mask = 0; mask < sizeof(int) * 8 - 1; mask++)
			{
				Ai = (a & (1 << mask));
				if (Ai != 0) { Ai = 1; }
				if (Ai == 1)
				{
					for (int i = 0; i < mask + 1; i++)
					{
						a = a ^ (1 << i);
					}
					break;
				}
			}
		}
		static int Summa_Bit(int a, int b)
		{
			int Ai, Bi; int s = 0, k = 0;
			for (int mask = 0; mask < sizeof(int) * 8 - 1; mask++)
			{
				Ai = (a & (1 << mask));
				Bi = (b & (1 << mask));
				if (Ai != 0) { Ai = 1; }
				if (Bi != 0) { Bi = 1; }
				if (Ai + Bi + k == 1)
				{
					s = s | (1 << mask);
					k = 0;
				}
				else
				{
					if (Ai + Bi + k == 2)
					{
						k = 1;
					}
					else
					{
						if (Ai + Bi + k > 2)
						{
							k = 1;
							s = s | (1 << mask);
						}
					}
				}
				Ai = 0;
				Bi = 0;
			}
			return s;
		}
		static void Main(string[] args)
        {
			int value1;
			Console.WriteLine("Input the value for first lesson: ");
			value1 = int.Parse(Console.ReadLine());
			Counter(ref value1);
			Console.WriteLine("New value = " + value1.ToString());
			int a, b;
			Console.WriteLine("Input values a and b  for second lesson: ");
			Console.WriteLine("Input A: ");
			a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Input B: ");
			b = Convert.ToInt32(Console.ReadLine());
			int s = Summa_Bit(a, b);
			Console.WriteLine("Suma a and b = " + s);
			Console.ReadKey();
		}
    }
}
