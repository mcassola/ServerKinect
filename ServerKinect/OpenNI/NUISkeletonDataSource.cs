using ServerKinect.DataSource;
using ServerKinect.Skeleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.OpenNI
{
    public class NUISkeletonDataSource: DataSourceProcessor<SkeletonDataSource, SkeletonDataSource>, ISkeletonDataSource
    {

        public NUISkeletonDataSource(ISkeletonPointerDataSource dataSource)
            : base(dataSource)
        {
            this.CurrentValue = dataSource.SkeletonData();

        }

        protected override SkeletonDataSource Process(SkeletonDataSource sourceData)
        {
            return this.ProcessUnsafe(sourceData);
        }

        private unsafe SkeletonDataSource ProcessUnsafe(SkeletonDataSource sourceData)
        {
            if (this.CurrentValue == null)
            { 
                this.CurrentValue = sourceData; 
            }

            if (this.CurrentValue != null)
            {
                lock (this.CurrentValue)
                {
                    this.CurrentValue = sourceData;
                    //this.imageFactory.CreateImage(this.CurrentValue, sourceData);
                    return this.CurrentValue;
                }
            }
            return null;
        }
    }
}
