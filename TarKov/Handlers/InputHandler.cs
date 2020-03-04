using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TarKov.Handlers;

public static class InputHelper
{
    private static IKeyboardMouseEvents m_GlobalHook;
    public static int mX;
    public static int mY;

    public static bool EnableControlKey = false;
    public static void Init()
    {
        m_GlobalHook = Hook.GlobalEvents();
        m_GlobalHook.MouseMove += OnMouseMove;
        m_GlobalHook.KeyUp += OnKeyPressUp;
        m_GlobalHook.KeyDown += OnKeyPressDown;
        m_GlobalHook.MouseWheel += OnMouseWheel;
    }

    public static void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        BrowserHandler.Wheeling(e);
    }
    public static void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        mX = e.X;
        mY = e.Y; 
    }
    public static void OnKeyPressDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.Control) { InputHelper.EnableControlKey = true; } 
    } 
    public static void OnKeyPressUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        AppHandler.KeyUpEventHandler(sender, e);
        OfferHandler.KeyUpEventHandler(sender, e);
        if (e.Control) { EnableControlKey = false; }
    }

}
