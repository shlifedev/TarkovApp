using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public static class MapHandler
{
    public static bool Show = false;
    public static void ShowMap(string mapName)
    { 
      
        TarKov.MainWindow window = AppHandler.window;
        window.ChromiumBrowser.Visibility = Visibility.Hidden;
        window.MapImage.Visibility = Visibility.Visible;
        window.CloseMap.Visibility = Visibility.Visible;
        ImageBrush imgBrush = new ImageBrush();
        imgBrush.Opacity = 1f;
        imgBrush.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/res/{mapName}.png")); 
        window.MapImage.Fill = imgBrush;
    }
    public static void HideAndBrowserShow()
    {
        TarKov.MainWindow window = AppHandler.window;
        window.ChromiumBrowser.Visibility = Visibility.Visible;
        window.MapImage.Visibility = Visibility.Hidden;
    }
}