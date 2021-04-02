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

            List<int[,]> solutions = b.FindQueensLocations(allSolution);

            foreach(int[,] solution in solutions)
            {
                Console.WriteLine("Solution " + (solutions.IndexOf(solution) + 1));
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        Console.Write(solution[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.ReadLine();



        }
    }
}
