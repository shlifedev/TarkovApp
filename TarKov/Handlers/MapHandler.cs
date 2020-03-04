using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public static class MapHandler
{
    public static bool Show = false;

    public static string[] GetResourceNames()
    {
        var assembly = Assembly.GetExecutingAssembly();
        string resName = assembly.GetName().Name + ".g.resources";
        using (var stream = assembly.GetManifestResourceStream(resName))
        {
            using (var reader = new System.Resources.ResourceReader(stream))
            {
                return reader.Cast<DictionaryEntry>().Select(entry =>
                         (string)entry.Key).ToArray();
            }
        }
    }

    public static void ShowMap(string mapName)
    {
        TarKov.MainWindow window = AppHandler.window;
        window.ChromiumBrowser.Visibility = Visibility.Hidden;
        window.MapImage.Visibility = Visibility.Visible;
        window.CloseMap.Visibility = Visibility.Visible;
        ImageBrush imgBrush = new ImageBrush();
        imgBrush.Opacity = 1f;
        var resourceNames = GetResourceNames();
        var b = false;
        foreach (var v in resourceNames)
        { 
            if (v == ("res/"+mapName.ToLower() + ".png") || v == ("res/" + mapName.ToLower() + ".jpg"))
            { 
                var extention = v.Split('.')[1]; 
                imgBrush.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/res/{mapName}.{extention}"));
                b = true;
                break;
            } 
        }
        if(b)
        {
            window.MapImage.Fill = imgBrush;
        }
        else
        { 
            throw new System.IO.FileNotFoundException(mapName);
        }
    }
    public static void HideAndBrowserShow()
    {
        TarKov.MainWindow window = AppHandler.window;
        window.ChromiumBrowser.Visibility = Visibility.Visible;
        window.MapImage.Visibility = Visibility.Hidden;
    }
}