using System.Windows;
using Autodesk.AutoCAD.Runtime;
using Plagin_AutoCad.View;
using autoDSK = Autodesk.AutoCAD.ApplicationServices.Application;

namespace Plagin_AutoCad
{
    public class StartGUI
    {
        // эта функция будет вызываться при выполнении в AutoCAD команды «TestCommand»
        [CommandMethod("startplagin")]
        public static void StartPlagin()
        {
            MainGUI mainGUI = new MainGUI();
            mainGUI.DataContext = new ViewModel.MainViewModel();
            autoDSK.ShowModelessWindow(mainGUI);
            //nmainGUI.DataContext = new ViewModel.MainViewModel();
            
        }
    }
}
