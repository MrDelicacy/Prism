using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace Tabitems
{
   
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }


        public class AppViewModel:INotifyPropertyChanged
    {
        //подключение к базе данных
        public DataBaseConnection dataBaseConnection;

        //коллекция заказов
        public ObservableCollection<Order> Orders { get; set; }
        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        //список заказов
        public ObservableCollection<OrdersRow> OrdersRows{ get; set; }
        //выбранная строка в списке заказов
        private OrdersRow selectedRow;
        public OrdersRow SelectedRow
        {
            get { return selectedRow; }
            set
            {
                selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }
        //клиент(поиск в списке заказов)
        private string clientField;
        public string ClientField
        {
            get { return clientField; }
            set
            {
                clientField = value;
                OnPropertyChanged("ClientField");
            }
        }
        //марка авто(поиск в списке заказов)
        private string autoField;
        public string AutoField
        {
            get { return autoField; }
            set
            {
                autoField = value;
                OnPropertyChanged("AutoField");
            }
        }
        //id заказа(поиск в списке заказов)
        private string idField;
        public string IdField
        {
            get { return idField; }
            set
            {
                idField = value;
                OnPropertyChanged("IdField");
            }
        }
        //дата заказа(поиск в списке заказов)
        private string dateField;
        public string DateField
        {
            get { return dateField; }
            set
            {
                dateField = value;
                OnPropertyChanged("DateField");
            }
        }
        //код цвета(поиск в списке заказов)
        private string colorcodeField;
        public string ColorcodeField
        {
            get { return colorcodeField; }
            set
            {
                colorcodeField = value;
                OnPropertyChanged("ColorcodeField");
            }
        }
        //цветовая группа(поиск в списке заказов)
        private string colorgroupField;
        public string ColorgroupField
        {
            get { return colorgroupField; }
            set
            {
                colorgroupField = value;
                OnPropertyChanged("ColorgroupField");
            }
        }


        //управление свойством "Visible" кнопки "показать больше"
        private string canPressButton;
        public string CanPressButton
        {
            get { return canPressButton; }
            set
            {
                canPressButton = value;
                OnPropertyChanged("CanPressButton");
            }
        }
        //функция обновления строк заказов
        private void UpdateOrdersRows()
        {
            OrdersRows.Clear();
            dataBaseConnection.quantityRows = 20;
            CanPressButton = "Visible";
            dataBaseConnection.SelectFromOrder(idField, dateField, clientField, autoField, colorgroupField, colorcodeField, OrdersRows);
            if (OrdersRows.Count < dataBaseConnection.quantityRows)
                CanPressButton = "Collapsed";
        }


        //
        private void DisplayMessage(string message)
        {
           // dataBaseConnection.InsertIntoConfigurateWorkProcess(SelectedOrder);
        }



        //команда создания нового заказа
        private RelayCommand addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                return addOrderCommand ??
                    (addOrderCommand = new RelayCommand(obj =>
                    {
                    CreateOrder createOrder = new CreateOrder(new OrderInfo());
                        if (createOrder.ShowDialog() == true)
                        {
                            Order order = new Order();
                            order.orderInfo = createOrder.orderInfo;
                            order.OrderHeader = order.orderInfo.Auto + " " + order.orderInfo.ColorCode;
                            string text = order.orderInfo.Tare;
                            text=text.Replace(".", ",");
                            order.Tare = Convert.ToDouble(text);
                            order.Notify += DisplayMessage;
                            Orders.Add(order);
                            SelectedOrder = order;
                            dataBaseConnection.InsertIntoOrder(order.orderInfo.Client, order.orderInfo.Auto, order.orderInfo.ColorGroup, order.orderInfo.ColorCode);
                            SelectedOrder.Id = dataBaseConnection.ReturnOrderId();//проверить на -1!!!!
                            if(order.orderInfo.ThreeStateCoat==true)
                            {
                                Order or = new Order();
                                or.orderInfo = order.orderInfo;
                                or.OrderHeader = or.orderInfo.Auto + " " + or.orderInfo.ColorCode;
                                dataBaseConnection.InsertIntoOrder(or.orderInfo.Client, or.orderInfo.Auto, or.orderInfo.ColorGroup, or.orderInfo.ColorCode);
                                or.Id = dataBaseConnection.ReturnOrderId();
                                order.Notify += DisplayMessage;
                                Orders.Add(or);
                                dataBaseConnection.UpdateRelatedOrder(order.Id, or.Id);
                                dataBaseConnection.UpdateRelatedOrder(or.Id, order.Id);
                            }
                            UpdateOrdersRows();
                        }
                    }));
            }
        }
        //команда редактирования заказа
        private RelayCommand redactOrderCommand;
        public RelayCommand RedactOrderCommand
        {
            get
            {
                return redactOrderCommand ??
                    (redactOrderCommand = new RelayCommand(obj =>
                    { 

                        Order order = new Order();
                        order.Id = selectedRow.OrderId;
                        order.orderInfo.Auto = selectedRow.Automobile;
                        order.orderInfo.Client = selectedRow.Client;
                        order.orderInfo.ColorCode = selectedRow.Colorcode;
                        order.orderInfo.ColorGroup = selectedRow.Colorgroup;

                        try
                        {
                            dataBaseConnection.OpenOrder(order);
                            CreateOrder createOrder = new CreateOrder(order.orderInfo);
                            if (createOrder.ShowDialog() == true)
                            {

                                dataBaseConnection.RedactOrderInfo(order.Id, createOrder.orderInfo);

                            }

                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message);
                        }

                    }));
            }
        }

        //команда отображения списка заказов
        private RelayCommand viewOrdersCollectionCommand;
        public RelayCommand ViewOrdersCollectionCommand
        {
            get
            {
                return viewOrdersCollectionCommand ??
                    (viewOrdersCollectionCommand = new RelayCommand(obj =>
                    {
                        UpdateOrdersRows();
                    }));
            }
        }

        //команда отображения большего количества строк в списке заказов
        private RelayCommand viewMoreOrdersCollectionCommand;
        public RelayCommand ViewMoreOrdersCollectionCommand
        {
            get
            {
                return viewMoreOrdersCollectionCommand ??
                    (viewMoreOrdersCollectionCommand = new RelayCommand(obj =>
                    {
                        OrdersRows.Clear();
                        dataBaseConnection.quantityRows += 20;
                        dataBaseConnection.SelectFromOrder(idField, dateField, clientField, autoField, colorgroupField, colorcodeField, OrdersRows);
                        if (OrdersRows.Count <dataBaseConnection.quantityRows)
                            CanPressButton = "Collapsed";
                    }));
            }
        }

        //команда выборки незавершенных заказов
        private RelayCommand notCompleteCommand;
        public RelayCommand NotCompleteCommand
        {
            get
            {
                return notCompleteCommand ??
                    (notCompleteCommand = new RelayCommand(obj =>
                    {
                        OrdersRows.Clear();
                        dataBaseConnection.quantityRows = 20;
                        CanPressButton = "Visible";
                        dataBaseConnection.SelectNotComplete(OrdersRows);
                        if (OrdersRows.Count < dataBaseConnection.quantityRows)
                            CanPressButton = "Collapsed";
                    }));
            }
        }

        //команда добавления итерации в таблицу итераций
        private RelayCommand addIterationCommand;
        public RelayCommand AddIterationCommand
        {
            get
            {
                return addIterationCommand ??
                    (addIterationCommand = new RelayCommand(obj =>
                    {
                        SelectedOrder.PercentCalculationOnOf = false;
                        try
                        {
                            if (SelectedOrder.BeforeBrutto > 0 && SelectedOrder.AfterBrutto == 0)
                                
                                SelectedOrder.AfterBrutto = SelectedOrder.BeforeBrutto;
                            SelectedOrder.CopyMixes();
                            SelectedOrder.AddToEstimatedAndRealWeight();
                            SelectedOrder.AddMixCalc();
                            SelectedOrder.IterationCount = SelectedOrder.iterations.Count;
                            SelectedOrder.PlusTare = SelectedOrder.estAndReal[SelectedOrder.estAndReal.Count - 1].realWeightAfter;
                            dataBaseConnection.InsertIntoMixesAdd(SelectedOrder.Id, SelectedOrder.SelectedIteration);
                            dataBaseConnection.InsertIntoTestCosts(SelectedOrder.Id, SelectedOrder.SelectedIteration.iterationId, SelectedOrder.estAndReal[SelectedOrder.estAndReal.Count - 1]);
                            SelectedOrder.currentChanges = false;
                            
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message);
                        }
                        SelectedOrder.PercentCalculationOnOf = true;
                    }));
            }
        }

        //команда отмены итерации
        private RelayCommand cancelIterationCommand;
        public RelayCommand CancelIterationCommand
        {
            get
            {
                return cancelIterationCommand ??
                    (cancelIterationCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            dataBaseConnection.DeleteFromMixesAdd(SelectedOrder.Id, SelectedOrder.SelectedIteration.iterationId);
                            dataBaseConnection.DeleteFromTestCosts(SelectedOrder.Id, SelectedOrder.SelectedIteration.iterationId);
                            SelectedOrder.SubMixCalc(SelectedOrder.iterations[SelectedOrder.iterations.Count-1]);
                            SelectedOrder.BeforeBrutto = SelectedOrder.estAndReal[SelectedOrder.estAndReal.Count - 1].realWeightBefore;
                            SelectedOrder.iterations.Remove(SelectedOrder.SelectedIteration);
                            if (SelectedOrder.iterations.Count > 0)
                            {
                                SelectedOrder.SelectedIteration = SelectedOrder.iterations[SelectedOrder.iterations.Count - 1];
                                SelectedOrder.estAndReal.RemoveAt(SelectedOrder.estAndReal.Count - 1);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        //команда удаление заказа
        private RelayCommand removeFromTheList;
        public RelayCommand RemoveFromTheList
        {
            get
            {
                return removeFromTheList ??
       (removeFromTheList = new RelayCommand(obj =>
       {
           int delOdrerId = selectedRow.OrderId;
           dataBaseConnection.DeleteMixesAdd(delOdrerId);
           dataBaseConnection.DeleteFromTestCosts(delOdrerId);
           dataBaseConnection.DeleteOrder(delOdrerId);
           UpdateOrdersRows();
       }));
            }
        }

        //команда закрытия заказа и удаления вкладки
        private RelayCommand closeOrderCommand;
        public RelayCommand CloseOrderCommand
        {
            get
            {
                return closeOrderCommand ??
                    (closeOrderCommand = new RelayCommand(obj =>
                    {
                        Order order = obj as Order;
                        if (order != null)
                        {
                            if(order.EmptyOrder())
                            {
                                dataBaseConnection.DeleteMixesAdd(order.Id);
                                dataBaseConnection.DeleteFromTestCosts(order.Id);
                                dataBaseConnection.DeleteOrder(order.Id);
                                Orders.Remove(order);
                            }
                            else
                            {
                                if (order.currentChanges == true&&order.SummAddMix != 0)
                                {
                                    if (SelectedOrder.BeforeBrutto > 0 && SelectedOrder.AfterBrutto == 0)
                                        SelectedOrder.AfterBrutto= SelectedOrder.BeforeBrutto;
                                    SelectedOrder.CopyMixes();
                                    SelectedOrder.AddToEstimatedAndRealWeight();
                                    SelectedOrder.AddMixCalc();
                                    dataBaseConnection.InsertIntoMixesAdd(SelectedOrder.Id, SelectedOrder.SelectedIteration);
                                    dataBaseConnection.InsertIntoTestCosts(SelectedOrder.Id, SelectedOrder.SelectedIteration.iterationId, SelectedOrder.estAndReal[SelectedOrder.estAndReal.Count - 1]);
                                    SelectedOrder.currentChanges = false;
                                }
                                Orders.Remove(order);
                            }
                        }
                    }, (obj) => Orders.Count > 0));              
            }          
        }

        //команда завершения заказа
        private RelayCommand orderComplete;
        public RelayCommand OrderComplete
        {
            get
            {
                return orderComplete ??
                    (orderComplete = new RelayCommand(obj =>
                    {
                        Order order = obj as Order;
                        
                        if (order != null)
                        {
                            if (order.EmptyOrder())
                            {
                                dataBaseConnection.DeleteMixesAdd(order.Id);
                                dataBaseConnection.DeleteFromTestCosts(order.Id);
                                dataBaseConnection.DeleteOrder(order.Id);
                                Orders.Remove(order);
                            }
                            else
                            {


                                //если текущий заказ имеет статус "в работе", то вызывать окно завершения заказа
                                //если данные о завершенном заказе имеются в базе, то обновить, если нет, то создать



                                    bool[] serviceInfo = new bool[7];
                                    string orderComment = "";
                                    int rating = 0;
                                    CompleteOrderWindow completeOrderWindow = new CompleteOrderWindow(serviceInfo, orderComment, rating);
                                    if (completeOrderWindow.ShowDialog() == true)
                                    {
                                        if (order.currentChanges == true && order.SummAddMix != 0)
                                        {
                                            if (SelectedOrder.BeforeBrutto > 0 && SelectedOrder.AfterBrutto == 0)
                                                SelectedOrder.AfterBrutto = SelectedOrder.BeforeBrutto;
                                            SelectedOrder.CopyMixes();
                                            SelectedOrder.AddToEstimatedAndRealWeight();
                                            SelectedOrder.AddMixCalc();
                                            dataBaseConnection.InsertIntoMixesAdd(SelectedOrder.Id, SelectedOrder.SelectedIteration);
                                            dataBaseConnection.InsertIntoTestCosts(SelectedOrder.Id, SelectedOrder.SelectedIteration.iterationId, SelectedOrder.estAndReal[SelectedOrder.estAndReal.Count - 1]);
                                            SelectedOrder.currentChanges = false;
                                        }
                                        dataBaseConnection.CompleteOrder(order.Id);
                                        Orders.Remove(order);
                                    }
                                    else
                                        return;
                                    UpdateOrdersRows();
                                
                            }
                        }
                    }, (obj) => Orders.Count > 0));
            }
        }

        //команда установки статуса "complete" в списке заказов
        private RelayCommand selectedOrderComplete;
        public RelayCommand SelectedOrderComplete
        {
            get
            {
                return selectedOrderComplete ??
                    (selectedOrderComplete = new RelayCommand(obj =>
                    {
                        dataBaseConnection.CompleteOrder(selectedRow.OrderId);
                        UpdateOrdersRows();
                    }));
            }
        }
        //команда установки статуса "defective" в списке заказов
        private RelayCommand selectedOrderDefective;
        public RelayCommand SelectedOrderDefective
        {
            get
            {
                return selectedOrderDefective ??
                    (selectedOrderDefective = new RelayCommand(obj =>
                    {
                        dataBaseConnection.DefectiveOrder(selectedRow.OrderId);
                        UpdateOrdersRows();
                    }));
            }
        }

        //команда открыть заказ
        private RelayCommand openOrder;
        public RelayCommand OpenOrder
        {
            get 
            {
                return openOrder ??
                    (openOrder = new RelayCommand(obj =>
                    {
                        Order order = new Order();
                        order.Id = selectedRow.OrderId;
                        order.orderInfo.Auto = selectedRow.Automobile;
                        order.orderInfo.Client = selectedRow.Client;
                        order.orderInfo.ColorCode = selectedRow.Colorcode;
                        order.orderInfo.ColorGroup = selectedRow.Colorgroup;
                        order.OrderHeader = order.orderInfo.Auto + " " + order.orderInfo.ColorCode;
                        order.Notify += DisplayMessage;
                        try
                    {
                        if (selectedRow.Orderstatus == "complete")
                            {
                                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Вернуть его в работу?", "Внимание, заказ завершен!", System.Windows.MessageBoxButton.YesNo);
                                if (result == System.Windows.MessageBoxResult.Yes)
                                {
                                    dataBaseConnection.InworkOrder(selectedRow.OrderId);
                                    UpdateOrdersRows();
                                }
                            }
                            dataBaseConnection.OpenOrder(order);
                            dataBaseConnection.SelectFromTestCosts(order.Id, order.estAndReal);
                            order.Tare = order.estAndReal[order.estAndReal.Count - 1].tare;
                            order.PlusTare = order.estAndReal[order.estAndReal.Count - 1].realWeightBefore;
                            order.IterationCount = order.iterations.Count;
                            Orders.Add(order);
                            SelectedOrder = order;
                            order.PercentCalculationOnOf = false;
                            order.percentCalculation();
                            order.PercentCalculationOnOf = true;
                            int relatedOrderId = dataBaseConnection.ReturnRelatedOrder(order.Id);

                            if (relatedOrderId > 0)
                            {
                                Order or = new Order();
                                or.Id = relatedOrderId;
                                dataBaseConnection.CreateRelatedOrderInfo(relatedOrderId, or);
                                dataBaseConnection.InworkOrder(relatedOrderId);
                                UpdateOrdersRows();

                                dataBaseConnection.OpenOrder(or);
                                dataBaseConnection.SelectFromTestCosts(or.Id, or.estAndReal);
                                or.Tare = or.estAndReal[or.estAndReal.Count - 1].tare;
                                or.PlusTare = or.estAndReal[or.estAndReal.Count - 1].realWeightBefore;
                                or.OrderHeader = or.orderInfo.Auto + " " + or.orderInfo.ColorCode;
                                or.IterationCount = or.iterations.Count;
                                Orders.Add(or);
                                order.PercentCalculationOnOf = false;
                                or.percentCalculation();
                                order.PercentCalculationOnOf = true;
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        //команда использовать рецепт в новом заказе
        private RelayCommand useRecipe;
        public RelayCommand UseRecipe
        {
            get
            {
                return useRecipe ??
                    (useRecipe = new RelayCommand(obj =>
                    {
                        OrderInfo temp = new OrderInfo();
                        temp.Auto = SelectedOrder.orderInfo.Auto;
                        temp.ColorCode = SelectedOrder.orderInfo.ColorCode;
                        temp.ColorGroup = SelectedOrder.orderInfo.ColorGroup;
                        temp.Tare = SelectedOrder.Tare.ToString();
                        CreateOrder createOrder = new CreateOrder(temp);
                        if (createOrder.ShowDialog() == true)
                        {
                            Order order = new Order();
                            UseRecipeWindow recipeWindow = new UseRecipeWindow(SelectedOrder);
                            if (recipeWindow.ShowDialog() == true)
                            {
                                for (int i = 0; i < 14; i++)
                                    order.mixesName[i] = SelectedOrder.mixesName[i];
                                order.M1 = Math.Round(SelectedOrder.Pm1, 1);
                                order.M2 = Math.Round(SelectedOrder.Pm2, 1);
                                order.M3 = Math.Round(SelectedOrder.Pm3, 1);
                                order.M4 = Math.Round(SelectedOrder.Pm4, 1);
                                order.M5 = Math.Round(SelectedOrder.Pm5, 1);
                                order.M6 = Math.Round(SelectedOrder.Pm6, 1);
                                order.M7 = Math.Round(SelectedOrder.Pm7, 1);
                                order.M8 = Math.Round(SelectedOrder.Pm8, 1);
                                order.M9 = Math.Round(SelectedOrder.Pm9, 1);
                                order.M10 = Math.Round(SelectedOrder.Pm10, 1);
                                order.M11 = Math.Round(SelectedOrder.Pm11, 1);
                                order.M12 = Math.Round(SelectedOrder.Pm12, 1);
                                order.M13 = Math.Round(SelectedOrder.Pm13, 1);
                                order.M14 = Math.Round(SelectedOrder.Pm14, 1);
                                order.M15 = Math.Round(SelectedOrder.Pm15, 1);
                                order.M16 = Math.Round(SelectedOrder.Pm16, 1);

                            }
                            else
                                return;
                            order.orderInfo = createOrder.orderInfo;
                            order.OrderHeader = order.orderInfo.Auto + " " + order.orderInfo.ColorCode;
                            SelectedOrder.currentChanges = false;
                            order.Notify += DisplayMessage;
                            dataBaseConnection.InsertIntoOrder(order.orderInfo.Client, order.orderInfo.Auto, order.orderInfo.ColorGroup, order.orderInfo.ColorCode);
                            order.Id = dataBaseConnection.ReturnOrderId(); 
                            Orders.Add(order);
                            SelectedOrder = order;
                        }
                    }));
            }
        }

        //команда использования пропорции
        private RelayCommand useProportion;
        public RelayCommand UseProportion
        {
            get
            {
                return useProportion ??
                    (useProportion = new RelayCommand(obj =>
                    {
                        if (SelectedOrder.iterations.Count > 0)
                        {
                            if(SelectedOrder.BeforeBrutto>0|| SelectedOrder.AfterBrutto>0)
                                System.Windows.MessageBox.Show("Внимание! Не внесены данные итерации.");
                            Proportion proportion = new Proportion(SelectedOrder);
                            UseProportionWindow proportionWindow = new UseProportionWindow(proportion);
                            if (proportionWindow.ShowDialog() == true)
                            {
                                proportion.UseProportion(SelectedOrder);
                            }
                        }
                    }));
            }
        }

        //команда закрыть и отменить
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Вы действительно хотите безвозвратно удалить заказ?", "Внимание!", System.Windows.MessageBoxButton.YesNo);
                        if (result == System.Windows.MessageBoxResult.Yes)
                        {
                            Order order = obj as Order;
                            if (order != null)
                            {
                                dataBaseConnection.DeleteMixesAdd(order.Id);
                                dataBaseConnection.DeleteFromTestCosts(order.Id);
                                dataBaseConnection.DeleteOrder(order.Id);
                                Orders.Remove(order);
                                UpdateOrdersRows();
                            }
                        }
                    }, (obj) => Orders.Count > 0));
            }
        }

        // команда вставки значения в "брутто до"
        private RelayCommand addToPrevious;
        public RelayCommand AddToPrevious
        {
            get
            {
                return addToPrevious ??
                    (addToPrevious = new RelayCommand(obj =>
                    {
                       SelectedOrder.AddToPrevious();
                    }, (obj) => Orders.Count > 0));
            }
        }

        private RelayCommand sortClient;
        public RelayCommand SortClient
        {
            get
            {
                return sortClient ??
                    (sortClient = new RelayCommand(obj =>
                    {
                        OrdersRows.Clear();
                        dataBaseConnection.SortClient(OrdersRows);
                    }));
            }
        }

        //Отчет о потраченных миксах
        private RelayCommand spentMixReportCommand;
        public RelayCommand SpentMixReportCommand
        {
            get
            {
                return spentMixReportCommand ??
                    (spentMixReportCommand = new RelayCommand(obj =>
                    {
                        SpentMixReport report = new SpentMixReport();
                        report.Show();
                    }));
            }

        }

    //конструктор
    public AppViewModel()
        {
            Orders = new ObservableCollection<Order>();
            //Order order = new Order();
            //order.Id = Orders.Count + 1;
            //Orders.Add(order);
            //SelectedOrder = order;
            dataBaseConnection = new DataBaseConnection();
            OrdersRows = new ObservableCollection<OrdersRow>();
            dataBaseConnection.quantityRows = 20;
            dataBaseConnection.SelectFromOrder(OrdersRows);
            if(OrdersRows.Count<20)
                CanPressButton = "Collapsed";
            //CompleteOrderWindow complete = new CompleteOrderWindow();
            //complete.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
