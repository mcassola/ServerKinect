using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerKinect.Shape;

namespace ServerKinect.HandTracking.Mouse
{
    public class CenterOfHandCursorMode : ICursorMode
    {
        public Point GetPoint(HandCollection handData)
        {
            return handData.Hands.First().PalmPoint.Value;
        }

        public bool HasPoint(HandCollection handData)
        {
            return handData.Count > 0 && handData.Hands.First().HasPalmPoint;
        }

        public CursorMode EnumValue
        {
            get { return CursorMode.CenterOfHand; }
        }
    }
}
