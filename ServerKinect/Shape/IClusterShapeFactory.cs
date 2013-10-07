using ServerKinect.Clustering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Shape
{
    public interface IClusterShapeFactory
    {
        ShapeCollection Create(ClusterCollection clusterData);
    }
}
