using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspProgramLaunchEntry
{
    public class StartItems : ObservableCollection<StartItem>
    {
        public StartItems()
        {
            Add(new StartItem() {
                Name = "name1",
                ////"D:/etp/Projects/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/first.png"
                PicPath = @"file:///D:/etp/Projects/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/first.png",
                ExePath = "" });
            Add(new StartItem() {
                Name = "name2",
                PicPath = @"file:///D:/etp/Projects/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/first.png",
                ExePath = "" });
            Add(new StartItem() {
                Name = "name3",
                PicPath = @"file:///D:/etp/Projects/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/first.png",
                ExePath = "" });
        }
    }
}
