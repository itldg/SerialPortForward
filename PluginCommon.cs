using ITLDG.DataCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortForward
{
    public class PluginCommon
    {
        SerialPortInfo com1, com2;
        Action<IPlugin, bool, byte[]> _OnWriteData;
        public PluginCommon(SerialPortInfo com1, SerialPortInfo com2, Action<IPlugin, bool, byte[]> OnWriteData)
        {
            _OnWriteData = OnWriteData;
            this.com1 = com1;
            this.com2 = com2;
        }
        /// <summary>
        /// 发送数据到串口
        /// </summary>
        /// <param name="bytes">要发送的数据</param>
        /// <param name="isCom1">是否是串口1</param>
        public void WriteData(IPlugin plugin, byte[] bytes, bool isCom1 = true)
        {
            _OnWriteData?.Invoke(plugin, isCom1, bytes);
        }
    }
}
