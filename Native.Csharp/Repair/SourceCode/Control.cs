using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Native.Csharp.App;

namespace Native.Csharp.Repair.SourceCode
{
    public class Control
    {
        public static List<string> BanQu = new List<string>();
        public static List<string> BanQQ = new List<string>();
        private static readonly string strPath = Common.AppDirectory + "设置.ini";
        public static void GetList()
        {
            int MaxCode = int.Parse(Code.GetConfigItem(strPath, "BanQQ", "MaxCode", "0"));
            for (int i = 1; i <= MaxCode; i++)
            {
                string code = Code.GetConfigItem(strPath, "BanQQ", i.ToString());
                BanQQ.Add(code);
            }
            MaxCode = int.Parse(Code.GetConfigItem(strPath, "BanQu", "MaxCode", "0"));
            for (int i = 1; i <= MaxCode; i++)
            {
                string code = Code.GetConfigItem(strPath, "BanQu", i.ToString());
                BanQu.Add(code);
            }
        }

        /// <summary>
        /// 添加禁止列表
        /// </summary>
        /// <param name="code">QQ号或者QQ群号</param>
        /// <param name="type">类型，1-qq，2-qu</param>
        public static void AddList(string code,int type)
        {
            if (type == 1)
            {
                BanQQ.Add(code);
                int MaxCode = int.Parse(Code.GetConfigItem(strPath, "BanQQ", "MaxCode", "0"))+1;
                Code.AddConfigItem(strPath, "BanQQ", "MaxCode", MaxCode.ToString());
                Code.AddConfigItem(strPath, "BanQQ", MaxCode.ToString(), code);
            }
            else
            {
                BanQu.Add(code);
                int MaxCode = int.Parse(Code.GetConfigItem(strPath, "BanQu", "MaxCode", "0")) + 1;
                Code.AddConfigItem(strPath, "BanQu", "MaxCode", MaxCode.ToString());
                Code.AddConfigItem(strPath, "BanQu", MaxCode.ToString(), code);
            }
        }

        public static void DleList()
        {

        }

        public static void UpdateList()
        {

        }
    }
}
