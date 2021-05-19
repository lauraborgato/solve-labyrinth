namespace Maze.Model
{
    class Node
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Distance { get; set; }
        public bool Visited { get; set; }
        public bool Unreached { get; set; }
        public Node(int row, int column, int distance)
        {
            Row = row;
            Column = column;
            Distance = distance;
        }
    }
}
