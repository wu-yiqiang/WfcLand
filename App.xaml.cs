using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;
using Microsoft.Win32;
using System.Configuration;
using System.Data;
using System.Windows;
namespace WfcLand
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string Key = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string Value = "AppsUseLightTheme";

        public static bool IsLight => (Registry.GetValue(Registry.CurrentUser.Name + "\\" + Key, Value, 1) as int?) == 1;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemeManager.Current.ApplicationTheme = IsLight ? ApplicationTheme.Light : ApplicationTheme.Dark;
        }
    }

}
