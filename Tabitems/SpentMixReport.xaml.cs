using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;


namespace Tabitems
{
    /// <summary>
    /// Логика взаимодействия для SpentMixReport.xaml
    /// </summary>
    public partial class SpentMixReport : Window
    {
        string date1;
        string date2;
        string connectionString;
        SqlDataAdapter adapter;
        DataTable spentMixTable;

        public SpentMixReport()
        {
            InitializeComponent();
            connectionString = @"Data Source=ASUSPC\MIXSQL; Initial Catalog=Orders; Integrated Security=SSPI";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dt1 = (DateTime)datePicker1.SelectedDate;
            DateTime dt2 = (DateTime)datePicker2.SelectedDate;
            date1 = dt1.ToString("yyyy-MM-dd");
            date2 = dt2.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string sql = @"select [MixName], sum([Weight]) as [Weight]
from MixesAdd
where OrderId = Any(select id 
from [Order] 
where [orderdate] between CONVERT(DATETIME,'"+ date1 + @"') and CONVERT(DATETIME,'"+ date2 + @"'))
group by [MixName]";
            spentMixTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(spentMixTable);
                spentMixGrid.ItemsSource = spentMixTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }
    }
}
