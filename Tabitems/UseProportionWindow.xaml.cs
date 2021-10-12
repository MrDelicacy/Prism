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
    /// Логика взаимодействия для UseProportionWindow.xaml
    /// </summary>
    public partial class UseProportionWindow : Window
    {
        public Proportion proportion { get; private set; }
        public UseProportionWindow(Proportion p)
        {
            InitializeComponent();
            proportion = p;
            this.DataContext = proportion;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
