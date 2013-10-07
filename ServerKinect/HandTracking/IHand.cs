using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerKinect.Shape;

namespace ServerKinect.HandTracking
{
    public interface IHand : ILocatable
    {
        Point? PalmPoint { get; }

        bool HasPalmPoint { get; }

        float PalmX { get; }

        float PalmY { get; }

        IEnumerable<IFinger> Fingers { get; }

        int FingerCount { get; }
    }
}
