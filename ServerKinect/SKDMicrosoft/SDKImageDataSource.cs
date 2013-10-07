using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ServerKinect.DataSource;
using ServerKinect.Video;


namespace ServerKinect.SKDMicrosoft
{
    public abstract class SDKImageDataSource : SensorDataSource<ImageSource>, IImageDataSource
    {
        protected WriteableBitmap writeableBitmap;

        public SDKImageDataSource(IKinectSensor nuiRuntime)
            : base(nuiRuntime)
        {
            this.writeableBitmap = new WriteableBitmap(this.Width, this.Height, 96, 96, PixelFormats.Bgr32, null);
            this.CurrentValue = this.writeableBitmap;
        }
    }
}
