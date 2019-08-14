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
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/firstlesson.png",
                ExePath = "" });
            Add(new StartItem() {
                Name = "name2",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/secondlesson.png",
                ExePath = "" });
            Add(new StartItem() {
                Name = "name3",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/secondlesson.png",
                ExePath = "" });
            Add(new StartItem()
            {
                Name = "name3",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/secondlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name1",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/firstlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name2",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/secondlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name3",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/thirdlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name3",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/fourthlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name1",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/firstlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name2",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/secondlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name3",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/thirdlesson.png",
                ExePath = ""
            });
            Add(new StartItem()
            {
                Name = "name3",
                PicPath = @"file:///C:/zxhome/Works/EspProgramLaunchEntry/EspProgramLaunchEntry/Photos/fourthlesson.png",
                ExePath = ""
            });
        }
    }
}
