using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ServerKinect.Skeleton;

namespace ServerKinect.OpenNI
{
    public class SkeletonPointerDataSource : OpenNISkeletonDataSourceBase<SkeletonDataSource, ISkeletonGenerator>, ISkeletonPointerDataSource
    {
        public SkeletonPointerDataSource(ISkeletonGenerator generator)
            : base(generator)
        { }

        protected SkeletonDataSource skeletonDataSource;

        protected override unsafe void Run()
        {
            this.skeletonDataSource = this.Generator.SkeletonData();
            this.CurrentValue = this.skeletonDataSource;
            this.OnNewDataAvailable(this.CurrentValue);
        }

        public SkeletonDataSource SkeletonData()
        {
            return this.skeletonDataSource;
        }
    }
}
