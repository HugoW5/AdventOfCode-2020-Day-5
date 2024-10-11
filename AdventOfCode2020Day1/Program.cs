using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Runtime.Intrinsics.Arm;

namespace AdventOfCode2020Day1
{
	internal class Program
	{

		static void Main(string[] args)
		{
			string[] numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


			List<string> input = new List<string>();

			using (var stream = new StreamReader("data.txt"))
			{
				while (!stream.EndOfStream)
				{
					input.Add(stream.ReadLine());
				}
			}


			int count = 0;
			for (int i = 0; i < input.Count; i++)
			{
				string nums = "";
				for (int j = 0; j < input[i].Length; j++)
				{
					if (char.IsNumber(input[i][j]))
					{
						nums += input[i][j];
						Console.WriteLine(input[i][j]);
					}
					else
					{
						for (int k = 0; k < numbers.Length; k++)
						{
							string s = "";
							for (int u = j; u < input[i].Length; u++)
							{
								s += input[i][u];
								if (s == numbers[k])
								{
									Console.WriteLine("{0} ({1})", k, s);
									nums += k;
									break;
								}
							}
						}
					}
				}
				string tmpCount = nums[0].ToString() + nums[nums.Length - 1];
				count += int.Parse(tmpCount);

				//Console.WriteLine("{0} \t {1}", i, count);
			}

			Console.WriteLine(count);

		}
	}
}