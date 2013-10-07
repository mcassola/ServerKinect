﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using ServerKinect.DataSource;

namespace ServerKinect.SKDMicrosoft
{
    public class KinectSensorAdapter : IKinectSensor, IDisposable
    {
        private KinectSensor sensor;

        public KinectSensorAdapter(KinectSensor sensor, bool useNearMode)
        {
            this.sensor = sensor;
            if (useNearMode)
            {
                this.sensor.DepthStream.Range = DepthRange.Near;
            }
            this.sensor.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(sensor_ColorFrameReady);
            this.sensor.DepthFrameReady += new EventHandler<DepthImageFrameReadyEventArgs>(sensor_DepthFrameReady);
            this.sensor.SkeletonFrameReady +=new EventHandler<SkeletonFrameReadyEventArgs>(sensor_SkeletonFrameReady);
        }

        public void Dispose()
        {
            this.sensor.ColorFrameReady -= new EventHandler<ColorImageFrameReadyEventArgs>(sensor_ColorFrameReady);
            this.sensor.DepthFrameReady -= new EventHandler<DepthImageFrameReadyEventArgs>(sensor_DepthFrameReady);
            this.sensor.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(sensor_SkeletonFrameReady);
        }

        public int DepthStreamWidth
        {
            get { return this.sensor.DepthStream.FrameWidth; }
        }

        public int DepthStreamHeight
        {
            get { return this.sensor.DepthStream.FrameHeight; }
        }

        public int ColorStreamWidth
        {
            get { return this.sensor.ColorStream.FrameWidth; }
        }

        public int ColorStreamHeight
        {
            get { return this.sensor.ColorStream.FrameHeight; }
        }

        public event EventHandler<DepthImageFrameReadyEventArgs> DepthFrameReady;

        void sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            if (this.DepthFrameReady != null)
            {
                this.DepthFrameReady(this, e);
            }
        }

        public event EventHandler<ColorImageFrameReadyEventArgs> ColorFrameReady;
       

        void sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            if (this.ColorFrameReady != null)
            {
                this.ColorFrameReady(this, e);
            }
        }

        public event EventHandler<SkeletonFrameReadyEventArgs> SkeletonFrameReady;

        void sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            if (this.SkeletonFrameReady != null)
            {
                this.SkeletonFrameReady(this, e);
            }
        }
    }
}
