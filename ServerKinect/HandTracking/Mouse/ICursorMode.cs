using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerKinect.Shape;

namespace ServerKinect.HandTracking.Mouse
{
    public interface ICursorMode
    {
        bool HasPoint(HandCollection handData);

        Point GetPoint(HandCollection handData);

        CursorMode EnumValue { get; }
    }
}
