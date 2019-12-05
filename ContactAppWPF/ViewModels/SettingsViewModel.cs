using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ContactAppWPF.ViewModels
{
    class SettingsViewModel : Screen
    {
        private FontFamily _fontSelectedItem;
        private FontStyle _fontSelectedItemFace;
        private BindableCollection<double> _sizes;
        private double _fontSizeSelectedItem;

        public SettingsViewModel()
        {
            _sizes = new BindableCollection<double>(new double[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 22, 24, 26, 27, 28, 29 });
            FontSizeSelectedItem = Application.Current.MainWindow.FontSize;
            FontSelectedItem = Application.Current.MainWindow.FontFamily;
            FontSelectedItemFace = Application.Current.MainWindow.FontStyle;
        }

        public FontFamily FontSelectedItem
        {
            get { return _fontSelectedItem; }
            set
            {
                _fontSelectedItem = value;
                NotifyOfPropertyChange(() => FontSelectedItem);
            }
        }

        public FontStyle FontSelectedItemFace
        {
            get { return _fontSelectedItemFace; }
            set
            {
                _fontSelectedItemFace = value;
                NotifyOfPropertyChange(() => FontSelectedItemFace);
            }
        }

        public double FontSizeSelectedItem
        {
            get { return _fontSizeSelectedItem; }
            set
            {
                _fontSizeSelectedItem = value;
                NotifyOfPropertyChange(() => FontSizeSelectedItem);
            }
        }

        public BindableCollection<double> Sizes
        {
            get { return _sizes; }
        }

        public void Save()
        {
            Application.Current.MainWindow.FontSize = FontSizeSelectedItem;
            Application.Current.MainWindow.FontFamily = FontSelectedItem;
        }

        

    }
}
