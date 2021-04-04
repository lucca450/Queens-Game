using System;
using System.Collections.Generic;

namespace QueensGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Queens' Game");
            validateByteInput("Choose mode (1- 1 to 10) or (2- custom): ", out byte mode);

            switch (mode)
            {
                case 1:
                    for (byte i = 1; i <= 10; i++)
                    {
                        Console.WriteLine("Size: " + i);
                        FindAndDrawSolutions(i);
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    validateByteInput("Please enter the size of the board: ", out byte size);

                    bool allSolution = IsAllSolutionsInput();

                    FindAndDrawSolutions(size, allSolution);
                    break;
            }

            Console.ReadLine();
        }

        private static void FindAndDrawSolutions(byte size, bool allSolution = false)
        {
            Board b = new Board(size);

            b.FindQueensLocations(allSolution);

            if (b.solutions.Count == 0)
            {
                Console.WriteLine("No solution found!");
            }
            else
            {
                DrawSolutions(b.solutions);
            }
        }

        private static void DrawSolutions(List<int[]> solutions)
        {
            int k = 0;
            foreach (int[] solution in solutions)
            {
                k++;
                Console.WriteLine("Solution " + k);
                foreach (int row in solution)
                {
                    Console.Write(row + " ");
                }
                Console.WriteLine("\n");

                for (int i = 0; i < solution.Length; i++)
                {
                    for (int j = 0; j < solution.Length; j++)
                    {
                        if (j + 1 == solution[i])
                            Console.Write("1 ");
                        else
                            Console.Write("0 ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
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
