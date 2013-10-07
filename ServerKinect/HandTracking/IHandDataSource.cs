using ServerKinect.DataSource;
using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.HandTracking
{
    public interface IHandDataSource : IDataSource<HandCollection>
    {
        int Width { get; }

        int Height { get; }

        IntSize Size { get; }
    }
}
