# ����ת������

ʵ���������ڼ�����ת��,��չʾͨѶ����

���������ݻ�ȡʹ��

### ������ʾ

![������](docs/main.png '������')

![�Զ�Ӧ��](docs/data.png '�Զ�Ӧ��')

![λ����](docs/bit.png 'λ����')

### ʵ�ֹ���

-   ����ת��(�Զ������÷ְ��ϲ�����ѯ)
-   Э���¼,֧�ֱ༭�Զ��ظ�
-   ��ʱ���ͺ��ֶ�������Ϣ������
-   ���������Զ�����У��,���Լ�����У����
-   �Զ�����Ϣ������,���Զ���Ϣ��¼����������ٽ���ת��

### �������

���ʾ��:[�ֿ��ַ](/itldg/SerialPortForwardPluginExample)

```csharp
public interface IPlugin
{
    /// <summary>
    /// �������
    /// </summary>
    string Name { get; }
    /// <summary>
    /// �����ѡ��
    /// </summary>
    /// <param name="plugin">������÷���</param>
    void Checked(PluginCommon plugin);
    /// <summary>
    /// �����ȡ��ѡ��
    /// </summary>
    void UnCheck();
    /// <summary>
    /// ����������
    /// </summary>
    /// <param name="IsCom1">�Ƿ���COM1</param>
    /// <param name="ComName">��������</param>
    /// <param name="Bytes">�յ�������</param>
    /// <returns>������,����������鳤�ȴ���0���Զ���</returns>
    byte[] GetBytes(bool IsCom1, string ComName, ref byte[] Bytes);
    /// <summary>
    /// �Ƿ����ѡ��
    /// </summary>
    bool HasOption { get; }
    /// <summary>
    /// ����˲��ѡ��
    /// </summary>
    void Option();
}
```
