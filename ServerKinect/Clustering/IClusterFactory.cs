﻿using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Clustering
{
    public interface IClusterFactory
    {
        ClusterCollection Create(IList<Point> points);
    }
}
