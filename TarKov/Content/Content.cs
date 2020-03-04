using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using TarKov;

public class BrowserData
{
    public BrowserData(string URL, int Width = 1000, bool TransparentBody = false)
    {
        this.URL = URL;
        this.Width = Width;
    }
    public string URL;
    public bool Init = false;
    public EContent content; 
    public string LatestURL;
    public double LatestScrollHeight;
    public int Width;
    public bool TransparentBody = false;
}
public static class BrowserHelper
{
    public static bool SaveLastURL = false;
    public static EContent CurrentCotnent;
    public static MainWindow MainWindow;
    public static ChromiumWebBrowser Browser;
    public static Dictionary<EContent, BrowserData> ContentMap = new Dictionary<EContent, BrowserData>(); 
    public static void Init()
    { 
        ContentMap.Add(EContent.QUEST, new BrowserData("https://escapefromtarkov.gamepedia.com/Quests", 1000));
        ContentMap.Add(EContent.ARMOR, new BrowserData("https://escapefromtarkov.gamepedia.com/Armor_vests",1000));
        ContentMap.Add(EContent.MARKET, new BrowserData("https://tarkov-market.com/", 800));
        ContentMap.Add(EContent.AMMO, new BrowserData("https://escapefromtarkov.gamepedia.com/Ballistics", 1000));
        ContentMap.Add(EContent.WEAPON, new BrowserData("https://escapefromtarkov.gamepedia.com/Weapons", 1000));
    } 

    
    public static void VisitContent(EContent content)
    {
        if (ContentMap.Count == 0)
            Init();


        if (content != CurrentCotnent && CurrentCotnent != EContent.NONE)
        {
            //현재 컨텐츠를 가져온다.
            var currentContent = ContentMap[CurrentCotnent];
            currentContent.LatestURL = Browser.Address; 
           // currentContent.LatestScrollHeight = Browser.Height; 
        }
        else
        {
            if (content == CurrentCotnent)
            {
                var currentContent = ContentMap[CurrentCotnent];
                if (currentContent.LatestURL == Browser.Address)
                {
                    currentContent.LatestURL = currentContent.URL; 
                }
            }
        }

        CurrentCotnent = content;
        MapHandler.HideAndBrowserShow(); 
   
        //get content data
        var visitContent = ContentMap[content];

        //content init
        if (visitContent.Init == false)
        {
            visitContent.LatestURL = visitContent.URL;
            visitContent.Init = true;
        }

        //white bg execute
        MainWindow.whiteBackground.Visibility = (visitContent.TransparentBody == true) ? Visibility.Visible : Visibility.Hidden; 
       
        //get url
        var url = visitContent.LatestURL;
        var scroll = visitContent.LatestScrollHeight;

        Browser.Visibility = Visibility.Visible;
        Browser.HorizontalAlignment = HorizontalAlignment.Left;
        Browser.Width = visitContent.Width;
        Browser.Load(visitContent.LatestURL);
        //Browser.p = getContent.LatestScrollHeight;
    }
}