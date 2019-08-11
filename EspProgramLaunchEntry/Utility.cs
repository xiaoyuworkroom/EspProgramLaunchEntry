using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EspProgramLaunchEntry
{
    public class Utility
    {
        public static BitmapImage CreateBitmapImage(string imgUrl)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(imgUrl);
            bmp.EndInit();

            return bmp;
        }
    }
}
