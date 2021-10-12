using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace Tabitems
{
   public class Scales
    {
        private bool _continue = false;
        private SerialPort _serialPort;

        Thread readThread;

        public string message;

        public void Start_scales()
        {
  
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
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
            readThread = new Thread(Read);

            _serialPort.Open();
            _continue = true;
            readThread.Start();

            //while (_continue)
            //{
            //    message = Console.ReadLine();

            //    if (stringComparer.Equals("quit", message))
            //    {
            //        _continue = false;
            //    }
            //    else
            //    {

            //    }
            //}

            //readThread.Join();
            //_serialPort.Close();

        }

        public void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                }
                catch (TimeoutException) { }
            }
        }
        //private void Start_Click(object sender, EventArgs e)
        //{

        //    _serialPort.Open();
        //    _continue = true;
        //    readThread.Start();
        //}

        //private void Stop_Click(object sender, EventArgs e)
        //{
        //    _continue = false;
        //    readThread.Join();
        //    _serialPort.Close();
        //}

    }
}
