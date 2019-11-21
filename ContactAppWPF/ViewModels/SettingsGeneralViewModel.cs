using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ContactAppWPF.ViewModels
{
    class SettingsGeneralViewModel
    {
        public void FontSettingsClick()
        {
            System.Windows.Forms.FontDialog fdg = new System.Windows.Forms.FontDialog();
            fdg.Font = new Font(Application.Current.MainWindow.FontFamily.ToString(), (float)Application.Current.MainWindow.FontSize);
            
                
            if (fdg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Application.Current.MainWindow.FontSize = fdg.Font.Size;
                Application.Current.MainWindow.FontFamily = new System.Windows.Media.FontFamily(fdg.Font.Name);
            }
        }
    }
}
