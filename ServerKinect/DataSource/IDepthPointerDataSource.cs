using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.DataSource
{
    public interface IDepthPointerDataSource : IImagePointerDataSource
    {
        int MaxDepth { get; }
    }
}
