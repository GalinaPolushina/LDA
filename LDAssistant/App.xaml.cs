using LDAssistant.View;
using LDAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LDAssistant
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = new MainVM()
            };
            mainWindow.Show();

            /*var mainWindow = new EditPlanting()
            {
                DataContext = new EditPlantingVM()
            };
            mainWindow.Show();*/

        }


    }
}
