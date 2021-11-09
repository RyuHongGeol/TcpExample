using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient
{
    public class DeviceInfo
    {
        public int DeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public bool LEDStatus { get; set; }
    }

    public class DeviceControl
    {
        public int DeviceId { get; set; }
        public bool LEDStatus { get; set; }
    }
}
