using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortForward
{
    public partial class FrmMoreSerial : Form
    {
        public FrmMoreSerial()
        {
            InitializeComponent();
        }
        SerialPortInfo com1, com2;
        public FrmMoreSerial(ref SerialPortInfo com1, ref SerialPortInfo com2)
        {
            InitializeComponent();
            this.com1 = com1;
            this.com2 = com2;

            ShowPort(com1, cmbCom1Stop, cmbCom1Data, cmbCom1Parity, cbCom1DTR, cbCom1RTS,nudCom1Timer);
            ShowPort(com2, cmbCom2Stop, cmbCom2Data, cmbCom2Parity, cbCom2DTR, cbCom2RTS,nudCom2Timer);
        }
        private void FrmMoreSerial_Load(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePort(com1, cmbCom1Stop, cmbCom1Data, cmbCom1Parity, cbCom1DTR, cbCom1RTS,nudCom1Timer);
            SavePort(com2, cmbCom2Stop, cmbCom2Data, cmbCom2Parity, cbCom2DTR, cbCom2RTS, nudCom2Timer);
            DialogResult = DialogResult.OK;
        }
        void ShowPort(SerialPortInfo sp, ComboBox cmbStop, ComboBox cmbData, ComboBox cmbParity, CheckBox cbDTR, CheckBox cbRTS,NumericUpDown nudTimer)
        {

            switch (sp.StopBits)
            {
                case StopBits.None:
                    break;
                case StopBits.One:
                    cmbStop.SelectedIndex = 0;
                    break;
                case StopBits.Two:
                    cmbStop.SelectedIndex = 2;
                    break;
                case StopBits.OnePointFive:
                    cmbStop.SelectedIndex = 1;
                    break;
                default:
                    break;
            }

            switch (sp.DataBits)
            {
                case 8: cmbData.SelectedIndex = 0; break;
                case 7: cmbData.SelectedIndex = 1; break;
                case 6: cmbData.SelectedIndex = 2; break;
                case 5:
                default:
                    cmbData.SelectedIndex = 3; break;
            }


            switch (sp.Parity)
            {
                case Parity.None:
                    cmbParity.SelectedIndex = 0;
                    break;
                case Parity.Odd:
                    cmbParity.SelectedIndex = 1;
                    break;
                case Parity.Even:
                    cmbParity.SelectedIndex = 2;
                    break;
                case Parity.Mark:
                    cmbParity.SelectedIndex = 3;
                    break;
                case Parity.Space:
                    cmbParity.SelectedIndex = 4;
                    break;
                default:
                    break;
            }

            cbDTR.Checked = sp.DtrEnable;
            cbRTS.Checked = sp.RtsEnable;
            nudTimer.Value=sp.Timer;
        }

        void SavePort(SerialPortInfo sp, ComboBox cmbStop, ComboBox cmbData, ComboBox cmbParity, CheckBox cbDTR, CheckBox cbRTS, NumericUpDown nudTimer)
        {
            switch (cmbStop.SelectedIndex)
            {

                case 1: sp.StopBits = StopBits.OnePointFive; break;
                case 2: sp.StopBits = StopBits.Two; break;
                case 0:
                default:
                    sp.StopBits = StopBits.One; break;
            }

            switch (cmbData.SelectedIndex)
            {

                case 1: sp.DataBits = 7; break;
                case 2: sp.DataBits = 6; break;
                case 3: sp.DataBits = 5; break;
                case 0:
                default:
                    sp.DataBits = 8; break;
            }

            switch (cmbParity.SelectedIndex)
            {
                case 1: sp.Parity = Parity.Odd; break;
                case 2: sp.Parity = Parity.Even; break;
                case 3: sp.Parity = Parity.Mark; break;
                case 4: sp.Parity = Parity.Space; break;
                case 0:
                default:
                    sp.Parity = Parity.None; break;
            }

            sp.DtrEnable = cbDTR.Checked;
            sp.RtsEnable = cbRTS.Checked;
            sp.Timer = (int)nudTimer.Value;
        }
    }
}
