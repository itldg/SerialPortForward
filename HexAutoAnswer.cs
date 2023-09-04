using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortForward
{
    public partial class HexAutoAnswer : UserControl
    {
        public delegate void RemoveSelf(HexAutoAnswer hexAutoAnswer);
        /// <summary>
        /// 移除数据
        /// </summary>
        public event RemoveSelf RemoveSelfEvent;
        /// <summary>
        /// 是否全部是HEX数据
        /// </summary>
        public bool IsHex { get { return txtReceiv.IsHex() && txtReply.IsHex(); } }
        /// <summary>
        /// 收到HEX数据
        /// </summary>
        public string Receiv
        {
            get
            {
                return txtReceiv.Text;
            }
            set
            {
                txtReceiv.Text = value;
            }
        }
        /// <summary>
        /// 回复HEX数据
        /// </summary>
        public string Reply
        {
            get
            {
                return txtReply.Text;
            }
            set
            {
                txtReply.Text = value;
            }
        }
        /// <summary>
        /// 收到HEX数据
        /// </summary>
        public string ReceivHex
        {
            get
            {
                return txtReceiv.HexText;
            }
        }
        /// <summary>
        /// 回复HEX数据
        /// </summary>
        public string ReplyHex
        {
            get
            {
                return txtReply.HexText;
            }
        }
        public HexAutoAnswer()
        {
            InitializeComponent();
        }
        public HexAutoAnswer(string Receiv, string Reply)
        {
            InitializeComponent();
            txtReceiv.Text = Receiv;
            txtReply.Text = Reply;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSelfEvent?.Invoke(this);
        }
    }
}
