using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Clustering
{
    public interface IClusterMergeStrategy
    {
        IList<ClusterPrototype> MergeClustersIfRequired(IList<ClusterPrototype> clusters);
    }
}
