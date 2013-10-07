using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Windows.Forms;
using ServerKinect.DataSource;
using ServerKinect.Video;
using ServerKinect.Skeleton;
using ServerKinect.Clustering;
using ServerKinect.Shape;


namespace ServerKinect.SKDMicrosoft
{
    public class SDKDataSourceFactory : IDataSourceFactory
    {
        private KinectSensor sensor;
        private bool useNearMode;
        private ListBox textBoxKinectStatus;

        public SDKDataSourceFactory(ListBox textBox,bool useNearMode = false)
        {
            this.textBoxKinectStatus = textBox;
            this.sensor = KinectSensor.KinectSensors.First();
            this.Adapter = new KinectSensorAdapter(this.sensor, useNearMode);
            this.sensor.Start();
            sensor.ColorStream.Enable(ColorImageFormat.YuvResolution640x480Fps15);//ColorImageFormat.RgbResolution640x480Fps30);
            this.sensor.DepthStream.Range = DepthRange.Default;
            sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
            this.sensor.SkeletonStream.Enable();
            KinectSensor.KinectSensors.StatusChanged += this.KinectsStatusChanged;
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
              
                //Console.WriteLine(kinect.Status.ToString());
                textBoxKinectStatus.Items.Add(kinect.Status.ToString() + "\t" + DateTime.Now.ToString("T")); 
                
                
            }
        }

        public int getTiltAngleElevation() { return this.sensor.ElevationAngle; }

        public void setTiltAngleElevation(int value) {
            this.sensor.ElevationAngle = value;
        }

        public SDKDataSourceFactory(bool useNearMode = false)
        {
            this.sensor = KinectSensor.KinectSensors.First();
            this.Adapter = new KinectSensorAdapter(this.sensor, useNearMode);
            this.sensor.Start();
            sensor.ColorStream.Enable(ColorImageFormat.YuvResolution640x480Fps15);//ColorImageFormat.RgbResolution640x480Fps30);
            this.sensor.DepthStream.Range = DepthRange.Default;
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            this.sensor.SkeletonStream.Enable();
        }

        private void KinectsStatusChanged(object sender, StatusChangedEventArgs e)
        {
            //Console.WriteLine(e.Status.ToString());
            textBoxKinectStatus.Items.Add(e.Status.ToString() + "\t" + DateTime.Now.ToString("T")); 
        }

        private KinectSensorAdapter Adapter { get; set; }

        public IImageDataSource CreateRGBImageDataSource()
        {
            return new SDKRgbImageDataSource(this.Adapter);
        }

        public IImageDataSource CreateDepthImageDataSource()
        {
            return new SDKDepthImageDataSource(this.Adapter);
        }

        public ISkeletonDataSource CreateSkeletonDateSource()
        {
            return new SDKSkeletonFrame(this.Adapter);
        }

        public IBitmapDataSource CreateRGBBitmapDataSource()
        {
            return new SDKRgbBitmapDataSource(this.Adapter);
        }

        public IBitmapDataSource CreateDepthBitmapDataSource()
        {
            return new SDKDepthBitmapDataSource(this.Adapter);
        }

        public IClusterDataSource CreateClusterDataSource(ClusterDataSourceSettings clusterDataSourceSettings)
        {
            var size = new IntSize(this.Adapter.DepthStreamWidth, this.Adapter.DepthStreamHeight);
            var clusterFactory = new KMeansClusterFactory(clusterDataSourceSettings, size);
            var filter = new ImageFrameDepthPointFilter(this.Adapter, size, clusterDataSourceSettings.MinimumDepthThreshold, clusterDataSourceSettings.MaximumDepthThreshold, clusterDataSourceSettings.LowerBorder);
            return new SDKClusterDataSource(this.Adapter, clusterFactory, filter);
        }

        public IClusterDataSource CreateClusterDataSource()
        {
            return this.CreateClusterDataSource(new ClusterDataSourceSettings());
        }

        public IShapeDataSource CreateShapeDataSource()
        {
            return new ClusterShapeDataSource(this.CreateClusterDataSource());
        }

        public IShapeDataSource CreateShapeDataSource(IClusterDataSource clusterdataSource)
        {
            return new ClusterShapeDataSource(clusterdataSource, new ShapeDataSourceSettings());
        }

        public IShapeDataSource CreateShapeDataSource(IClusterDataSource clusterdataSource, ShapeDataSourceSettings shapeDataSourceSettings)
        {
            return new ClusterShapeDataSource(clusterdataSource, shapeDataSourceSettings);
        }

        public IShapeDataSource CreateShapeDataSource(ClusterDataSourceSettings clusterDataSourceSettings, ShapeDataSourceSettings shapeDataSourceSettings)
        {
            return new ClusterShapeDataSource(this.CreateClusterDataSource(clusterDataSourceSettings), shapeDataSourceSettings);
        }

        public KinectSensor Sensor
        {
            get { return this.sensor; }
        }

        public void Dispose()
        {
            this.Adapter.Dispose();
            this.sensor.Dispose();
        }



    }
}
