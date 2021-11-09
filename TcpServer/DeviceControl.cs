using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    public class DeviceControl
    {
        public int DeviceId { get; set; }
        public bool LEDStatus { get; set; }
    }

    public class DeviceInfo
    {
        public int DeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public bool LEDStatus { get; set; }
    }
}
