using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.OpenNI
{
    public interface IDepthGenerator : IImageGenerator
    {
        int DeviceMaxDepth { get; }
    }
}
