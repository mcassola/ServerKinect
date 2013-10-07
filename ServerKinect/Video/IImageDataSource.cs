using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Media;
using ServerKinect.DataSource;
using ServerKinect.Shape;

namespace ServerKinect.Video
{
    public interface IImageDataSource : IDataSource<ImageSource>
    {
        IntSize Size { get; }

        int Width { get; }

        int Height { get; }
    }
}
