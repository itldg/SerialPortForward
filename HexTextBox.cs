using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace SerialPortForward
{
    public partial class HexTextBox : TextBox
    {
        /// <summary>
        /// HEX字符串,不包含分隔符
        /// </summary>
        public string HexText { get { return Regex.Replace(Text, "[^0-9a-fA-F]", ""); } }
        public HexTextBox()
        {
            InitializeComponent();
            this.ContextMenu = new ContextMenu();
            this.KeyDown += HexTextBox_KeyDown; ;
            this.TextChanged += HexTextBox_TextChanged;
            this.KeyPress += HexTextBox_KeyPress;
        }
        int lastSelectionStart = 0;
        private void HexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            lastSelectionStart = this.SelectionStart;
        }

        private void HexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 如果按下了删除键并且删除的是空格，则同时删除其前面的一个字符
            if (e.KeyChar == (char)Keys.Back && this.SelectionStart > 0 && this.Text[this.SelectionStart - 1] == ' ')
            {
                lastSelectionStart = this.SelectionStart - 2;
                this.SelectionStart = lastSelectionStart;
                this.SelectionLength = 2;
                this.SelectedText = "";
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                lastSelectionStart = this.SelectionStart - 1;
            }

            else if (IsValidHexChar(e.KeyChar))
            {
                if (this.SelectionStart >= 2 && this.Text[this.SelectionStart - 2] != ' ' && this.Text[this.SelectionStart - 1] != ' ')
                {
                    lastSelectionStart = this.SelectionStart + 2;
                }
                else
                {
                    lastSelectionStart = this.SelectionStart + 1;
                }
            }
            //按下Ctrl+v
            else if (e.KeyChar == 22)
            {
                // 获取剪贴板文本
                string clipboardText = Clipboard.GetText();

                // 删除所有非法字符
                string hexString = string.Concat(clipboardText.Where(c => ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'))));

                // 在每两个字符之间插入一个空格
                hexString = string.Join(" ", Enumerable.Range(0, hexString.Length / 2).Select(i => hexString.Substring(i * 2, 2)));

                // 插入到当前光标位置
                int selectionStart = SelectionStart;
                if (this.SelectionLength > 0) { this.SelectedText = ""; }

                Text = Text.Insert(selectionStart, hexString);
                if (this.SelectionStart > 0 && this.Text[this.SelectionStart - 1] == ' ')
                {
                    SelectionStart = selectionStart + hexString.Length;
                }
                else
                {
                    SelectionStart = selectionStart + hexString.Length + 1;
                }

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
            if (lastSelectionStart >= Text.Length)
            {
                SelectionStart = Text.Length;
            }
            else if (lastSelectionStart >= 0)
            {
                SelectionStart = lastSelectionStart;
            }

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

        private bool IsValidHexChar(char c)
        {
            return "0123456789ABCDEFabcdef".IndexOf(c) >= 0;
        }
    }
}
