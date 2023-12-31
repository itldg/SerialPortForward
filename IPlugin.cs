﻿using ITLDG;
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
        string Name { get; }
        /// <summary>
        /// 插件被选中
        /// </summary>
        /// <param name="plugin">插件公用方法</param>
        void Checked(PluginCommon plugin);
        /// <summary>
        /// 插件被取消选中
        /// </summary>
        void UnCheck();
        /// <summary>
        /// 插件处理过程
        /// </summary>
        /// <param name="IsCom1">是否是COM1</param>
        /// <param name="ComName">串口名称</param>
        /// <param name="Bytes">收到的数据</param>
        /// <returns>答复数据,如果返回数组长度大于0则自动答复</returns>
        byte[] GetBytes(bool IsCom1, string ComName, ref byte[] Bytes);
        /// <summary>
        /// 是否存在选项
        /// </summary>
        bool HasOption { get; }
        /// <summary>
        /// 点击了插件选项
        /// </summary>
        void Option();
    }
}
