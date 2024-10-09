using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;

namespace AdventOfCode2020Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> seats = new List<string>();
            List<int> seatIds = new List<int>();

            using (var stream = new StreamReader("data.txt"))
            {
                while (!stream.EndOfStream)
                {
                    seats.Add(stream.ReadLine());
                }
            }


            foreach (string seat in seats)
            {
                int top = 127;
                int bottom = 0;

                for (int i = 0; i < seat.Length - 3; i++)
                {
                    switch (seat[i])
                    {
                        case 'F':
                            top = (int)Math.Floor((decimal)((top + bottom) / 2));
                            break;
                        case 'B':
                            bottom = (int)Math.Ceiling((decimal)((top + bottom) / 2));
                            break;
                    }
                }
                int row = top;

                int right = 7;
                int left = 0;
                string leftRight = seat.Substring(7);

                for (int i = 0; i < leftRight.Length; i++)
                {
                    switch (leftRight[i])
                    {
                        case 'R':
                            left = (int)Math.Ceiling((decimal)(left + right) / 2);
                            break;
                        case 'L':
                            right = (int)Math.Floor((decimal)(left + right) / 2);
                            break;
                    }
                }
                int column = right;
                int seatId = (row * 8) + column;
                seatIds.Add(seatId);
                Console.WriteLine("Row: {0} Column: {1} Seat-Id: {2}", row, column, seatId);
            }

            int highest = 0;
            foreach (int i in seatIds)
            {
                if (i > highest)
                    highest = i;
            }
            Console.WriteLine("Answer: " + highest);




        }
    }
}