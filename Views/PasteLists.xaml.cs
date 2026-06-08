using iNKORE.UI.WPF.Modern.Common.IconKeys;
using iNKORE.UI.WPF.Modern.Controls;
using System.Collections.ObjectModel;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using FormsClipboard = System.Windows.Clipboard;
using MessageBoxs = iNKORE.UI.WPF.Modern.Controls.MessageBox;
namespace WfcLand.Views
{
    public partial class PasteLists : System.Windows.Controls.Page
    {
        public ObservableCollection<string> Items { get; set; } = [];

        public PasteLists()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>
            {
               
            };
            ItemsControlLists.ItemsSource = Items;
        }

        /// <summary>
        /// 复制指定项到剪贴板
        /// </summary>
        public void HandleCopy(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string item)
            {
                FormsClipboard.SetText(item);
                MessageBoxs.Show(item, "复制成功", MessageBoxButton.OK, FluentSystemIcons.CheckmarkCircle_48_Filled);
            }
        }
        public async void HandleAdd(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "确认添加?";
            dialog.PrimaryButtonText = "保存";
            dialog.CloseButtonText = "关闭";
            dialog.DefaultButton = ContentDialogButton.Primary;
            TextBox textBox  = new TextBox();
            textBox.MaxHeight = 500;
            textBox.MinHeight = 260;
            textBox.Width = 420;
            textBox.AcceptsReturn = true;
            dialog.Content = textBox;
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string textToSave = textBox.Text;
                if (!string.IsNullOrWhiteSpace(textToSave))
                {
                    Items.Add(textToSave);
                }

            }
        }
    }
}