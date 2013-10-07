using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ServerKinect.Shape;
using ServerKinect.DataSource;

namespace ServerKinect.OpenNI
{
    public class DepthDataFrameFactory
    {
        private IntSize size;

        public DepthDataFrameFactory(IntSize size)
        {
            this.size = size;
        }

        public DepthDataFrame Create(IntPtr pointer)
        {
            var depthDataFrame = new DepthDataFrame(this.size.Width, this.size.Height);
            this.Create(depthDataFrame, pointer);
            return depthDataFrame;
        }

        public void Create(DepthDataFrame depthDataFrame, IntPtr pointer)
        {
            var data = new short[this.size.Width * this.size.Height];
            Marshal.Copy(pointer, data, 0, data.Length);
            Buffer.BlockCopy(data, 0, depthDataFrame.Data, 0, data.Length * sizeof(short));
        }
    }
}
