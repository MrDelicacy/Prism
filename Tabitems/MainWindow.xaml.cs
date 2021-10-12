using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO.Ports;
using System.Threading;

namespace Tabitems
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _continue = false;
        private SerialPort _serialPort;
        Thread readThread;
        private TextBox source;
        public string txt;
        private string tempText;
        public MainWindow()
        {
           
            InitializeComponent();

            //новый объект SerialPort с настройками по умолчанию.
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM7";
            _serialPort.BaudRate = 1200;
            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "Odd", true);
            _serialPort.DataBits = 7;
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One", true);
            _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None", true);

            //права на чтение/запись тайм-аутов
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            DataContext = new AppViewModel();
            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;
            scales_field.Content = "Весы отключены";


        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
                e.Cancel=true;
        }

        private void TextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            source = e.Source as TextBox;
            tempText = source.Text;
            source.Text = "";
        }
        private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            source = e.Source as TextBox;
            if (source.Text == "")
                source.Text = tempText;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_serialPort.IsOpen) { _serialPort.Open(); }
                _continue = true;
                readThread = new System.Threading.Thread(Read);
                readThread.Start();
                scales_field.Content = "Весы подключены";
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            try
            {
                _continue = false;
                readThread.Abort();
                txt = "";
                scales_field.Content = "Весы отключены";
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {

                if (_serialPort.IsOpen)
                    _serialPort.Close();

        }


        private void Read()
        {
            while (_continue)
            {
                try
                {
                    string mess = _serialPort.ReadLine();
                    string resulttxt = "";
                    foreach(char ch in mess) {
                        if (ch == '+' || ch == '-' || ch == ' ' || ch == 'g')
                            continue;
                        else
                            resulttxt += ch.ToString();
                    }
                    txt = resulttxt;
                }
                catch (TimeoutException) { }
            }

        }

        //перемещение фокуса и ввод данных с весов в "добавление" 
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e != null && e.Key == Key.Right)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((Control)e.Source).MoveFocus(request);
            }
            if (e != null && e.Key == Key.Left)
            {
                if (((Control)e.Source).TabIndex != 0)
                {
                    TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Previous);
                    request.Wrapped = true;
                    ((Control)e.Source).MoveFocus(request);
                }
            }
            if (e != null && e.Key == Key.Enter)
            {
                source = e.Source as TextBox;
                source.Text = txt;
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((Control)e.Source).MoveFocus(request);
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e != null && e.Key == Key.Right)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((Control)e.Source).MoveFocus(request);
            }
            if (e != null && e.Key == Key.Left)
            {
                if (((Control)e.Source).TabIndex != 0)
                {
                    TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Previous);
                    request.Wrapped = true;
                    ((Control)e.Source).MoveFocus(request);
                }
            }

        }


    }
}
