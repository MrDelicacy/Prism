using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Tabitems
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        public OrderInfo orderInfo { get; private set; }

        public CreateOrder(OrderInfo orderInf)
        {
            InitializeComponent();
            orderInfo = orderInf;
            this.DataContext = orderInfo;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (!validation())
                return;
                this.DialogResult = true;
        }
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            orderInfo.ColorGroup=selectedItem.Text.ToString();
        }

        //функция проверки заполненности полей данных о заказе
        public bool validation()
        {
            if (orderInfo.Client == null|| orderInfo.Auto == null || orderInfo.ColorCode == null || orderInfo.ColorGroup == null || orderInfo.Tare == null)
            {
                MessageBox.Show("Данные о заказе отсутствуют или внесены не полностью", "Предупреждение!",  MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            orderInfo.ThreeStateCoat = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e != null && e.Key == Key.Enter)
            {


                
            }
        }
    }
}
