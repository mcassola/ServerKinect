using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using ServerKinect.DataSource;

namespace ServerKinect.Video
{
    public class RgbImageDataSource : ImageDataSource
    {
        public RgbImageDataSource(IRgbPointerDataSource dataSource)
            : base(dataSource, new RgbImageSourceFactory())
        { }
    }
}
