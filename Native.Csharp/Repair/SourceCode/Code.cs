using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Native.Csharp.App;
using Native.Csharp.Tool.IniConfig.Linq;

namespace Native.Csharp.Repair.SourceCode
{
    public class Code
    {
        /// <summary>
        /// 写配置项
        /// </summary>
        /// <param name="strPath">配置文件名</param>
        /// <param name="SectionName">节名称</param>
        /// <param name="SectionKey">配置项名称</param>
        /// <param name="SectionValue">欲写入的值</param>
        public static void AddConfigItem(string strPath,string SectionName,string SectionKey,string SectionValue)
        {
            IniObject iObject = new IniObject();
            if (File.Exists(strPath))
            {
                iObject = IniObject.Load(strPath, Encoding.Default);
            }
            IniSection iSection = new IniSection(SectionName);
            if (iObject.ContainsKey(SectionName))
            {
                iSection = iObject[SectionName];
            }
            if (iSection.ContainsKey(SectionKey))
            {
                iSection[SectionKey] = new IniValue(SectionValue);
            }
            else
            {
                iSection.Add(SectionKey, SectionValue);
            }
            if (!iObject.ContainsKey(SectionName))
            {
                iObject.Add(iSection);
            }
            iObject.Save(strPath);
        }

        /// <summary>
        /// 读配置项
        /// </summary>
        /// <param name="strPath">配置文件名</param>
        /// <param name="SectionName">节名称</param>
        /// <param name="SectionKey">配置项名称</param>
        /// <param name="DefaultTxt">默认文本</param>
        /// <returns></returns>
        public static string GetConfigItem(string strPath, string SectionName, string SectionKey, string DefaultTxt = "")
        {
            string strItem = DefaultTxt;
            if (File.Exists(strPath))
            {
                IniObject iObject = IniObject.Load(strPath, Encoding.Default);
                if (iObject.ContainsKey(SectionName))
                {
                    IniSection section1 = iObject[SectionName];
                    if (section1.ContainsKey(SectionKey))
                    {
                        strItem = section1[SectionKey].Value;
                    }
                }
            }
            return strItem;
        }


    }
}
