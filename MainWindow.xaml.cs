using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;

using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using WfcLand.Views;

namespace WfcLand
{
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
            { "DeviceScan", typeof(DeviceScan) },
            { "Setting", typeof(Setting) },
            { "Ssh", typeof(Ssh) }
        };

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                SelectMenuByTag("OverView");
            }), DispatcherPriority.Loaded);
        }

        private void SelectMenuByTag(string tag)
        {
            var item = FindMenuItem(NavView.MenuItems, tag)
                    ?? FindMenuItem(NavView.FooterMenuItems, tag);

            if (item != null)
            {
                NavView.SelectedItem = item;
            }
        }

        private NavigationViewItem FindMenuItem(IEnumerable items, string tag)
        {
            foreach (var obj in items)
            {
                if (obj is NavigationViewItem it)
                {
                    if (it.Tag?.ToString() == tag) return it;

                    var child = FindMenuItem(it.MenuItems, tag);
                    if (child != null) return child;
                }
            }
            return null;
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {
                string tag = selectedItem.Tag?.ToString();
                NavView.Header = selectedItem.Content;

                if (!string.IsNullOrEmpty(tag) && _pages.TryGetValue(tag, out Type pageType))
                {
                    ContentFrame.Navigate(pageType);
                }
            }
        }
    }
}