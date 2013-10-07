using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Drawing;
using System.Drawing.Imaging;
using ServerKinect.DataSource;

namespace ServerKinect.SKDMicrosoft
{
    public class SDKRgbBitmapDataSource : SDKBitmapDataSource
    {
        private BitmapData bitmapDataLast;
        private static bool imageInUse = false;
        public static bool ImageInUse
        {
            get { return imageInUse; }
            set { imageInUse = value; }
        }
        public SDKRgbBitmapDataSource(IKinectSensor sensor)
            : base(sensor)
        { }

        public override int Width
        {
            get { return this.Sensor.ColorStreamWidth; }
        }

        public override int Height
        {
            get { return this.Sensor.ColorStreamHeight; }
        }

        protected override void  InnerStart()
        {
            this.Sensor.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(sensor_ColorFrameReady);
        }

        protected override void InnerStop()
        {
            this.Sensor.ColorFrameReady -= new EventHandler<ColorImageFrameReadyEventArgs>(sensor_ColorFrameReady);
        }

        protected void sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (var frame = e.OpenColorImageFrame())
            {
                if (frame != null)
                {
                    this.ProcessFrame(frame);
                }
            }
        }

        protected unsafe void ProcessFrame(ColorImageFrame frame)
        {
            if (!imageInUse)
            {
                var bytes = new byte[frame.PixelDataLength];
                frame.CopyPixelDataTo(bytes);
               // try
              //  {
                    BitmapData bitmapData = this.CurrentValue.LockBits(new System.Drawing.Rectangle(0, 0, this.Width, this.Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    //  BitmapData bitmapData = this.CurrentValue;  
                    // bitmapDataLast = bitmapData;
                    byte* pDest = (byte*)bitmapData.Scan0.ToPointer();
                    int pointer = 0;

                    var maxIndex = this.Width * this.Height;
                    for (int index = 0; index < maxIndex; index++)
                    {
                        pDest[0] = bytes[pointer];
                        pDest[1] = bytes[pointer + 1];
                        pDest[2] = bytes[pointer + 2];
                        pDest += 3;
                        pointer += 4;
                    }
                    this.CurrentValue.UnlockBits(bitmapData);
                    imageInUse = true;
                    this.OnNewDataAvailable();
              //  }
                //}
               /* catch (Exception ex)
                {
                    Console.WriteLine("error " + ex.ToString());
                    this.CurrentValue.UnlockBits(bitmapData);
                }*/
            }
          
        }
    }
}
