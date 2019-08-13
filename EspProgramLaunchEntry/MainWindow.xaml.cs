using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EspProgramLaunchEntry
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public StartItems startItems;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            startItems = new StartItems();
            listBoxStartItems.ItemsSource = startItems;
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

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer scrollViewer = FV<ScrollViewer>(this.listBoxStartItems);
            scrollViewer.PageLeft();
            
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer scrollViewer = FV<ScrollViewer>(this.listBoxStartItems);
            scrollViewer.PageRight();
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
