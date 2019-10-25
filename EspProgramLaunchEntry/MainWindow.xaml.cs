using EspProgramLaunchEntry.Utilitys;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Configuration;

using System.Linq;
using System.Collections.Generic;

namespace EspProgramLaunchEntry
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public StartItems StartItemsData;
        private int m_listBoxShowItemsCount = 5;

        private Dictionary<string, String> dictionary = new Dictionary<string, String>();

        private int m_startIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            StartItemsData = UtilityXML.LoadFromXml<StartItems>(@"startItems.xml");
            GetListBoxShowItemsCount();
            UpdateListItems(m_startIndex);
        }

        public void GetListBoxShowItemsCount()
        {
            try
            {
                m_listBoxShowItemsCount = Convert.ToInt32(ConfigurationManager.AppSettings["ListBoxShowItemsCount"]);
            }
            catch (Exception)
            {
                m_listBoxShowItemsCount = 5;
            }            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartItemListSelection(object sender, SelectionChangedEventArgs e)
        {
           
        }

        public void UpdateListItems(int start)
        {
            int takeCount = m_listBoxShowItemsCount;
            listBoxStartItems.ItemsSource = StartItemsData.Skip(start).Take(takeCount).ToList();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            //ScrollViewer scrollViewer = FV<ScrollViewer>(this.listBoxStartItems);
            //scrollViewer.PageLeft();
            m_startIndex -= m_listBoxShowItemsCount;
            if (m_startIndex < 0)
            {
                m_startIndex = 0;
            }

            UpdateListItems(m_startIndex);
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            //ScrollViewer scrollViewer = FV<ScrollViewer>(this.listBoxStartItems);
            //scrollViewer.PageRight();
            if (m_startIndex + m_listBoxShowItemsCount < StartItemsData.Count)
            {
                m_startIndex += m_listBoxShowItemsCount;
            }
            UpdateListItems(m_startIndex);
        }

        public static ci FV<ci>(DependencyObject o)
        where ci : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                DependencyObject c = VisualTreeHelper.GetChild(o, i);

                if (c != null && c is ci)
                    return (ci)c;
                else
                {
                    ci cc = FV<ci>(c);

                    if (cc != null)
                        return cc;
                }
            }
            return null;
        }

        private void StackPanel_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StartItem startItem = listBoxStartItems?.SelectedItem as StartItem;
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
    }
}
