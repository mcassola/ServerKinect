using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.DataSource
{
    public interface IImagePointerDataSource : IDataSource<IntPtr>
    {
        IntSize Size { get; }

        int Width { get; }

        int Height { get; }
    }
}
