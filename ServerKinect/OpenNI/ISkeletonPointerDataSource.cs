using ServerKinect.DataSource;
using ServerKinect.Skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.OpenNI
{
    public interface ISkeletonPointerDataSource : IDataSource<SkeletonDataSource>
    {
        SkeletonDataSource SkeletonData();
    }
}
