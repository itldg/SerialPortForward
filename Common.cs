using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLDG;

namespace SerialPortForward
{
    public static class Common
    {
        /// <summary>
        /// 将指定的字节数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
        /// </summary>
        /// <param name="value">字节数组。</param>
        /// <param name="separator"></param>
        /// <returns>由以 <see cref="separator"/> 分隔的十六进制对构成的字符串，其中每一对表示 <see cref="value"/> 中对应的元素；例如“7F 2C 4A”。</returns>
        public static string GetString_HEX(this byte[] value, string separator = " ")
        { 
            return BitConverterExtend.GetString_HEX(value, separator);
        }
        /// <summary>
        /// 将指定字节数组中的所有字节解码为一个字符串。
        /// </summary>
        /// <param name="value">要解码的字节序列的字节数组。</param>
        /// <returns>字节序列解码结果的字符串。</returns>
        public static string GetString_UTF8(this byte[] value)
        {
            return BitConverterExtend.GetString_UTF8(value);
        }
        /// <summary>
        /// 将指定字节数组中的所有字节解码为一个字符串。
        /// </summary>
        /// <param name="value">包含要解码的字节序列的字节数组。</param>
        /// <param name="index">要解码的第一个字节的索引。</param>
        /// <param name="count">要解码的字节数。</param>
        /// <returns>包含对指定字节序列进行解码的结果的字符串。</returns>
        public static string GetString_UTF8(this byte[] value, int index, int count)
        {
            return Encoding.UTF8.GetString(value, index, count);
        }
        /// <summary>
        /// 将HEX字符串转换为ASCII码的HEX字符串。
        /// </summary>
        /// <param name="value">HEX字符串</param>
        /// <param name="separator">转换后分隔符</param>
        /// <returns>转换为ASCII码的HEX字符串</returns>
        /// <example>GetString_HEX2ASCII("01 02")//30 31 30 32</example>
        public static string GetString_HEX2ASCII(this string value, string separator = " ")
        {
            return BitConverterExtend.GetString_HEX2ASCII(value, separator);
        }
        /// <summary>
        /// 将ASCII码的HEX字符串转换为HEX字符串。
        /// </summary>
        /// <param name="value">ASCII码的HEX字符串</param>
        /// <param name="separator">转换后分隔符</param>
        /// <returns>HEX字符串</returns>
        /// <example>GetString_HEX2ASCII("30 31 30 32")//01 02</example>
        public static string GetString_ASCII2HEX(this string value)
        {
            return BitConverterExtend.GetString_ASCII2HEX(value);
        }

        /// <summary>
        /// 将指定字符串使用UTF-8编码,编码为字节数组
        /// </summary>
        /// <param name="value">要编码的字符串</param>
        /// <returns>以字节数组的形式返回UTF-8编码后的字符串</returns>
        public static byte[] GetBytes_UTF8(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// 将指定的十六进制字符串转换为它的字节等效表示形式数组。
        /// </summary>
        /// <param name="value">要转换的十六进制字符串(支持的连接符号:" ","\t","-")</param>
        /// <returns>以字节数组的形式返回指定的十六进制字符串。</returns>
        public static byte[] GetBytes_HEX(this string value)
        {
            return BitConverterExtend.GetBytes_HEX(value);
        }
    }
}
