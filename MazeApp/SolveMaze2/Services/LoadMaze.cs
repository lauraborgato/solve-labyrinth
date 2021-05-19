using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Maze.Interface;

namespace Maze.Service
{
    public class LoadMaze : ILoadMaze
    {
        public int[,] MazeToSolve { get; set; }

        public string MazeToLoad { get; set; }
        public int StartRow { get; set; }
        public int StartCol { get; set; }
        public int MAXCOL { get; set; }
        public int MAXROW { get; set; }

        public void CrateMazeFromFile(StreamReader file)
        {
            var maze = file.ReadToEndAsync().Result;
            file.Close();

            var newLine = '\n';
            var rows = maze.Trim().Split(newLine);
            MAXROW = rows.Length;
            MAXCOL = GetColumn(0, rows).Count();
            int[,] loadedMaz = new int[MAXROW, MAXCOL];
            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var cells = GetColumn(rowIndex, rows).ToArray();
                for (int colIndex = 0; colIndex < cells.Length; colIndex++)
                {
                    if (cells[colIndex].Equals("-2"))
                    {
                        StartCol = colIndex;
                        StartRow = rowIndex;
                    }
                    loadedMaz[rowIndex, colIndex] = Convert.ToInt32(cells[colIndex]);
                }
            }
            MazeToSolve = loadedMaz;
        }

        public void CreateMaze()
        {
            StartRow = 7;
            StartCol = 0;
            MAXCOL = 8;
            MAXROW = 8;
            int[,] imageMapExample =
            {
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0, -1,  0, -1,  0, -1, -1,  0 },
                { -1, -1,  0, -1, -1, -1,  0,  0 },
                {  0,  0,  0,  0,  0,  0,  0, -1 },
                {  0, -1, -1,  0, -1, -1,  0,  0 },
                {  0,  0,  0,  0, -1, -1, -1,  0 },
                { -1,  0, -1,  0, -1,  0,  0,  0 },
                { -2,  0, -1,  0,  0,  0, -1,  0 },
            };
            MazeToSolve = imageMapExample;
        }

        private IEnumerable<string> GetColumn(int row, string[] rows)
        {
            return rows[row].Replace("\r", string.Empty)
                    .Trim().Split(',')
                    .Where(elem => !string.IsNullOrEmpty(elem))
                    .Select(elem => elem.Trim());
        }
    }
}
