using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EspProgramLaunchEntry
{
    /// <summary>
    /// WindowYongDa.xaml 的交互逻辑
    /// </summary>
    public partial class WindowYongDa : Window
    {

        public StartItems StartItemsData;
        private Dictionary<string, String> dictionary = new Dictionary<string, String>();

        public WindowYongDa()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            StartItemsData = Utilitys.UtilityXML.LoadFromXml<StartItems>(@"startItems.xml");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartProcess(StartItem startItem)
        {
            if (startItem != null)
            {
                try
                {
                    string exePath = startItem.ExePath;
                    String startedInfo = "";

                    if (dictionary.TryGetValue(exePath, out startedInfo))
                    {
                        try
                        {
                            var startedProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName + p.Id == startedInfo);
                            if (startedProcess != null) return;
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(string.Format("配置文件信息错误: {0}", e1.Message), "异常信息");
                        }
                    }
                    if (!exePath.Contains(":"))
                    {
                        var appPath = System.Environment.CurrentDirectory;
                        exePath = string.Format(@"{0}/{1}", appPath, exePath.TrimStart('/'));
                    }

                    var newProcess = Process.Start(exePath);
                    dictionary[startItem.ExePath] = newProcess.ProcessName + newProcess.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("配置文件信息错误: {0}", ex.Message), "异常信息");
                }
            }
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            if (StartItemsData.Count <= 0) return;
            StartProcess(StartItemsData[0]);
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            if (StartItemsData.Count <= 1) return;
            StartProcess(StartItemsData[1]);
        }
    }
}
