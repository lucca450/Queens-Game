using System;
using System.Collections.Generic;
using System.Drawing;

namespace QueensGame
{
    class Board
    {
        private int[,] data;
        private byte size;
        public List<int[]> solutions { get; }
        public List<int> solution { get; }
        private bool finished;

        public Board(byte size)
        {
            this.size = size;
            solutions = new List<int[]>();
            solution = new List<int>();
            finished = false;
        }

        public void InitializeData()
        {
            data = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    data[i, j] = 0;
        }

        private bool PositionAvailable(int i, int j)
        {
            if (!VerifyDownRightLine(i, j)) { return false; }
            if (!VerifyDownLeftLine(i, j)) { return false; }
            if (!VerifyUpRightLine(i, j)) { return false; }
            if (!VerifyUpLeftLine(i, j)) { return false; }

            return true;
        }

        public void FindQueensLocations(bool allSolutions)
        {
            InitializeData();
            FindQueensLocations(0, allSolutions);
        }

        private void FindQueensLocations(int row, bool allSolutions)
        {
            if (!finished)
            {
                for (int col = 0; col < size; col++)
                {

                    if (PositionAvailable(row, col) && !solution.Contains(col + 1))
                    {
                        solution.Add(col + 1);
                        data[row, col] = 1;

                        if (solution.Count == size)
                        {
                            int[] solution_arr = new int[solution.Count];
                            solution.CopyTo(solution_arr);
                            solutions.Add(solution_arr);

                            if (!allSolutions)
                                finished = true;
                        }
                        else
                            FindQueensLocations(row + 1, allSolutions);

                        if (!finished)
                        {
                            if (solution.Count > 0)
                                solution.RemoveAt(solution.Count - 1); // Cul de sac

                            data[row, col] = 0;
                        }
                    }
                }
            }
        }

        private void MakeCoordinatesSure(ref Point nextLocation)
        {
            if (nextLocation.X >= size)
            {
                nextLocation.X = nextLocation.X - size;
            }

            if (nextLocation.Y >= size)
            {
                nextLocation.Y = nextLocation.Y - size;
            }
        }

        private bool VerifyLeftLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyLeftLine(i - 1, j);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyDownLeftLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyDownLeftLine(i - 1, j + 1);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyDownLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyDownLine(i, j + 1);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyDownRightLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyDownRightLine(i + 1, j + 1);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyUpRightLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyUpRightLine(i + 1, j - 1);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyRightLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyRightLine(i + 1, j);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyUpLeftLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyUpLeftLine(i - 1, j - 1);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyUpLine(int i, int j)
        {
            if (i < data.GetLength(0) && i >= 0 && j < data.GetLength(1) && j >= 0)
            {
                if (VerifyCell(i, j))
                    return VerifyUpLine(i, j - 1);
                else
                    return false;
            }
            else
                return true;
        }

        private bool VerifyCell(int i, int j)
        {
            return data[i, j] == 0;
        }
    }
}
