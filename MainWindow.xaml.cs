using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;

using System.Windows;
using WfcLand.Views;

namespace WfcLand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>
        {
            { "OverView", typeof(OverView) },
            { "SerialMonitor", typeof(SerialMonitor) },
            { "InternetSpeed", typeof(InternetSpeed) },
            { "PasteLists", typeof(PasteLists) },
            { "LiteGrab", typeof(LiteGrab) },
            { "PortScan", typeof(PortScan) },
            {"DeviceScan", typeof(DeviceScan) },
            { "Setting", typeof(Setting) },
            { "Ssh", typeof(Ssh) }
        };

        public MainWindow()
        {
            InitializeComponent();
            // 2. 默认加载首页
            ContentFrame.Navigate(typeof(OverView));
        }

        // 3. 处理菜单点击事件
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            // 判断点击的是否为有效的菜单项
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {
                string tag = selectedItem.Tag?.ToString();
                NavView.Header = selectedItem.Content;
                // 4. 从字典中查找对应的页面并跳转
                if (!string.IsNullOrEmpty(tag) && _pages.TryGetValue(tag, out Type pageType))
                {
                    ContentFrame.Navigate(pageType);
                }
            }
        }

    }
}