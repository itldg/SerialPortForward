using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortForward
{
    /// <summary>
    /// 串口扩展字段
    /// </summary>
    public class SerialPortInfo:SerialPort
    {
        /// <summary>
        /// 轮询查询时间间隔
        /// </summary>
        public int Timer { get; set; }=0;

        /// <summary>
        /// 分包合并
        /// </summary>
        public int TimeOut { get; set; } = 30;
    }
}
