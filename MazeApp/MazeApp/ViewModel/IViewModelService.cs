using System.IO;
using Microsoft.Win32;

namespace MazeApp.ViewModel
{
    public interface IViewModelService
    {
        int MAXCOL { get; set; }
        int MAXROW { get; set; }
        int[,] SoveMaze();
        void LoadMazeFromFile(OpenFileDialog file);
    }
}
