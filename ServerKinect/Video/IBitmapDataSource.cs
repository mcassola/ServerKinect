using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ServerKinect.DataSource;
using ServerKinect.Shape;

namespace ServerKinect.Video
{
    public interface IBitmapDataSource : IDataSource<Bitmap>
    {
        IntSize Size { get; }

        int Width { get; }

        int Height { get; }
    }
}
