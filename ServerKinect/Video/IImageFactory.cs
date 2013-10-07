using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace ServerKinect.Video
{
    public interface IImageFactory
    {
        unsafe void CreateImage(WriteableBitmap target, IntPtr pointer);
    }
}
