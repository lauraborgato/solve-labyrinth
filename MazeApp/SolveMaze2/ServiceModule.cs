using Autofac;
using Maze.Interface;
using Maze.Service;

namespace SolveMaze
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new LoadMaze()).As<ILoadMaze>().SingleInstance();
            builder.Register(c => new Calculate(c.Resolve<ILoadMaze>())).As<ICalculate>();
        }
    }
}
