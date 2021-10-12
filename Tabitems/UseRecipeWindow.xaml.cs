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

namespace Tabitems
{
    /// <summary>
    /// Логика взаимодействия для UseRecipeWindow.xaml
    /// </summary>
    public partial class UseRecipeWindow : Window
    {
        public Order order { get; private set; }
        public UseRecipeWindow(Order or)
        {
            InitializeComponent();
            order = or;
            this.DataContext = order;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
