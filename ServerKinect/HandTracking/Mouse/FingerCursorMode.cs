using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.HandTracking.Mouse
{
    public class FingerCursorMode : ICursorMode
    {
        public Point GetPoint(HandCollection handData)
        {
            return handData.Hands.First().Fingers.First().Location;
        }

        public bool HasPoint(HandCollection handData)
        {
            var fingerCount = handData.Hands.First().FingerCount;
            return handData.Count > 0 && fingerCount > 0 && fingerCount <= 2;
        }

        public CursorMode EnumValue
        {
            get { return CursorMode.Finger; }
        }
    }
}
