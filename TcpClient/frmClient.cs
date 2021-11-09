using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClient
{
    public partial class frmClient : Form
    {
        Socket ClientSocket;

        public frmClient()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!chkLEDStatus.Checked)
                return;

            var rnd = new Random();
            txtTemperature.Text = rnd.Next(10, 30).ToString();
            txtHumidity.Text = rnd.Next(10, 100).ToString();
            
            SendDeviceInfo(); //서버로 장치 정보를 전송
        }

        private void SendDeviceInfo()
        {
            //소켓 객체가 생성되어 있고, 서버와 연결되어 있는 경우
            if (ClientSocket == null || !ClientSocket.Connected)
                return;

            try
            {
                //1.전송할 데이터를 엔터티 객체에 넣어서 준비
                var info = new DeviceInfo
                {
                    DeviceId = 1,
                    Temperature = Convert.ToDouble(txtTemperature.Text),
                    Humidity = Convert.ToDouble(txtHumidity.Text),
                    LEDStatus = chkLEDStatus.Checked
                };

                //2. 객체를 Json 문자열로 직렬화
                string json = JsonConvert.SerializeObject(info);

                //3. 문자열을 byte배열로 변환
                byte[] bytesToSend = Encoding.UTF8.GetBytes(json);

                //4. SocketAsyncEventArgs 객체에 전송할 데이터를 설정
                var args = new SocketAsyncEventArgs();
                args.SetBuffer(bytesToSend, 0, bytesToSend.Length);

                //5. 비동기적으로 전송
                ClientSocket.SendAsync(args);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(IPAddress.Parse(txtIpAddress.Text), 10004);
            var args = new SocketAsyncEventArgs();
            args.RemoteEndPoint = endPoint;
            args.Completed += ServerConnected;
            ClientSocket.ConnectAsync(args);
        }

        private void ServerConnected(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                //서버에 성공적으로 연결된 경우, 서버로부터
                //제어 요청을 받도록 함
                ReceiveControl();
            }
        }

        private void ReceiveControl()
        {
            var args = new SocketAsyncEventArgs();
            args.SetBuffer(new byte[1024], 0, 1024);
            args.Completed += ControlReceived;
            ClientSocket.ReceiveAsync(args);
        }

        private void ControlReceived(object sender, SocketAsyncEventArgs e)
        {
            string json = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);
            var control = JsonConvert.DeserializeObject<DeviceControl>(json);

            if (control.DeviceId == 1)
                RefreshLEDStatus(control.LEDStatus);

            ReceiveControl();
        }

        private void RefreshLEDStatus(bool ledStatus)
        {
            Action action = () => { chkLEDStatus.Checked = ledStatus; };
            this.Invoke(action);
        }

        private void chkLEDStatus_CheckedChanged(object sender, EventArgs e)
        {
            SendDeviceInfo();
        }
    }
}
