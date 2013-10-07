using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.OpenNI
{
    public class OpenNISkeletonDataSource  : NUISkeletonDataSource
    {
        public OpenNISkeletonDataSource(ISkeletonPointerDataSource skeletonDataSource)
            : base(skeletonDataSource)
        { }
    }
}
