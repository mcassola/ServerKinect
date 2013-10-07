using ServerKinect.OpenNI;
using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ServerKinect.HandTracking.Mouse
{
    public class HandTrackingCursorMode : ICursorMode
    {
        private TrackingClusterDataSource trackingClusterDataSource;

        public HandTrackingCursorMode(TrackingClusterDataSource trackingClusterDataSource)
        {
            this.trackingClusterDataSource = trackingClusterDataSource;
        }

        public Point GetPoint(HandCollection handData)
        {
            return this.trackingClusterDataSource.TrackingPoint.GetValueOrDefault();
        }

        public bool HasPoint(HandCollection handData)
        {
            return this.trackingClusterDataSource.TrackingPoint.HasValue;
        }

        public CursorMode EnumValue
        {
            get { return CursorMode.HandTracking; }
        }
    }
}
