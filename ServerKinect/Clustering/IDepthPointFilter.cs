using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Clustering
{
    public interface IDepthPointFilter<TSource>
    {
        IList<Point> Filter(TSource source);
    }
}
