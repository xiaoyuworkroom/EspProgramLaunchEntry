using EspProgramLaunchEntry.Utilitys;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Configuration;

using System.Linq;

namespace EspProgramLaunchEntry
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public StartItems StartItemsData;
        private int m_listBoxShowItemsCount = 5;

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
            var listBox = sender as ListBox;
            var t = listBox.ActualHeight;
            StartItem startItem = (sender as ListBox)?.SelectedItem as StartItem;
            if (startItem != null)
            {
                try
                {
                    string exePath = startItem.ExePath;
                    Process.Start(exePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("配置文件信息错误: {0}", ex.Message), "异常信息");
                }
            }
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
    }
}
