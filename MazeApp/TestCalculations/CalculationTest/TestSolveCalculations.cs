using Maze.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCalculations.Stubs;

namespace TestCalculations.CalculationTest
{
    [TestClass]
    public class TestSolveCalculations
    {
        [TestMethod]
        public void CalculateMaze()
        {
            var stubLoadService = new StubLoadMaze();
            stubLoadService.CreateMaze();
            var service = new Calculate(stubLoadService);

            var mazeSolution = service.Solve();
            var mazeResolution = stubLoadService.GetSolvedMaze();
            for (int i = 0; i < stubLoadService.MAXCOL; i++)
            {
                for (int j = 0; j < stubLoadService.MAXROW; j++)
                {
                    Assert.AreEqual(mazeResolution[i, j], mazeSolution[i, j]);
                }
            }
        }

        [TestMethod]
        public void CalculateOtherMaze()
        {
            var stubLoadService = new StubLoadMaze();
            stubLoadService.LoadSecondMaze();
            var service = new Calculate(stubLoadService);

            var mazeSolution = service.Solve();
            var mazeResolution = stubLoadService.GetOtherSolvedMaze();
            for (int i = 0; i < stubLoadService.MAXCOL; i++)
            {
                for (int j = 0; j < stubLoadService.MAXROW; j++)
                {
                    Assert.AreEqual(mazeResolution[j, i], mazeSolution[j, i]);
                }
            }
        }
    }
}
