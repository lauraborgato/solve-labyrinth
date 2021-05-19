using System.IO;
using Microsoft.Win32;

namespace MazeApp.ViewModel
{
    public interface IViewModelService
    {
        int MaXCOL { get; set; }
        int MaXROW { get; set; }
        int[,] SoveMaze();
        void LoadMazeFromFile(OpenFileDialog file);
    }
}
