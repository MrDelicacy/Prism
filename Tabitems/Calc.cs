using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace Tabitems
{

    // класс содержит даннные о названиях миксов, весе добавленых миксов и пропорции
    public class Mix
    {
        
        //названия миксов
        private string mixName;
        public string MixName
        {
            get { return mixName; }
            set
            {
                mixName = value;
               
            }
        }
        //добавленные миксы
        private double mixAdd;
        public double MixAdd
        {
            get { return mixAdd; }
            set
            {
                mixAdd = value;
               
            }
        }
        //пропорция компонентов
        private double mixPercent_1;
        public double MixPercent_1
        {
            get { return mixPercent_1; }
            set
            {
                mixPercent_1 = value;
            }
        }
        //пропорция компонентов без 177 и 199
        private double mixPercent_2;
        public double MixPercent_2
        {
            get { return mixPercent_2; }
            set
            {
                mixPercent_2 = value;
            }
        }
        //вес микса, потраченный на тест
        private double testWeight;
        public double TestWeight
        {
            get { return testWeight; }
            set
            {
                testWeight = value;
            }
        }

    }

    //класс итераций
    public class Iteration
    {
        public int iterationId;

        public ObservableCollection<Mix> mixes { get; set; }
        public void setMix(string n, double add, double p1, double p2) 
        {
            Mix m = new Mix();
            m.MixName = n;
            m.MixAdd = add;
            m.MixPercent_1 = p1;
            m.MixPercent_2 = p2;
            mixes.Add(m);
        }
        public void setEmpty() 
        {
            for (int i = 0; i < 16; i++)
            {
                Mix m = new Mix();
                m.MixName = $"{i.ToString()}";
                m.MixAdd = 0;
                m.MixPercent_1 = 0;
                m.MixPercent_2 = 0;
                if (i==13)
                    m.MixName = "177";
                if (i == 14)
                    m.MixName = "199";
                if (i == 15)
                    m.MixName = "thin.";
                mixes.Add(m);
            }
        }
        public Iteration()
        {
            mixes = new ObservableCollection<Mix>();
        }
        
    }

    //класс хранения информации о расчетной и реальной массе краски
    public class EstimatedAndRealWeight
    {
        public double tare;
        public double estimatedWeightAfter;
        public double estimatedWeightBefore;
        public double realWeightAfter;
        public double realWeightBefore;
    }


    //класс информации о заказе, используется в CreateOrder
    public class OrderInfo
    {
        private string client;
        public string Client
        {
            get { return client; }
            set
            {
                client = value;
            }
        }
        private string auto;
        public string Auto
        {
            get { return auto; }
            set
            {
                auto = value;
            }
        }
        private string colorGroup;
        public string ColorGroup
        {
            get { return colorGroup; }
            set
            {
                colorGroup = value;
            }
        }
        private string colorCode;
        public string ColorCode
        {
            get { return colorCode; }
            set
            {
                colorCode = value;
            }
        }
        private string tare;
        public string Tare
        {
            get { return tare; }
            set
            {
                tare = value;
            }
        }
        private bool threeStateCoat;
        public bool ThreeStateCoat
        {
            get { return threeStateCoat; }
            set
            {
                threeStateCoat = value;
            }
        }
        public OrderInfo() 
        {
            threeStateCoat = false;
        }
        public OrderInfo(OrderInfo oi)
        {
            Client = oi.Client;
            Auto = oi.Auto;
            ColorGroup = oi.ColorGroup;
            ColorCode = oi.ColorCode;
            Tare = oi.Tare;
            threeStateCoat = false;
        }
    }


    //класс строк заказа
    public class OrdersRow
    {
        private int orderId;
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        private string orderdate;
        public string Orderdate
        {
            get { return orderdate; }
            set { orderdate = value; }
        }
        private string automobile;
        public string Automobile
        {
            get { return automobile; }
            set { automobile = value; }
        }
        private string client;
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        private string colorgroup;
        public string Colorgroup
        {
            get { return colorgroup; }
            set { colorgroup = value; }
        }
        private string colorcode;
        public string Colorcode
        {
            get { return colorcode; }
            set { colorcode = value; }
        }
        private string orderstatus;
        public string Orderstatus
        {
            get { return orderstatus; }
            set { orderstatus = value; }
        }
    }

    public class DataBaseConnection
    {
        
        SqlDataAdapter adapter;
        public DataTable ordersTable;
        string connectionString;

        public int quantityRows;
        public class QueryAttribute
        {
            public string attrKey;
            public string attrValue;
        }



        //функция внесения данных о заказе
        public void InsertIntoOrder(string client,string auto,string colorgroup,string colorcode)
        {

            string dt = DateTime.Now.ToString();
    string sql = @"SELECT TOP (20) [Id]
      ,[orderdate]
      ,[automobile]
      ,[client]
      ,[colorgroup]
      ,[colorcode]
      ,[orderstatus]
      FROM[Orders].[dbo].[Order]";
            ordersTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                DataRow newRow = ordersTable.NewRow();
                newRow["orderdate"] = dt;
                newRow["automobile"] = auto;
                newRow["client"]  = client;
                newRow["colorgroup"] = colorgroup;
                newRow["colorcode"] = colorcode;
                newRow["orderstatus"] = "inwork";
                ordersTable.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция внесения данных о текущей рабочей конфигурации
        //данные с расчетной таблицы заносятся в бд
        public void InsertIntoConfigurateWorkProcess(Order order)
        {
            string sql = @"SELECT TOP (100) [Id]
      ,[OrderId]
      ,[mix_1]
      ,[mix_2]
      ,[mix_3]
      ,[mix_4]
      ,[mix_5]
      ,[mix_6]
      ,[mix_7]
      ,[mix_8]
      ,[mix_9]
      ,[mix_10]
      ,[mix_11]
      ,[mix_12]
      ,[mix_13]
      ,[mix_14]
      ,[mix_15]
      ,[mix_16]
      ,[before_brutto]
      ,[after_brutto]
      FROM[Orders].[dbo].[ConfigurateWorkProcess]";
            ordersTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                DataRow newRow = ordersTable.NewRow();
                newRow["OrderId"] = order.Id;
                newRow["mix_1"] = order.M1;
                newRow["mix_2"] = order.M2;
                newRow["mix_3"] = order.M3;
                newRow["mix_4"] = order.M4;
                newRow["mix_5"] = order.M5;
                newRow["mix_6"] = order.M6;
                newRow["mix_7"] = order.M7;
                newRow["mix_8"] = order.M8;
                newRow["mix_9"] = order.M9;
                newRow["mix_10"] = order.M10;
                newRow["mix_11"] = order.M11;
                newRow["mix_12"] = order.M12;
                newRow["mix_13"] = order.M13;
                newRow["mix_14"] = order.M14;
                newRow["mix_15"] = order.M15;
                newRow["mix_16"] = order.M16;
                newRow["before_brutto"] = order.BeforeBrutto;
                newRow["after_brutto"] = order.AfterBrutto;
        ordersTable.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                //запрос на удаление 5 первых строк
                //DELETE FROM[Orders].[dbo].[ConfigurateWorkProcess]
                //WHERE[Id]= ANY(SELECT TOP (5) [Id]
                //FROM[Orders].[dbo].[ConfigurateWorkProcess]
                //ORDER BY[Id])

                //запрос на удаление всех строк в талице конфигурации
                //DELETE FROM[Orders].[dbo].[ConfigurateWorkProcess]

                //запрос на удаление строки в таблице конфигурации при выполнении команды "шаг назад"
                //DELETE FROM[Orders].[dbo].[ConfigurateWorkProcess]
                //WHERE[Id]= ANY(SELECT TOP (1) [Id]
                //FROM[Orders].[dbo].[ConfigurateWorkProcess]
                //WHERE[OrderId]=137
                //ORDER BY[Id] DESC)

                //запрос на получение количества строк в таблице конфигурации
                //SELECT COUNT([Id]) AS[cnt]
                //FROM[Orders].[dbo].[ConfigurateWorkProcess]

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }



        //функция получения id заказа
        public int ReturnOrderId()
        {
            string sql = @"SELECT TOP (1) [Id]
      FROM[Orders].[dbo].[Order]
      ORDER BY [Id] DESC";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                return (int)ds.Tables[0].Rows[0].ItemArray[0];
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                
            }
        }
        //функция, которая показывает последние 20 заказов
        public void SelectFromOrder(ObservableCollection<OrdersRow> ordersRows)
        {
            string sql = @"SELECT TOP (" + quantityRows.ToString() + @") [Id]
      ,[orderdate]
      ,[automobile]
      ,[client]
      ,[colorgroup]
      ,[colorcode]
      ,[orderstatus]
      FROM[Orders].[dbo].[Order] ORDER BY [Id] DESC";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                DateTime d;
                ordersTable = ds.Tables[0];
                for (int i = 0; i < ordersTable.Rows.Count; i++)
                {
                    OrdersRow oRow = new OrdersRow();
                    oRow.OrderId = Convert.ToInt32(ordersTable.Rows[i].ItemArray[0]);
                    d = (DateTime)ordersTable.Rows[i].ItemArray[1];
                    oRow.Orderdate = d.ToString("d");
                    oRow.Automobile = ordersTable.Rows[i].ItemArray[2].ToString();
                    oRow.Client = ordersTable.Rows[i].ItemArray[3].ToString();
                    oRow.Colorgroup = ordersTable.Rows[i].ItemArray[4].ToString();
                    oRow.Colorcode = ordersTable.Rows[i].ItemArray[5].ToString();
                    oRow.Orderstatus = ordersTable.Rows[i].ItemArray[6].ToString();
                    ordersRows.Add(oRow);
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция, которая показывает последние 20 заказов с параметрами для поиска
        public void SelectFromOrder(string Id, string orderdate, string client, string automobile, string colorgroup, string colorcode, ObservableCollection<OrdersRow> ordersRows)
        {
            string sql = @"SELECT TOP (" + quantityRows.ToString() + @") [Id]
      ,[orderdate]
      ,[automobile]
      ,[client]
      ,[colorgroup]
      ,[colorcode]
      ,[orderstatus]
      FROM[Orders].[dbo].[Order]";

            List<QueryAttribute> queryAttribute = new List<QueryAttribute>();
            if (Id != null && Id != "")
                queryAttribute.Add(new QueryAttribute { attrKey = "[Id]", attrValue = "'"+ Id +"'" });
            if (orderdate != null && orderdate != "")
                queryAttribute.Add(new QueryAttribute { attrKey = "[orderdate]", attrValue = " CONVERT(DATETIME,'" + orderdate +"')" });
            if (client!=null && client !="")
                queryAttribute.Add( new QueryAttribute{ attrKey="[client]", attrValue="'"+ client +"'" });
            if (automobile != null && automobile !="")
                queryAttribute.Add(new QueryAttribute { attrKey = "[automobile]", attrValue ="'"+ automobile+"'" });
            if (colorgroup != null && colorgroup != "")
            {
                if (colorgroup == "белый")
                    colorgroup = "white";
                if (colorgroup == "серый")
                    colorgroup = "grey";
                if (colorgroup == "черный")
                    colorgroup = "black";
                if (colorgroup == "синий" || colorgroup == "голубой")
                    colorgroup = "blue";
                if (colorgroup == "зеленый")
                    colorgroup = "green";
                if (colorgroup == "желтый" || colorgroup == "жёлтый")
                    colorgroup = "yellow";
                if (colorgroup == "оранжевый")
                    colorgroup = "orange";
                if (colorgroup == "красный")
                    colorgroup = "red";
                if (colorgroup == "пурпурный" || colorgroup == "фиолетовый")
                    colorgroup = "purple";
                if (colorgroup == "бежевый")
                    colorgroup = "beige";
                if (colorgroup == "коричневый")
                    colorgroup = "brown";
                queryAttribute.Add(new QueryAttribute { attrKey = "[colorgroup]", attrValue = "'" + colorgroup + "'" });
            }
            if (colorcode != null && colorcode !="")
                queryAttribute.Add(new QueryAttribute { attrKey = "[colorcode]", attrValue = "'"+ colorcode +"'" });
            if (queryAttribute.Count == 1)
                sql += " WHERE " + queryAttribute[0].attrKey + " = " + queryAttribute[0].attrValue;
            if(queryAttribute.Count>1)
            {
                for(int i=0; i< queryAttribute.Count; i++)
                {
                    if(i==0)
                        sql += " WHERE " + queryAttribute[i].attrKey + " = " + queryAttribute[i].attrValue;
                    if(i>0)
                        sql += " AND " + queryAttribute[i].attrKey + " = " + queryAttribute[i].attrValue;
                }
            }
            sql += " ORDER BY [Id] DESC";
               // System.Windows.MessageBox.Show(sql, queryAttribute.Count.ToString());

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                DateTime d;
                for (int i=0; i< ordersTable.Rows.Count; i++) 
                {
                    OrdersRow oRow = new OrdersRow();
                    oRow.OrderId = Convert.ToInt32(ordersTable.Rows[i].ItemArray[0]);
                    d = (DateTime)ordersTable.Rows[i].ItemArray[1];
                    oRow.Orderdate= d.ToString("d");
                    oRow.Automobile= ordersTable.Rows[i].ItemArray[2].ToString();
                    oRow.Client= ordersTable.Rows[i].ItemArray[3].ToString();
                    oRow.Colorgroup= ordersTable.Rows[i].ItemArray[4].ToString();
                    oRow.Colorcode= ordersTable.Rows[i].ItemArray[5].ToString();
                    oRow.Orderstatus= ordersTable.Rows[i].ItemArray[6].ToString();
                    ordersRows.Add(oRow);
                }
                queryAttribute.Clear();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }


        //функция занесения данных о весе миксов в текущей итерации
        public void InsertIntoMixesAdd(int orderId, Iteration it) 
        {
            string sql = @"SELECT TOP (20) [Id]
      ,[OrderId]
      ,[IterationId]
      ,[MixName]
      ,[Weight]
      ,[Proportion1]
      ,[Proportion2]
      ,[Test]
      ,[Column]
      FROM[Orders].[dbo].[MixesAdd]
      ORDER BY [Id] DESC";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                if (it.mixes.Count > 0)
                {
                    for (int i = 0; i < it.mixes.Count; i++)
                    {
                        if (it.mixes[i].MixPercent_1 == 0)
                            continue;
                        else
                        {
                            DataRow newRow = ordersTable.NewRow();
                            newRow["OrderId"] = orderId;
                            newRow["IterationId"] = it.iterationId;
                            newRow["MixName"] = it.mixes[i].MixName;
                            newRow["Weight"] = it.mixes[i].MixAdd;
                            newRow["Proportion1"] = it.mixes[i].MixPercent_1;
                            newRow["Proportion2"] = it.mixes[i].MixPercent_2;
                            newRow["Test"] = it.mixes[i].TestWeight;
                            newRow["Column"] = i;
                            ordersTable.Rows.Add(newRow);
                        }
                    }
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция удаления данных о весе миксов в текущей итерации
        public void DeleteFromMixesAdd(int orderId,int iterationId)
        {
            string sql = @"DELETE FROM[Orders].[dbo].[MixesAdd]
      WHERE [OrderId]=" + orderId.ToString()+ " AND [IterationId]="+ iterationId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция удаления данных о весе миксов в текущем заказе
        public void DeleteMixesAdd(int orderId)
        {
            string sql = @"DELETE FROM[Orders].[dbo].[MixesAdd]
      WHERE [OrderId]=" + orderId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция удаления данных о заказе
        public void DeleteOrder(int orderId)
        {
            string sql = @"DELETE FROM[Orders].[dbo].[Order]
            WHERE [Id]=" + orderId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }


        //функция установки статуса "complete"
        public void CompleteOrder(int orderId)
        {
            string sql = @"UPDATE [Orders].[dbo].[Order]
      SET [orderstatus]='complete'
      WHERE [Id]="+orderId.ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        //функция установки статуса "inwork"
        public void InworkOrder(int orderId)
        {
            string sql = @"UPDATE [Orders].[dbo].[Order]
      SET [orderstatus]='inwork'
      WHERE [Id]=" + orderId.ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        //функция установки статуса "defective"
        public void DefectiveOrder(int orderId)
        {
            string sql = @"UPDATE [Orders].[dbo].[Order]
      SET [orderstatus]='defective'
      WHERE [Id]=" + orderId.ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция обновления поля relatedOrder
        public void UpdateRelatedOrder(int orderId, int relatedOrderId)
        {
            string sql = @"UPDATE [Orders].[dbo].[Order]
      SET [relatedOrder]="+ relatedOrderId.ToString() +
     " WHERE [Id]=" + orderId.ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция редактирования orderInfo
        public void RedactOrderInfo(int orderId, OrderInfo orderInfo)
        {
            string sql = @"UPDATE [Orders].[dbo].[Order]
      SET [automobile]='"+ orderInfo.Auto +"', [client] ='"+ orderInfo.Client + "', [colorgroup] ='"+ orderInfo.ColorGroup +"', [colorcode] = '"+ orderInfo.ColorCode +"' WHERE [Id]=" + orderId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция проверки связанных заказов
        public int ReturnRelatedOrder(int orderId)
        {
            string sql = @"SELECT [relatedOrder]
      FROM[Orders].[dbo].[Order]
      WHERE [Id]="+ orderId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                    return (int)ds.Tables[0].Rows[0].ItemArray[0];
                else return -1;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                if (connection != null)
                    connection.Close();

            }
        }

        //функция заполнения orderInfo для связанного заказа
        public void CreateRelatedOrderInfo(int id, Order or)
        {
            string sql = @"SELECT [automobile]
      ,[client]
      ,[colorgroup]
      ,[colorcode]
      FROM[Orders].[dbo].[Order]
      WHERE [Id]=" + id.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                or.orderInfo.Auto = (string)ds.Tables[0].Rows[0].ItemArray[0];
                or.orderInfo.Client = (string)ds.Tables[0].Rows[0].ItemArray[1];
                or.orderInfo.ColorGroup = (string)ds.Tables[0].Rows[0].ItemArray[2];
                or.orderInfo.ColorCode = (string)ds.Tables[0].Rows[0].ItemArray[3];

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();

            }
        }

        //функция выборки незавершенных заказов
        public void SelectNotComplete(ObservableCollection<OrdersRow> ordersRows)
        {
            string sql = @"SELECT TOP (" + quantityRows.ToString() + @") [Id]
      ,[orderdate]
      ,[automobile]
      ,[client]
      ,[colorgroup]
      ,[colorcode]
      ,[orderstatus]
      FROM[Orders].[dbo].[Order] 
      WHERE [orderstatus]='inwork'
      ORDER BY [Id] DESC";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                for (int i = 0; i < ordersTable.Rows.Count; i++)
                {
                    OrdersRow oRow = new OrdersRow();
                    oRow.OrderId = Convert.ToInt32(ordersTable.Rows[i].ItemArray[0]);
                    oRow.Orderdate = ordersTable.Rows[i].ItemArray[1].ToString();
                    oRow.Automobile = ordersTable.Rows[i].ItemArray[2].ToString();
                    oRow.Client = ordersTable.Rows[i].ItemArray[3].ToString();
                    oRow.Colorgroup = ordersTable.Rows[i].ItemArray[4].ToString();
                    oRow.Colorcode = ordersTable.Rows[i].ItemArray[5].ToString();
                    oRow.Orderstatus = ordersTable.Rows[i].ItemArray[6].ToString();
                    ordersRows.Add(oRow);
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция открытия незавершенного заказа
        public void OpenOrder(Order order)
        {
            string sql = @"SELECT [Id]
      ,[OrderId]
      ,[IterationId]
      ,[MixName]
      ,[Weight]
      ,[Proportion1]
      ,[Proportion2]
      ,[Test]
      ,[Column]
      FROM[Orders].[dbo].[MixesAdd]
      WHERE [OrderId]=" + order.Id.ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                int rowsCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int lastRow = (int)ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1].ItemArray[2] + 1;
                    for (int i = 0; i < lastRow; i++)
                    {
                        //создаем итерацию и заполнякм поля значениями
                        Iteration iteration = new Iteration();
                        iteration.iterationId = i;
                        iteration.setEmpty();
                        while (i == (int)ds.Tables[0].Rows[rowsCount].ItemArray[2])
                        {

                            order.mixesName[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]] = (string)ds.Tables[0].Rows[rowsCount].ItemArray[3];
                            iteration.mixes[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]].MixName = (string)ds.Tables[0].Rows[rowsCount].ItemArray[3];
                            iteration.mixes[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]].MixAdd = (double)ds.Tables[0].Rows[rowsCount].ItemArray[4];
                            iteration.mixes[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]].MixPercent_1 = (double)ds.Tables[0].Rows[rowsCount].ItemArray[5];
                            iteration.mixes[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]].MixPercent_2 = (double)ds.Tables[0].Rows[rowsCount].ItemArray[6];
                            iteration.mixes[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]].TestWeight = (double)ds.Tables[0].Rows[rowsCount].ItemArray[7];
                            order.afterTestMixes[(int)ds.Tables[0].Rows[rowsCount].ItemArray[8]] += (double)ds.Tables[0].Rows[rowsCount].ItemArray[4] - (double)ds.Tables[0].Rows[rowsCount].ItemArray[7];
                            rowsCount++;
                            if (rowsCount == ds.Tables[0].Rows.Count)
                                break;
                        }
                        order.iterations.Add(iteration);
                        order.SelectedIteration = iteration;
                        order.CopyFromIterationsColection(iteration);
                    }
                }
        }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция внесения данных о расчетном и реальном весе краски
        public void InsertIntoTestCosts(int orderId, int itId, EstimatedAndRealWeight estAndReal)
        {
            string sql = @"SELECT TOP (20) [Id]
      ,[OrderId]
      ,[IterationId]
      ,[Tare]
      ,[EstimatedWeightAfter]
      ,[EstimatedWeightBefore]
      ,[RealWeightAfter]
      ,[RealWeightBefore]
      FROM[Orders].[dbo].[TestCosts]
      ORDER BY [Id] DESC";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];

                            DataRow newRow = ordersTable.NewRow();
                            newRow["OrderId"] = orderId;
                            newRow["IterationId"] = itId;
                            newRow["Tare"] = estAndReal.tare;
                            newRow["EstimatedWeightAfter"] = estAndReal.estimatedWeightAfter;
                            newRow["EstimatedWeightBefore"] = estAndReal.estimatedWeightBefore;
                            newRow["RealWeightAfter"] = estAndReal.realWeightAfter;
                            newRow["RealWeightBefore"] = estAndReal.realWeightBefore;
                            ordersTable.Rows.Add(newRow);

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция удаления данных о расчетном и реальном весе краски
        public void DeleteFromTestCosts(int orderId, int itId)
        {
            string sql = @"DELETE FROM[Orders].[dbo].[TestCosts]
      WHERE [OrderId]=" + orderId.ToString() + " AND [IterationId] = " + itId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //функция извлечения данных о расчетном и реальном весе краски
        public void SelectFromTestCosts(int orderId, List<EstimatedAndRealWeight> estAndReal)
        {
            string sql = @"SELECT [Id]
      ,[OrderId]
      ,[IterationId]
      ,[Tare]
      ,[EstimatedWeightAfter]
      ,[EstimatedWeightBefore]
      ,[RealWeightAfter]
      ,[RealWeightBefore]
      FROM[Orders].[dbo].[TestCosts]
      WHERE [OrderId]= " + orderId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);
                ordersTable = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        EstimatedAndRealWeight est = new EstimatedAndRealWeight();
                        est.tare = (double)ds.Tables[0].Rows[i].ItemArray[3];
                        est.estimatedWeightAfter = (double)ds.Tables[0].Rows[i].ItemArray[4];
                        est.estimatedWeightBefore = (double)ds.Tables[0].Rows[i].ItemArray[5];
                        est.realWeightAfter = (double)ds.Tables[0].Rows[i].ItemArray[6];
                        est.realWeightBefore = (double)ds.Tables[0].Rows[i].ItemArray[7];
                        estAndReal.Add(est);
                    }
                }

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        //функция удаления данных о расчетном и реальном весе краски
        public void DeleteFromTestCosts(int orderId)
        {
            string sql = @"DELETE FROM[Orders].[dbo].[TestCosts]
      WHERE [OrderId]=" + orderId.ToString();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                connection.Open();
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public void SortClient(ObservableCollection<OrdersRow> ordersRows)
        {
                string sql = @"SELECT [Id]
      ,[orderdate]
      ,[automobile]
      ,[client]
      ,[colorgroup]
      ,[colorcode]
      ,[orderstatus]
      FROM[Orders].[dbo].[Order] ORDER BY [client]";

                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(sql, connection);
                    adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    connection.Open();
                    adapter.Fill(ds);
                    ordersTable = ds.Tables[0];
                    for (int i = 0; i < ordersTable.Rows.Count; i++)
                    {
                        OrdersRow oRow = new OrdersRow();
                        oRow.OrderId = Convert.ToInt32(ordersTable.Rows[i].ItemArray[0]);
                        oRow.Orderdate = ordersTable.Rows[i].ItemArray[1].ToString();
                        oRow.Automobile = ordersTable.Rows[i].ItemArray[2].ToString();
                        oRow.Client = ordersTable.Rows[i].ItemArray[3].ToString();
                        oRow.Colorgroup = ordersTable.Rows[i].ItemArray[4].ToString();
                        oRow.Colorcode = ordersTable.Rows[i].ItemArray[5].ToString();
                        oRow.Orderstatus = ordersTable.Rows[i].ItemArray[6].ToString();
                        ordersRows.Add(oRow);
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            
        }

        public DataBaseConnection()
        {
            quantityRows = 0;
            connectionString = @"Data Source=ASUSPC\MIXSQL; Initial Catalog=Orders; Integrated Security=SSPI";
        }

    }

}