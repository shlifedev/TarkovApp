using CefSharp;
using CefSharp.Wpf;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace TarKov
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary> 
    /// 


    public partial class MainWindow : System.Windows.Window
    {
        public ChromiumWebBrowser ChromiumBrowser;
        public bool isDevMode = false;
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public MainWindow()
        {
            InitializeComponent();
            AllocConsole();
            Setup();
            ChromeInit("https://tarkov-market.com/");
            InputHelper.Init();
            AppHandler.Init(this);
        }
        void Setup()
        {
            this.Topmost = true;
            var _width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            var _height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Width = _width;
            this.Height = _height;
            this.AppGrid.Width = _width;
            this.AppGrid.Height = _height;
        }
        public void ChromeInit(string url)
        {
            CefSettings chromium = new CefSettings();
            Cef.Initialize(chromium);
            ChromiumBrowser = new ChromiumWebBrowser();
            ChromiumBrowser.Address = url;
            ChromiumBrowser.Width = 500;
            ChromiumBrowser.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetColumn(ChromiumBrowser, 1);
            AppGrid.Children.Add(ChromiumBrowser);
            this.ChromiumBrowser.Visibility = Visibility.Visible;
        }
        public void ChangeURL(string url, bool whiteBg, int browerSize)
        {
            MapHandler.HideAndBrowserShow();
            ChromiumBrowser.HorizontalAlignment = HorizontalAlignment.Left;
            ChromiumBrowser.Visibility = Visibility.Visible;
            whiteBackground.Width = browerSize;
            ChromiumBrowser.Width = browerSize;
            ChromiumBrowser.Load(url);
            whiteBackground.Visibility = (whiteBg == true) ? Visibility.Visible : Visibility.Hidden;
        }
        public void BrowserZoom(System.Windows.Forms.MouseEventArgs e)
        {
            if (InputHelper.EnableControlKey)
            {
                var p = 1;
                if (e.Delta > 0) p = 1;
                else p = -1;
                ChromiumBrowser.ZoomLevel += p;
            }
        }

        private void Button_Armor(object sender, RoutedEventArgs e)
        {
            ChangeURL("https://escapefromtarkov.gamepedia.com/Armor_vests", false, 1000);
        }
        private void Button_Ammo(object sender, RoutedEventArgs e)
        {
            ChangeURL("https://escapefromtarkov.gamepedia.com/Ballistics", false, 600);
        }
        private void Button_Market(object sender, RoutedEventArgs e)
        {
            ChangeURL("https://tarkov-market.com/", false, 600);
        }
        private void Button_Weapons(object sender, RoutedEventArgs e)
        {
            //ChangeURL("https://namu.wiki/w/Escape%20From%20Tarkov/%EB%AC%B4%EA%B8%B0", false, 800); 
            //en
            ChangeURL("      https://escapefromtarkov.gamepedia.com/Weapons", false, 1000);
        }
        public void DisableBrowser()
        {
            this.ChromiumBrowser.Visibility = Visibility.Hidden;
        }
        public void EnableBrowser()
        {
            this.ChromiumBrowser.Visibility = Visibility.Visible;
        }
        public string GetLocale()
        {
            return "en";
        }
        public void Button_Map_Reserve(object sender, RoutedEventArgs e)
        {
            MapHandler.ShowMap($"Reserve_{GetLocale()}");
        }
        public void Button_Map_InterChange(object sender, RoutedEventArgs e)
        {
            MapHandler.ShowMap($"InterChange_{GetLocale()}");
        }
        public void Button_Map_Custom(object sender, RoutedEventArgs e)
        {
            MapHandler.ShowMap($"Custom_{GetLocale()}");
        }
        public void Button_Map_Wood(object sender, RoutedEventArgs e)
        {
            MapHandler.ShowMap($"Wood_{GetLocale()}");
        }
        public void Button_Quest(object sender, RoutedEventArgs e)
        {
            ChangeURL("https://escapefromtarkov.gamepedia.com/Quests", false, 1000);
        }
        private void HideMap(object sender, RoutedEventArgs e)
        {
            MapHandler.HideAndBrowserShow();
        }
    }


}
