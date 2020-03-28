using System;
namespace MapsCore
{
    public class Grid
    {
        private const string WALL = "W";
        private const string EMPTY = " ";
        private const string CORRIDOR = "C";

        private string[][] grid;
        public int Width { get; }
        public int Height { get; }


        public Grid(string[] strings)
        {
            Height = strings.Length;
            Width = strings[0].Length;
        
            grid = new string[Height][];
            
            for(int y = 0; y<Height; y++)
            {
                grid[y] = new string[Width];
                string inputRow = strings[y];
                for(int x=0; x< inputRow.Length; x++)
                {
                    grid[y][x] = ""+inputRow[x];
                }
            }
        }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            grid = new string[height][];
            for (int y = 0; y < height; y++)
            {
                grid[y] = new string[width];
                for(int x = 0; x < width; x++)
                {
                    grid[y][x] = EMPTY;
                }
            }
        }

        public void PutVisited(int x, int y)
        {
            grid[y][x] = "*";
        }

        public void PutWall(int x, int y)
        {
            grid[y][x] = WALL;
        }

        public bool IsWall(int x, int y)
        {
            return grid[y][x] == WALL;
        }

        public void PutCorridor(int x, int y)
        {
            grid[y][x] = CORRIDOR;
        }

        public bool IsCorridor(int x, int y)
        {
            return grid[y][x] == CORRIDOR;
        }

        public bool IsEmpty(int x, int y)
        {
            return grid[y][x] == EMPTY;
        }

        public override string ToString()
        {
            string result = "";
            foreach(string[] row in grid)
            {
                foreach(string tile in row)
                {
                    result += tile;

                }
                result += "\n";
            }
            
            return result;
        }
    }
}
