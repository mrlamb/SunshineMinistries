using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace ContactAppWPF.Helpers
{
    [Serializable]
    public class SettingsHelper
    {
        public string AppFont { get; set; }
        public double AppFontSize { get; set; }

        private const string _settingsFileName = "settings.xml";
        private string _settingsPath = AppDomain.CurrentDomain.BaseDirectory +  _settingsFileName;

        public void Save()
        {

            using (StreamWriter sw = File.CreateText(_settingsPath))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(SettingsHelper));
                xmls.Serialize(sw, this);
            }
        }
        public void Read()
        {
            if (File.Exists(_settingsPath))
            {
                using (StreamReader sw = new StreamReader(_settingsPath))
                {
                    XmlSerializer xmls = new XmlSerializer(typeof(SettingsHelper));
                    var tmp = xmls.Deserialize(sw) as SettingsHelper;
                    this.AppFont = tmp.AppFont;
                    this.AppFontSize = tmp.AppFontSize;
                }
            }
            else
            {
                AppFont = "Segoe UI";
                AppFontSize = 12;
            }
        }
    }
}
