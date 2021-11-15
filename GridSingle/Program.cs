using System;
using System.Threading;

namespace GridSingle
{
    class Program
    {

        static int NR = 12 + 2;          //change first value only since arrays surrounded by zeros
        static int NC = 20 + 2;          //same as above
        static int HIGH = 20;
        static int GENS = 10;


        static void Main()
        {
            int[,] start = new int[NR, NC];
            int[,] current = new int[NR, NC];
            int[,] next = new int[NR, NC];
            start = (int[,])initGrid(start, NR, NC);                        
            current = (int[,])initGrid(current, NR, NC);
            next = (int[,])initGrid(next, NR, NC);


            current = Filler(start, NR, NC);

            Console.Write("Gen: 1------------------------------------\n");
            Printer(start, NR, NC);

            for (int i = 1; i < NR - 1; i++)
            {
                for (int j = 1; j < NC - 1; j++)
                {
                    current[i, j] = start[i, j];
                }
            }

            for (int t = 2; t <= GENS; t++)                          
            {
                for (int i = 1; i < NR - 1; i++)
                {
                    for (int j = 1; j < NC - 1; j++)
                    {
                        next[i, j] = Checker(current, i, j);
                    }
                }
                Console.Write("Gen: {0}-------------------------------------\n", t);
                Printer(next, NR, NC);

                for (int i = 1; i < NR - 1; i++)                                   
                {
                    for (int j = 1; j < NC - 1; j++)
                    {
                        current[i, j] = next[i, j];
                    }
                }

            }

        }

        private static int Checker(int[,] arr, int x, int y)
        {
            
            int ans = arr[x, y] + arr[x - 1, y - 1] + arr[x, y - 1] + arr[x + 1, y - 1] + arr[x - 1, y] + arr[x + 1, y] + arr[x - 1, y + 1] + arr[x, y + 1] + arr[x + 1, y + 1];

            Thread.Sleep((ans % 11 * 1500)/1000);

            if (ans % 10 == 0)
            {
                return 0;
            }
            if (ans < 50)
            {
                return arr[x, y] + 3;
            }
            if (ans > 50 && ans < 150)
            {
                if (arr[x, y] - 3 < 0)
                {
                    return 0;
                }
                return arr[x, y] - 3;
            }
            if (ans > 150)
            {
                return 1;
            }
            else
            {
                return 0;
            }
      
        }

        private static void Printer(int[,] start, int NR, int NC)
        {
           for (int row = 1; row < NR - 1; row++)
           {                            
                for (int col = 1; col < NC - 1; col++)
                {
                    Console.Write("{0,3}", start[row, col]);
                }
                Console.WriteLine("");
           } 
        }

        private static int[,] Filler(int[,] start, int NR, int NC)
        {
            var rand = new Random();
            for (int row = 1; row < NR - 1; row++)
            {
                for (int col = 1; col < NC - 1; col++)
                {
                    start[row, col] = rand.Next(HIGH);
                }

             }
             return start;
        }

        private static int[,] initGrid(int[,] start, int NR, int NC)
        {
            
            for (int row = 0; row < NR; row++)
            {
                for (int col = 0; col < NC; col++)
                {
                    start[row, col] = 0;
                }
            }
            return start;
        }
    }
}