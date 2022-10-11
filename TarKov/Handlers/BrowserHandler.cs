using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarKov.Handlers
{
    public static class BrowserHandler
    { 
        public static void Wheeling(System.Windows.Forms.MouseEventArgs e)
        {
            AppHandler.window.BrowserZoom(e);
        }
    }
}
