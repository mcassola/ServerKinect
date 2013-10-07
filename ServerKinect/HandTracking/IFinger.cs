using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.HandTracking
{
    public interface IFinger : ILocatable
    {
        Point Fingertip { get; }
    }
}
