using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Runtime.Intrinsics.Arm;

namespace AdventOfCode2020Day1
{
    internal class Program
    {
        public struct Seat
        {
            public int row;
            public int col;
        }

        static void Main(string[] args)
        {

            List<string> seats = new List<string>();
            Dictionary<int, Seat> keyValuePairs = new Dictionary<int, Seat>();


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

                Seat seat1 = new Seat();
                seat1.row = row;
                seat1.col = column;
                keyValuePairs.Add(seatId, seat1);
            }


            //sort dictionary with seats based on ascending rows
            var tmpSortedSeats = from entry in keyValuePairs orderby entry.Value.row ascending select entry;
            var sortedSeats = tmpSortedSeats.ToDictionary(pair => pair.Key, pair => pair.Value);




            foreach (int key in sortedSeats.Keys)
            {
                Console.WriteLine($"Id:{key} \t row:{sortedSeats[key].row}  \t col:{sortedSeats[key].col}");
            }

        }
    }
}