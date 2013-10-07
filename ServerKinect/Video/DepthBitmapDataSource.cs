﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.ExceptionServices;
using ServerKinect.DataSource;

namespace ServerKinect.Video
{
    public class DepthBitmapDataSource : BitmapDataSource
    {
        public DepthBitmapDataSource(IDepthPointerDataSource depthDataSource)
            : base(depthDataSource, new DepthBitmapFactory(depthDataSource.MaxDepth))
        { }
    }
}
