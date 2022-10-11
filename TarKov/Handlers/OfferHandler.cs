using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

public static class OfferHandler
{
    public static bool OfferMacroEnable = false;
    public static void KeyUpEventHandler(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        //if (OfferMacroEnable)
        //{
        //    if (InputHelper.EnableControlKey && e.KeyCode == System.Windows.Forms.Keys.D1)
        //    {
        //        Thread macroThread = new Thread(new ParameterizedThreadStart(OfferHandler.RunMacro_OfferDragWindow));
        //        macroThread.Start(e);
        //        return;
        //    }
        //    if (InputHelper.EnableControlKey && e.KeyCode == System.Windows.Forms.Keys.D2)
        //    {
        //        Thread macroThread = new Thread(new ParameterizedThreadStart(OfferHandler.RunMacro_ItemInspection));
        //        macroThread.Start(e);
        //        return;
        //    }
        //}
    }
    public static void RunMacro_OfferDragWindow(object e)
    {
        Macro_OfferDragWindow((System.Windows.Forms.KeyEventArgs)e);
    }
    static void Macro_OfferDragWindow(System.Windows.Forms.KeyEventArgs e)
    {
        SimWinInput.SimMouse.Click(System.Windows.Forms.MouseButtons.Left, 1246, 81, 25);
        Thread.Sleep(1000); // wait shop dupate
        var y = 164;
        for (int i = 819; i >= 0; i -= 6)
        {
            if (y == -1) y = 0;
            SimWinInput.SimMouse.Act(SimWinInput.SimMouse.Action.LeftButtonDown, i, y -= 6);
            Thread.Sleep(6);
        }
        SimWinInput.SimMouse.Act(SimWinInput.SimMouse.Action.LeftButtonUp, 0, 0);
    }
    public static void RunMacro_ItemInspection(object e)
    {
        Macro_ItemInspection((System.Windows.Forms.KeyEventArgs)e);
    }
    static void Macro_ItemInspection(System.Windows.Forms.KeyEventArgs e)
    {
        var px = InputHelper.mX;
        var py = InputHelper.mY;
        //Get Current Mouse Pos, And Click.
        SimWinInput.SimMouse.Click(System.Windows.Forms.MouseButtons.Left, px, py, 100);
        Thread.Sleep(15);
        //Open menu
        SimWinInput.SimMouse.Click(System.Windows.Forms.MouseButtons.Right, px, py, 100);
        Thread.Sleep(15);
        //Click Inspection
        var filter_distance = 50;
        SimWinInput.SimMouse.Click(System.Windows.Forms.MouseButtons.Left, px, py - filter_distance, 100);
        //Wait Response.
        Thread.Sleep(1500);
        SimWinInput.SimMouse.Click(System.Windows.Forms.MouseButtons.Left, 1055, 353);
        Thread.Sleep(50);
        SimWinInput.SimMouse.Click(System.Windows.Forms.MouseButtons.Left, 1006, 234);
    }
}