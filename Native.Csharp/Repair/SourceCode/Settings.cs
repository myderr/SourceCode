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
            string strPath = Common.AppDirectory + "//设置.ini";
            if (File.Exists(strPath))
            {
                IniObject iObject = IniObject.Load(strPath, Encoding.Default);
                if (iObject.ContainsKey("设置主人"))
                {
                    IniSection section1 = iObject["设置主人"];
                    if (section1.ContainsKey("主人QQ"))
                    {
                        txtMaster.Text = section1["主人QQ"].Value;
                    }
                }
            }
        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            string strPath = Common.AppDirectory + "//设置.ini";
            string strMaster = txtMaster.Text;
            IniObject iObject = new IniObject();
            if (File.Exists(strPath))
            {
                iObject = IniObject.Load(strPath, Encoding.Default);
            }
            IniSection iSection = new IniSection("设置主人");
            iSection.Add("主人QQ", strMaster);
            iObject.Add(iSection);
            iObject.Save(strPath);
            this.Close();
        }
    }
}
