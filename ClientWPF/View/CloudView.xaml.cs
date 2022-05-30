using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClientWPF.ViewModel;

namespace ClientWPF.View
{
    /// <summary>
    /// Логика взаимодействия для CloudView.xaml
    /// </summary>
    public partial class CloudView : Window
    {
        MainWindow mainWindow;
        public CloudView(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.DataContext = new CloudViewModel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mainWindow.Close();
        }
    }
}
