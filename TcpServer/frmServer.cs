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

namespace TcpServer
{
    public partial class frmServer : Form
    {
        Socket ServerSocket;
        Socket ClientSocket;

        public frmServer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(IPAddress.Any, Convert.ToInt32(txtPort.Text));
            ServerSocket.Bind(endPoint);
            ServerSocket.Listen(10);
            AcceptClient();
        }

        private void AcceptClient()
        {
            var args = new SocketAsyncEventArgs();
            args.Completed += ClientAccepted;

            ServerSocket.AcceptAsync(args);
            AddLog("서비스가 시작되었습니다.");
        }

        private void ClientAccepted(object sender, SocketAsyncEventArgs e)
        {
            //클라이언트와 연결 완료
            AddLog("클라이언트와 연결되었습니다.");
            //클라이언트를 상대하기 위해서 동적으로 생성된 소켓을
            //멤버변수에 저장
            ClientSocket = e.AcceptSocket;
            ReceiveInfo();
        }

        private void ReceiveInfo()
        {
            var args = new SocketAsyncEventArgs();
            args.SetBuffer(new byte[1024], 0, 1024);
            args.Completed += DataReceived;
            ClientSocket.ReceiveAsync(args);
        }

        private void DataReceived(object sender, SocketAsyncEventArgs e)
        {
            //1. 도착한 바이트 배열을 Json 문자열로 변환
            string json = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);

            //2. Json 문자열을 객체로 역직렬화
            try
            {
                var deviceInfo = JsonConvert.DeserializeObject<DeviceInfo>(json);

                AddLog(json);

                //3. 객체의 내용을 UI에 반영
                RefreshDeviceInfo(deviceInfo);
            }
            catch { }

            //4. 다시 수신 작업 수행
            ReceiveInfo();
        }

        private void RefreshDeviceInfo(DeviceInfo info)
        {
            Action action = () =>
            {
                txtTemperature.Text = info.Temperature.ToString();
                txtHumidity.Text = info.Humidity.ToString();
                chkLEDStatus.Checked = info.LEDStatus;
            };

            this.Invoke(action);
        }



        private void AddLog(string log)
        {
            //메인 스레드에서 UI 속성을 접근하는 로직이 수행되도록
            //위임
            Action action = () => { txtLog.AppendText(log + "\r\n"); };
            this.Invoke(action);
        }

        private void chkLEDStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (ClientSocket == null || !ClientSocket.Connected)
                return;

            //1. 제어정보를 담는 엔터티 객체를 생성하고 초기화
            var control = new DeviceControl
            {
                DeviceId = 1,
                LEDStatus = chkLEDStatus.Checked
            };

            //2. 객체를 직렬화해서 Json 문자열로 변환
            string json = JsonConvert.SerializeObject(control);

            //3. 문자열을 바이트 배열로 변환
            byte[] bytesToSend = Encoding.UTF8.GetBytes(json);

            var args = new SocketAsyncEventArgs();
            args.SetBuffer(bytesToSend, 0, bytesToSend.Length);
            ClientSocket.SendAsync(args);
        }
    }
}
