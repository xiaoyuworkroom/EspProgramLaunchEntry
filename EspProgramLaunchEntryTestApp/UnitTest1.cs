using System;
using EspProgramLaunchEntry;
using EspProgramLaunchEntry.Utilitys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EspProgramLaunchEntryTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StartItems startItems = new StartItems();
            UtilityXML.SaveToXml(@"D://Text.xml", startItems, typeof(StartItems));
        }

        [TestMethod]
        public void TestMethod2()
        {
            StartItems startItems = UtilityXML.LoadFromXml<StartItems>(@"D://Text.xml");
            int count = startItems.Count;
        }
    }
}
