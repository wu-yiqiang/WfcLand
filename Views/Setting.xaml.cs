using iNKORE.UI.WPF.Modern.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MessageBoxs = iNKORE.UI.WPF.Modern.Controls.MessageBox;
namespace WfcLand.Views
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : System.Windows.Controls.Page
    {
        public Setting()
        {
            InitializeComponent();
        }

        public async void HandlePrivacyDialog(object sender, EventArgs e)
        {
            ContentDialogResult result = await PrivacyDialog.ShowAsync();

        }
        public async void HandleLicenseDialog(object sender, EventArgs e)
        {
            ContentDialogResult result = await LicenseDialog.ShowAsync();

        }
    }
}
