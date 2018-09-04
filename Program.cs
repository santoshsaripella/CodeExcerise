using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
public class Program
	{
		static void Main(string[] args)
		{
			Generate g = new Generate();
			Random _rdm = new Random();
			string char1 = g.GenerateRandomNo(_rdm);
			string char2 = g.GenerateRandomNo(_rdm);
			string char3 = g.GenerateRandomNo(_rdm);
			string char4 = g.GenerateRandomNo(_rdm);

			int number = Convert.ToInt32(char1 + char2 + char3 + char4);
			Console.WriteLine("Please enter a number with a digit range 1 to 6. Max tries 10 times");
			bool flag = false;
			for (int i = 1; i <= 10; i++)
			{
				var val = Console.ReadLine();
				if (isValid(val))
				{
					var intValue = Convert.ToInt32(val);
					if (intValue == number)
					{
						flag = true;
						break;
					}
					else
					{
						Console.WriteLine("Please enter a number with a digit range 1 to 6. Max tries " + (10 - i).ToString() + " times");
						Console.WriteLine("--++");
						string charPos = "";
						for (int c = 1; c <= 4; c++)
						{
							if (val.Substring(c - 1, 1) == number.ToString().Substring(c - 1, 1))
								charPos += "-";
							else
								charPos += "+";
						}
						charPos = ReplacePosition(charPos);
						Console.WriteLine("Please enter a number with a digit range 1 to 6. Max tries " + (10 - i).ToString() + " times" + charPos);
					}


				}
				else
					Console.WriteLine("Please enter a number with a digit range 1 to 6. Max tries " + (10 - i).ToString() + " times");



			}
			if (flag)
			{
				Console.WriteLine("Number matched :" + number.ToString());
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Exceeded maximum limit.");
				Console.ReadLine();
			}
		}

		private static bool isValid(string number)
		{
			int n;
			bool isNumeric = int.TryParse(number, out n);
			return isNumeric;
		}

		private static string ReplacePosition(string charPos)
		{
			if (charPos == "---+")
				return "+---";
			else if (charPos == "--++")
				return "++--";
			else if (charPos == "-+++")
				return "+++-";
			else if (charPos == "-+--")
				return "+---";
			return charPos;
		}
	}

	public class Generate
	{
		public string GenerateRandomNo(Random _rdm)
		{
			int _min = 1;
			int _max = 7;

			return _rdm.Next(_min, _max).ToString();
		}
	}
}
