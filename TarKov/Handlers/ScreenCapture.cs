using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TarKov.Handlers
{
    /* May be necessary. */
    public class ScreenCapture
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr onj);
        public static void CaptureToMap()
        {
            Bitmap bitmap;

            bitmap = new Bitmap((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            }
            IntPtr handle = IntPtr.Zero;
            try
            {
                handle = bitmap.GetHbitmap();
                BitmapSource p = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = p;
                AppHandler.window.MapImage.Fill = ib;  
            }
            catch (Exception)
            {

            }

            finally
            {
                DeleteObject(handle);
            }
        }
    }
}
