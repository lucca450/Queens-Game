using System;
using System.Collections.Generic;

namespace QueensGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Queens' Game");
            int size = 0;
            do
            {
                Console.WriteLine("Please enter the size of the board");
                try
                {
                    size = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Error - Size must be an integer - Error");
                }
            } while (true);

            Console.WriteLine("Do you want all solutions (yes) or only one (no)");
            bool allSolution = Console.ReadLine().ToLower().Equals("yes");
            Console.WriteLine();
                
            Board b = new Board(size);

            b.FindQueensLocations(allSolution);

            int k = 0;
            foreach(int[] solution in b.solutions)
            {
                k++;
                Console.WriteLine("Solution " + k);
                foreach (int row in solution)
                {
                    Console.Write(row + " ");
                }
                Console.WriteLine("\n");

                for(int i = 0; i < solution.Length; i++)
                {
                    for (int j = 0; j < solution.Length; j++)
                    {
                        if (j+1 == solution[i])
                            Console.Write("1 ");
                        else
                            Console.Write("0 ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\n");
            }

            Console.ReadLine();



        }

        private static bool ArrayHasValue(int[] array, int value)
        {
            foreach(int arrayValue in array)
            {
                if (arrayValue == value)
                    return true;
            }
            return false;
        }
    }
}
