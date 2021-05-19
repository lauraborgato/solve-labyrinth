using System.Collections.Generic;
using System.Linq;
using Maze.Interface;
using Maze.Model;

namespace Maze.Service
{
    public class Calculate : ISolveMaze
    {
        private readonly ILoadMaze LoadMaze;

        public Calculate(ILoadMaze maze)
        {
            this.LoadMaze = maze;
        }
        public int[,] Solve()
        {
            return CalculateMinDistances();
        }

        private int[,] CalculateMinDistances()
        {

            List<Node> stillNotVisited = new List<Node>();
            stillNotVisited.Add(new Node(LoadMaze.StartRow, LoadMaze.StartCol, 0));

            while (stillNotVisited.Count() > 0)
            {
                Node current = stillNotVisited.ElementAt(0);
                stillNotVisited.RemoveAt(0);
                IList<Node> neighbours = GetNeighbours(current);
                foreach (Node neighbour in neighbours)
                {
                    if (IsValid(neighbour))
                    {
                        LoadMaze.MazeToSolve[neighbour.Row, neighbour.Column] = current.Distance + 1;
                        stillNotVisited.Add(neighbour);
                    }

                }
            }
            return LoadMaze.MazeToSolve;
        }

        private IList<Node> GetNeighbours(Node current)
        {
            IList<Node> neighbours = new List<Node>();
            neighbours.Add(new Node(current.Row, current.Column - 1, current.Distance + 1));
            neighbours.Add(new Node(current.Row, current.Column + 1, current.Distance + 1));
            neighbours.Add(new Node(current.Row - 1, current.Column, current.Distance + 1));
            neighbours.Add(new Node(current.Row + 1, current.Column, current.Distance + 1));
            return neighbours;
        }

        private bool IsValid(Node current)
        {
            return NotOutOfBounds(current.Row, current.Column)
                && IsValidCell(current.Row, current.Column);
        }

        private bool IsValidCell(int row, int column)
        {
            return LoadMaze.MazeToSolve[row, column] == 0
                && LoadMaze.MazeToSolve[row, column] != -1
                && LoadMaze.MazeToSolve[row, column] != -2;
        }

        private bool NotOutOfBounds(int row, int column)
        {
            return row >= 0 && row < LoadMaze.MAXROW && column >= 0 && column < LoadMaze.MAXCOL;
        }
    }
}
