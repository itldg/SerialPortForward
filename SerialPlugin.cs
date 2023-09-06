using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortForward
{
    public abstract class SerialPlugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public abstract string Name();
        /// <summary>
        /// 插件处理过程
        /// </summary>
        /// <param name="IsCom1">是否是COM1</param>
        /// <param name="ComName">串口名称</param>
        /// <param name="Bytes">收到的数据</param>
        /// <returns>答复数据,如果返回数组长度大于0则自动答复</returns>
        public abstract byte[] GetBytes(bool IsCom1, string ComName, ref byte[] Bytes);
        /// <summary>
        /// 是否存在选项
        /// </summary>
        public abstract bool HasOption();
        /// <summary>
        /// 点击了插件选项
        /// </summary>
        public abstract void Option();
        /// <summary>
        /// 发送数据到串口
        /// </summary>
        /// <param name="isCom1">是否是串口1</param>
        /// <param name="data">要发送的数据</param>

        public virtual void WriteData(bool isCom1,byte[] data)
        {
        }
        
    }
}
