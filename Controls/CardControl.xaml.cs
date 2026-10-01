using System;
using System.Collections.Generic;
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
   DependencyProperty.Register("Icon", typeof(string), typeof(DropdownLabel), new PropertyMetadata("&#xE799;"));

        public static readonly DependencyProperty TitleProperty =
   DependencyProperty.Register("Title", typeof(string), typeof(DropdownLabel), new PropertyMetadata("FTP"));

        public static readonly DependencyProperty DescriptionProperty =
   DependencyProperty.Register("Description", typeof(string), typeof(DropdownLabel), new PropertyMetadata("这是一个FTP功能介绍"));

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
        public CardControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
