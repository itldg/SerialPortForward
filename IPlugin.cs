using ITLDG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortForward
{
    public interface IPlugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 插件处理过程
        /// </summary>
        /// <param name="IsCom1">是否是COM1</param>
        /// <param name="ComName">串口名称</param>
        /// <param name="Bytes">收到的数据</param>
        /// <returns>答复数据,如果返回数组长度大于0则自动答复</returns>
        byte[] GetBytes(bool IsCom1, string ComName, ref byte[] Bytes);
    }
}
