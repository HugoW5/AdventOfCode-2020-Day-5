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

			List<string> input = new List<string>();

			using (var stream = new StreamReader("data.txt"))
			{
				while (!stream.EndOfStream)
				{
					input.Add(stream.ReadLine());
				}
			}

			List<int> powersums = new List<int>();
			int sum = 0;
			long powerSum = 1;

			for (int i = 0; i < input.Count; i++)
			{

				bool invalid = false;

				int minRed = 0;
				int minGreen = 0;
				int minBlue = 0;

				int gameId = int.Parse(input[i].Substring(5).Split(":")[0]);
				var game = input[i].Split(":")[1].Split(";");

				for (int j = 0; j < game.Length; j++)
				{
					int red = 0;
					int green = 0;
					int blue = 0;

					string s = game[j].Trim();
					if (s.Contains(','))
					{
						string[] gameParts = s.Split(",");
						for (int k = 0; k < gameParts.Length; k++)
						{
							int count = int.Parse(gameParts[k].Trim().Split(' ')[0]);
							switch (gameParts[k].Trim().Split(' ')[1])
							{
								case "red":
									red += count;
									break;
								case "green":
									green += count;
									break;
								case "blue":
									blue += count;
									break;
							}
						}
					}
					else
					{
						int count = int.Parse(s.Trim().Split(' ')[0]);
						switch (s.Trim().Split(' ')[0])
						{
							case "red":
								red += count;
								break;
							case "green":
								green += count;
								break;
							case "blue":
								blue += count;
								break;
						}
					}
					if (red > minRed)
						minRed = red;
					if (green > minGreen)
						minGreen = green;
					if (blue > minBlue)
						minBlue = blue;

					Console.Write($"{gameId}: [Red: {red} Green: {green} Blue: {blue}]");


					if (red > 12 || green > 13 || blue > 14)
					{
						Console.Write(" - Invalid");
						invalid = true;
					}
					Console.Write("\n");
				}

				if (!invalid)
				{
					sum += gameId;
				}

				Console.WriteLine(sum);

				if (minRed == 0)
					minRed = 1;
				if (minGreen == 0)
					minGreen = 1;
				if (minBlue == 0)
					minBlue = 1;

				Console.WriteLine("total:" + ((minRed * minGreen * minBlue)));
				powersums.Add(minRed * minGreen * minBlue);
			}

			for (int i = 0; i < powersums.Count; i++)
			{
				if (powersums[i] > 0)
				{
					powerSum += powersums[i];
				}
			}



			Console.WriteLine(powerSum);
		}
	}
}