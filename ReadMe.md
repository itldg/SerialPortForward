# 串口转发程序

实现两个串口间数据转发,并展示通讯过程

方便做数据获取使用

### 界面演示

![主界面](docs/main.png '主界面')

![自动应答](docs/data.png '自动应答')

![位分析](docs/bit.png '位分析')

### 实现功能

-   串口转发(自定义设置分包合并和轮询)
-   协议记录,支持编辑自动回复
-   定时发送和手动发送消息给串口
-   发送数据自动计算校验,可自己开发校验插件
-   自定义消息处理插件,可以对消息记录或者整理后再进行转发

### 插件方法

插件示例:[仓库地址](/itldg/SerialPortForwardPluginExample)

```csharp
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
```
