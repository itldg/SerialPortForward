using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLDG;

namespace SerialPortForward
{
    public partial class FrmBitAnalysis : Form
    {
        List<BitStatus> list = new List<BitStatus>();
        List<byte> listCache = new List<byte>();
        public FrmBitAnalysis()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("请输入要监控的字节索引", "设置索引", "1", -1, -1);
            int byteIndex;
            if (string.IsNullOrEmpty(s) || !int.TryParse(s, out byteIndex) || byteIndex <= 0)
            {
                return;
            }
            AddByte(byteIndex);
            GoToLast();
        }
        void GoToLast()
        {
            tableLayoutPanel1.VerticalScroll.Value = tableLayoutPanel1.VerticalScroll.Maximum;
            if (WindowState != FormWindowState.Maximized)
            {
                Width += 100;
                Width -= 100;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = tableLayoutPanel1.Controls.Count;
            if (count == 0)
            {
                MessageBox.Show("没有可保存的数据");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "配置文件|*.bit";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    BitStatus bitStatus = tableLayoutPanel1.Controls[i] as BitStatus;
                    string line = bitStatus.ByteIndex + "," + bitStatus.Rule + "," + string.Join("|", bitStatus.GetNames());
                    sb.AppendLine(line);
                }
                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                MessageBox.Show("保存成功");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "配置文件|*.bit";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tableLayoutPanel1.Controls.Clear();
                list.Clear();
                listCache.Clear();
                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.SuspendLayout();
                foreach (var item in lines)
                {
                    string[] arr = item.Split(',');
                    if (arr.Length == 3)
                    {
                        string[] arr2 = arr[2].Split('|');
                        if (arr2.Length == 8)
                        {
                            int btyeIndex = int.Parse(arr[0]);
                            AddByte(btyeIndex, arr2, arr[1]);
                        }
                    }
                }
                tableLayoutPanel1.ResumeLayout();
                tableLayoutPanel1.Visible = true;
                GoToLast();

            }
        }
        void AddByte(int Index, string[] names = null, string rule = "")
        {
            BitStatus bitStatus = new BitStatus();
            bitStatus.ByteIndex = Index;
            if (names != null)
            {
                bitStatus.SetNames(names);
            }
            if (!string.IsNullOrEmpty(rule))
            {
                bitStatus.Rule = rule;
            }
            bitStatus.RemoveSelfEvent += (BitStatus bitStatu) =>
            {
                int index = tableLayoutPanel1.Controls.IndexOf(bitStatu);
                list.RemoveAt(index);
                listCache.RemoveAt(index);
                tableLayoutPanel1.Controls.RemoveAt(index);
            };
            tableLayoutPanel1.Controls.Add(bitStatus, 0, tableLayoutPanel1.RowCount - 1);
            bitStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bitStatus.Margin = new Padding(0, 0, 10, 0);
            tableLayoutPanel1.RowCount += 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            list.Add(bitStatus);
            listCache.Add(0);
        }

        public void NewData(byte[] bytes)
        {
            if (list.Count == 0)
            {
                return;
            }
            string hex = bytes.GetString_HEX("");
            for (int i = 0; i < list.Count; i++)
            {
                if (bytes.Length < list[i].ByteIndex)
                {
                    return;
                }
                if (listCache[i] == bytes[list[i].ByteIndex - 1])
                {
                    continue;
                }
                if (!list[i].CheckHex(hex))
                {
                    continue;
                }
                listCache[i] = bytes[list[i].ByteIndex - 1];
                list[i].ByteChange(bytes[list[i].ByteIndex - 1]);
            }
        }

        private void FrmBitAnalysis_Load(object sender, EventArgs e)
        {

        }
    }
}
