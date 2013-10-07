using ServerKinect.Skeleton;
using ServerKinect.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.OpenNI
{
    public interface ISkeletonGenerator
    {
        SkeletonDataSource SkeletonData();
        event EventHandler NewData;
    }
}
