using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortForward
{
    public partial class BitStatus : UserControl
    {
        public delegate void RemoveSelf(BitStatus bitStatus);
        /// <summary>
        /// 移除数据
        /// </summary>
        public event RemoveSelf RemoveSelfEvent;
        int byteIndex = 0;
        /// <summary>
        /// 字节索引
        /// </summary>
        public int ByteIndex { get { return byteIndex; } set { byteIndex = value; lblByteIndex.Text = "字节" + value; } }
        Regex dataRule;
        string rule = "";
        public string Rule
        {
            get { return rule; }
            set
            {
                rule = value; if (string.IsNullOrEmpty(rule)) { lblRule.Text = "任意数据"; }
                else
                {
                    lblRule.Text = value;
                    try
                    {
                        dataRule = new Regex(value, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    }
                    catch (Exception)
                    {

                        dataRule = null;
                    }

                }
            }
        }
        /// <summary>
        /// 检查HEX是否符合规则
        /// </summary>
        /// <param name="hex">要检查的HEX字符串</param>
        /// <returns>是否符合</returns>
        public bool CheckHex(string hex)
        {
            if (dataRule == null)
            {
                return true;
            }
            return dataRule.IsMatch(hex);
        }
        public BitStatus()
        {
            InitializeComponent();
        }

        private void lblBit7Name_DoubleClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string s = Interaction.InputBox("请输入新的标题", "设置标题", label.Text, -1, -1);
            if (!string.IsNullOrEmpty(s))
            {
                label.Text = s;
            }
        }
        public void ByteChange(byte data)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                SetLable(lblBit7Value, (data & 0x80) == 0x80);
                SetLable(lblBit6Value, (data & 0x40) == 0x40);
                SetLable(lblBit5Value, (data & 0x20) == 0x20);
                SetLable(lblBit4Value, (data & 0x10) == 0x10);
                SetLable(lblBit3Value, (data & 0x08) == 0x08);
                SetLable(lblBit2Value, (data & 0x04) == 0x04);
                SetLable(lblBit1Value, (data & 0x02) == 0x02);
                SetLable(lblBit0Value, (data & 0x01) == 0x01);
            });

        }
        void SetLable(Label label, bool value)
        {
            label.Text = value ? "1" : "0";
            if (value)
            {
                label.ForeColor = Color.Red;
            }
            else
            {
                label.ForeColor = Color.Gray;
            }
        }
        public string[] GetNames()
        {
            string[] names = new string[]
            {
                lblBit7Name.Text,
                lblBit6Name.Text,
                lblBit5Name.Text,
                lblBit4Name.Text,
                lblBit3Name.Text,
                lblBit2Name.Text,
                lblBit1Name.Text,
                lblBit0Name.Text
            };
            return names;
        }
        public void SetNames(string[] names)
        {
            if (names.Length != 8)
            {
                return;
            }
            lblBit7Name.Text = names[0];
            lblBit6Name.Text = names[1];
            lblBit5Name.Text = names[2];
            lblBit4Name.Text = names[3];
            lblBit3Name.Text = names[4];
            lblBit2Name.Text = names[5];
            lblBit1Name.Text = names[6];
            lblBit0Name.Text = names[7];
        }

        private void lblRule_DoubleClick(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("只有符合规则的数据才会进行监控,此处可以输入正则表达式,HEX匹配", "匹配规则", rule, -1, -1);
            Rule = s;
        }

        private void llblRemoveSelf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemoveSelfEvent?.Invoke(this);
        }

        private void lblRule_Click(object sender, EventArgs e)
        {

        }
    }
}
