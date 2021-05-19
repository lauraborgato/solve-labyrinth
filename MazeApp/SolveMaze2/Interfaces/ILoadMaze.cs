using System.IO;

namespace Maze.Interface
{
    public interface ILoadMaze
    {
        int[,] MazeToSolve { get; set; }
        int StartRow { get; set; }
        int StartCol { get; set; }
        int MAXCOL { get; set; }
        int MAXROW { get; set; }
        void CrateMazeFromFile(StreamReader maze);
        void CreateMaze();
    }
}
