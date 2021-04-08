using System;
using System.Collections.Generic;

namespace QueensGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Queens' Game");

            bool allSolution = IsAllSolutionsInput();

            validateByteInput("Choose mode (1- 1 to 10) or (2- custom): ", out byte mode);

            switch (mode)
            {
                case 1:
                    for (byte i = 1; i <= 10; i++)
                    {
                        Utilities.nbStackOverall = 0;
                        FindAndDrawSolutions(i, allSolution);
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    validateByteInput("Please enter the size of the board: ", out byte size);

                    FindAndDrawSolutions(size, allSolution);
                    break;
            }

            Console.ReadLine();
        }

        private static void FindAndDrawSolutions(byte size, bool allSolution = false)
        {
            Board b = new Board(size);

            b.FindQueensLocations(allSolution);

            Console.WriteLine("Size: " + size);

            if (b.solutions.Count == 0)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                DrawSolutions(b.solutions);
            }
        }

        private static void DrawSolutions(Dictionary<int[], int> solutions)
        {
            Console.WriteLine(Utilities.nbStackOverall + " tuples total");
            int k = 0;
            foreach (KeyValuePair<int[], int> solution in solutions)
            {
                k++;
                Console.WriteLine("Solution " + k);
                foreach (int row in solution.Key)
                {
                    Console.Write(row + " ");
                }
                Console.WriteLine(": "  + solution.Value + " tuples\n");

                /*for (int i = 0; i < solution.Key.Length; i++)
                {
                    for (int j = 0; j < solution.Key.Length; j++)
                    {
                        if (j + 1 == solution.Key[i])
                            Console.Write("1 ");
                        else
                            Console.Write("0 ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n");*/
            }
        }

        private static void validateByteInput(string message, out byte size)
        {
            do
            {
                Console.Write(message);
            } while (!byte.TryParse(Console.ReadLine(), out size));
        }

        private static bool IsAllSolutionsInput()
        {
            Console.WriteLine("Do you want all solutions (yes) or only one (no)");
            bool allSolution = Console.ReadLine().ToLower().Equals("yes");
            Console.WriteLine();

            return allSolution;
        }
    }
}
