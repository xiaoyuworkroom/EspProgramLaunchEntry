using EspProgramLaunchEntry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EspProgramLaunchEntry
{
    public class StartItem
    {
        public string Name { get; set; }
        public string PicPath { get; set; }
        public string Note { get; set; }
        public string ExePath { get; set; }
    }

    public class StartItemPicPathToPhotoPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = (string)value;
            if(!uriStr.StartsWith("file:///"))
            {
                var appPath = System.Environment.CurrentDirectory;
                uriStr = string.Format(@"file:///{0}/{1}", appPath, uriStr.TrimStart('/'));
            }

            return Utility.CreateBitmapImage(uriStr);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


