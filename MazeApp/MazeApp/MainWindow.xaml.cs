using System;
using System.Collections.Generic;
using System.Windows;
using MazeApp.ViewModel;
using Microsoft.Win32;

namespace MazeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IViewModelService ViewModelService;
        private OpenFileDialog SelectedFile;

        public MainWindow(IViewModelService viewModelService) 
        {
            ViewModelService = viewModelService;
            InitializeComponent();
            solve.Click += new RoutedEventHandler(solve_maze);
            upload.Click += new RoutedEventHandler(upload_maze);
        }

        private void upload_maze(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt";
            fileDialog.Filter = "Text documents (.txt)|*.txt";
            var result = fileDialog.ShowDialog();
            if (result.GetValueOrDefault())
            {
                SelectedFile = fileDialog;
            }
        }

        private void solve_maze(object sender, RoutedEventArgs e)
        {
            ViewModelService.LoadMazeFromFile(SelectedFile);
            var solvedMaze = ViewModelService.SoveMaze();
            var _maze = new List<int>();
            for (int i = 0; i < ViewModelService.MaXCOL; i++){
                for(int j = 0; j < ViewModelService.MaXROW; j++)
                {
                    _maze.Add(solvedMaze[j, i]);
                }
            }
            mazeResut.ItemsSource = _maze;
        }
    }
}
