using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using ServerKinect.DataSource;

namespace ServerKinect.Skeleton
{
    public abstract class NUISkeletonFrame : SensorDataSource<SkeletonDataSource>, ISkeletonDataSource
    {

        protected SkeletonDataSource skeletonDataSource;

        public NUISkeletonFrame(IKinectSensor sensor)
            : base(sensor)
        { 
            this.skeletonDataSource = new SkeletonDataSource();
            this.CurrentValue = this.skeletonDataSource;
        }

    }
}
