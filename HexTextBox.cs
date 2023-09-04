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
    public partial class HexTextBox : TextBox
    {
        public HexTextBox()
        {
            InitializeComponent();
            this.TextChanged += HexTextBox_TextChanged;
            this.KeyPress += HexTextBox_KeyPress;
        }

        private void HexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 如果按下了删除键并且删除的是空格，则同时删除其前面的一个字符
            if (e.KeyChar == (char)Keys.Back && this.SelectionStart > 0 && this.Text[this.SelectionStart - 1] == ' ')
            {
                this.SelectionStart -= 2;
                this.SelectionLength = 2;
                this.SelectedText = "";
                e.Handled = true;
            }
        }

        private void HexTextBox_TextChanged(object sender, EventArgs e)
        {
            string hexInput = Text;

            // 移除除了HEX字符之外的所有字符
            hexInput = Regex.Replace(hexInput, "[^0-9a-fA-F]", "");

            // 在每两个字符之间添加一个间距
            StringBuilder spacedHex = new StringBuilder();
            for (int i = 0; i < hexInput.Length; i += 2)
            {
                if (i + 1 < hexInput.Length)
                {
                    spacedHex.Append(hexInput.Substring(i, 2));
                    spacedHex.Append(" ");
                }
                else
                {
                    spacedHex.Append(hexInput.Substring(i));
                }
            }

            // 更新TextBox的文本
            Text = spacedHex.ToString().ToUpper();

            // 设置光标位置为文本末尾
            SelectionStart = Text.Length;
        }
        /// <summary>
        /// 判断是否是HEX字符串,是否已经输入完整
        /// </summary>
        /// <returns>是否是HEX字符串</returns>
        public bool IsHex()
        {
            string hexInput = Text;
            hexInput = Regex.Replace(hexInput, " ", "");
            return hexInput.Length % 2 == 0;
        }
    }
}
