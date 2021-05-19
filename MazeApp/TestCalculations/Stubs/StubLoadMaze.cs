using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Interface;

namespace TestCalculations.Stubs
{
    class StubLoadMaze : ILoadMaze
    {
        public int[,] MazeToSolve { get; set; }
        public int StartRow { get; set; }
        public int StartCol { get; set; }
        public int MAXCOL { get; set; }
        public int MAXROW { get; set; }

        public void CrateMazeFromFile(StreamReader file)
        {
            StartRow = 7;
            StartCol = 0;
           
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

        public int[,] GetSolvedMaze()
        {
            return new int[,]  {
                {13,12,11,12,13,14,15,14},
                {14,-1,10,-1,14,-1,-1,13},
                {-1,-1,9,-1,-1,-1,11,12},
                {6,7,8,7,8,9,10,-1},
                {5,-1,-1,6,-1,-1,11,12},
                {4,3,4,5,-1,-1,-1,13},
                {-1,2,-1,6,-1,10,11,12},
                {-2,1,-1,7,8,9,-1,13},
            };
        }

        public int[,] GetOtherSolvedMaze()
        {
            return new int[,]   {
                { 5, -1, 9,  8, -1 },
                { 4, -1, -1, 7, -1 },
                { 3,  4, 5,  6, 7 },
                { 2, -1, -1, -1, 8 },
                { 1,  2, -1,  10,  9 },
                { -2, -1, -1, -1, 10 },
            };
        }

        public void LoadSecondMaze()
        {
            StartRow = 5;
            StartCol = 0;
            MAXCOL = 5;
            MAXROW = 6;
            int[,] imageMapExample = {
                { 0, -1, 0,  0, -1 },
                { 0, -1, -1, 0, -1 },
                { 0,  0, 0,  0, 0 },
                { 0, -1, -1, -1, 0 },
                { 0,  0, -1,  0,  0 },
                { -2, -1, -1, -1, 0 },
            };
            MazeToSolve = imageMapExample;
        }
    }
}
