using Native.Csharp.App;
using Native.Csharp.Tool.IniConfig.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Native.Csharp.Repair.SourceCode
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            txtMaster.Text = Code.GetConfigItem(Common.AppDirectory+"设置.ini","设置","主人QQ");
            string Open = Code.GetConfigItem(Common.AppDirectory + "设置.ini", "设置", "开关插件","开启");
            if (Open == "开启")
            {
                radOpen.Checked = true;
            }
            else
            {
                radClose.Checked = true;
            }
        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            string Open = "";
            if (radOpen.Checked)
            {
                Open = "开启";
            }
            else
            {
                Open = "关闭";
            }
            Code.AddConfigItem(Common.AppDirectory + "设置.ini", "设置", "主人QQ", txtMaster.Text);
            Code.AddConfigItem(Common.AppDirectory + "设置.ini", "设置", "开关插件", Open);
            this.Close();
        }
        private void TxtMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            int charCode = (int)e.KeyChar;
            if (charCode == 46 || charCode == 8) return;
            if (charCode < 48 || (charCode > 57 && charCode < 96) || charCode > 105)
            {
                e.Handled = true;
            }
        }
    }
}
