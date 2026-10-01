using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WfcLand.Controls
{
    /// <summary>
    /// CardControl.xaml 的交互逻辑
    /// </summary>
    public partial class CardControl : UserControl
    {
        public static readonly DependencyProperty IconProperty =
   DependencyProperty.Register("Icon", typeof(string), typeof(CardControl), new PropertyMetadata("&#xE799;"));

        public static readonly DependencyProperty TitleProperty =
   DependencyProperty.Register("Title", typeof(string), typeof(CardControl), new PropertyMetadata("FTP"));

        public static readonly DependencyProperty DescriptionProperty =
   DependencyProperty.Register("Description", typeof(string), typeof(CardControl), new PropertyMetadata("这是一个FTP功能介绍"));

        public static readonly DependencyProperty NavigateTagProperty =
  DependencyProperty.Register("NavigateTag", typeof(string), typeof(CardControl), new PropertyMetadata(""));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
        public string NavigateTag
        {
            get => (string)GetValue(NavigateTagProperty);
            set => SetValue(NavigateTagProperty, value);
        }
        private void SettingsCardNavigate(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NavigateTag) &&
                Window.GetWindow(this) is MainWindow main)
            {
                main.NavigateTo(NavigateTag);
            }
            Debug.WriteLine("sdsada撒大苏打");

        }
        public CardControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
