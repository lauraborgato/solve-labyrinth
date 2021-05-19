using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Maze.Interface;
using MazeApp.ViewModel;
using SolveMaze;

namespace MazeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer serviceProvider;

        public App()
        {
            var services = new ServiceModule();
            var builder = new ContainerBuilder();
            builder.RegisterModule(services);
            builder.Register(c => new ViewModelService(c.Resolve<ISolveMaze>(), c.Resolve<ILoadMaze>())).As<IViewModelService>();
            builder.Register(c => new MainWindow(c.Resolve<IViewModelService>())).SingleInstance();
            serviceProvider = builder.Build();
           
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            serviceProvider.Resolve<MainWindow>().Show();
        }
    }
}
