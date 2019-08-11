using EspProgramLaunchEntry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            /* 
             * value = "file:///D:/etp/Works/ToolsRepository/EspDemoEntry/photos/fourthlesson.png"
             */
            string uriStr = (string)value;
            return Utility.CreateBitmapImage(uriStr);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


