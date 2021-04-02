using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace QueensGame
{
    class Board
    {
        public int[,] data;
        private int size;

        public Board(int size)
        {
            this.size = size;
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
            if (!VerifyUpLine(i, j - 1)) { return false; }
            if (!VerifyUpRightLine(i+1, j-1)) { return false; }
            if (!VerifyRightLine(i+1, j)) { return false; }
            if (!VerifyDownRightLine(i+1, j+1)) { return false; }
            if (!VerifyDownLine(i, j+1)) { return false; }
            if (!VerifyDownLeftLine(i-1, j+1)) { return false; }
            if (!VerifyLeftLine(i-1, j)) { return false; }
            if (!VerifyUpLeftLine(i-1, j-1)) { return false; }

            return true;
        }

        public List<int[,]> FindQueensLocations(bool allSolutions)
        {
            List<int[,]> solutions = new List<int[,]>();

            for (int i = 0; i < size; i++)
            {
                InitializeData();

                List<Point> queensPositions = new List<Point>();

                data[0, i] = 1;
                queensPositions.Add(new Point(0, i));

                Point lastPoint = new Point(0, i);
                Point nextLocation;
                while (queensPositions.Count < size)
                {
                    nextLocation = new Point(lastPoint.X + 1, lastPoint.Y + 2);
                    MakeCoordinatesSure(ref nextLocation);

                    if (PositionAvailable(nextLocation.X, nextLocation.Y))
                    {
                        queensPositions.Add(nextLocation);
                        data[nextLocation.X, nextLocation.Y] = 1;
                        lastPoint = nextLocation;
                    }
                    else
                    {
                        Console.WriteLine("Error with location");
                    }
                }

                solutions.Add(data);
                if (!allSolutions)
                    i = size;
            }

            return solutions;
        }

        private void MakeCoordinatesSure(ref Point nextLocation)
        {
            if(nextLocation.X >= size)
            {
                nextLocation.X = nextLocation.X - size;
            }

            if(nextLocation.Y >= size)
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
                    return VerifyUpLeftLine(i-1, j-1);
                else
                    return false;
            }else
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
