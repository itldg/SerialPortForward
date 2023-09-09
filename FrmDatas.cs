using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SerialPortForward
{
    public partial class FrmDatas : Form
    {
        Dictionary<string, string> oldDic;
        public delegate void SaveDatas(Dictionary<string, string> dic);
        /// <summary>
        /// 保存了新的应答数据
        /// </summary>
        public event SaveDatas SaveDatasEvent;
        public FrmDatas(Dictionary<string, string> dic)
        {
            InitializeComponent();
            oldDic = dic;
        }
        void ShowList(Dictionary<string, string> dic)
        {
            foreach (var item in dic)
            {
                AddData(item.Key, item.Value);
            }
        }
        void AddData(string Receiv = "", string Reply = "")
        {


            HexAutoAnswer autoAnswer = new HexAutoAnswer(Receiv, Reply);

            autoAnswer.RemoveSelfEvent += (HexAutoAnswer hexAutoAnswer) =>
            {
                tableLayoutPanel1.Controls.Remove(hexAutoAnswer);
            };
            tableLayoutPanel1.Controls.Add(autoAnswer, 0, tableLayoutPanel1.RowCount - 1);
            autoAnswer.Dock = DockStyle.Fill;
            autoAnswer.BringToFront();


            tableLayoutPanel1.RowCount += 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }
        private void FrmDatas_Load(object sender, EventArgs e)
        {
            ShowList(oldDic);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData();
            GoToLast();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicNew = new Dictionary<string, string>();
            //按照控件顺序倒叙保存
            int max = tableLayoutPanel1.Controls.Count;
            for (int i = max - 1; i >= 0; i--)
            {
                HexAutoAnswer autoAnswer = tableLayoutPanel1.Controls[i] as HexAutoAnswer;
                if (string.IsNullOrEmpty(autoAnswer.ReceivHex) || string.IsNullOrEmpty(autoAnswer.ReplyHex) || !autoAnswer.IsHex)
                {
                    MessageBox.Show("请检查数据全部是否为HEX格式");
                    return;
                }
                dicNew.Add(autoAnswer.ReceivHex, autoAnswer.ReplyHex);
            }


            SaveDatasEvent?.Invoke(dicNew);
            DialogResult = DialogResult.OK;
        }

        private void FrmDatas_Shown(object sender, EventArgs e)
        {
            if (oldDic.Count > 0)
            {
                GoToLast();
            }
        }

        void GoToLast()
        {
            tableLayoutPanel1.VerticalScroll.Value = tableLayoutPanel1.VerticalScroll.Maximum;
            HexAutoAnswer haa = tableLayoutPanel1.Controls[0] as HexAutoAnswer;
            haa.txtReceiv.Focus();
        }
    }
}
