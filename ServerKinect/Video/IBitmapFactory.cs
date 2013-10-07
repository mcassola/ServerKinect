using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ServerKinect.Video
{
    public interface IBitmapFactory
    {
        unsafe void CreateImage(Bitmap targetImage, IntPtr pointer);
    }
}
