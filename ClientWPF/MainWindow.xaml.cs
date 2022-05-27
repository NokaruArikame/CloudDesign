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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientWPF.Model;
using Newtonsoft.Json;
using ClientWPF.CloudService;
using ClientWPF.View;
using ClientWPF.ViewModel;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
            // Here must be Login realization
            CloudView cloudView = new CloudView(this);
            this.Hide();
            cloudView.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
