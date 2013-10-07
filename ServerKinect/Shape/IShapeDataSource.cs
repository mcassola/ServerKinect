﻿using ServerKinect.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Shape
{
    public interface IShapeDataSource : IDataSource<ShapeCollection>
    {
        int Width { get; }

        int Height { get; }

        IntSize Size { get; }
    }
}
