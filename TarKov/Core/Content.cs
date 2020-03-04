using System.Collections.Generic;

public class BrowserData
{
    public EContent content; 
    public string LatestURL;
    public int LatestScrollHeight;  
}
public static class ContentContainer
{
    public static Dictionary<EContent, BrowserData> ContentMap = new Dictionary<EContent, BrowserData>();
    public static void Init()
    {

    }
}