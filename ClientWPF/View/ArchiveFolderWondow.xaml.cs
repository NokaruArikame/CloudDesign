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
using ClientWPF.Model;

namespace ClientWPF.View
{
    /// <summary>
    /// Логика взаимодействия для ArchiveFolderWondow.xaml
    /// </summary>
    public partial class ArchiveFolderWondow : Window
    {
        public ArchiveFolderWondow(IFolder parentFolder)
        {
            
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
