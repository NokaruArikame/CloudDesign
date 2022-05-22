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
using ClientWPF.SimpleService;
using ClientWPF.Model;
using Newtonsoft.Json;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ArchiveFolder> archiveFolders;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string foldersJson;
            using(var client = new SimpleServiceClient())
            {
                foldersJson = 
                    client.GetFoldersJson(int.Parse(TestTextBox.Text));
            }
            TestTextBlock.Text = foldersJson;
            archiveFolders = JsonConvert.DeserializeObject<List<ArchiveFolder>>(foldersJson);
            TestTreeView.DataContext = archiveFolders;
        }
    }
}
