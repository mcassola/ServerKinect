using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using ServerKinect.Skeleton;
using ServerKinect.DataSource;
using ServerKinect.Shape;


namespace ServerKinect.SKDMicrosoft
{
    public class SDKSkeletonFrame : NUISkeletonFrame
    {

        public SDKSkeletonFrame(IKinectSensor sensor) : base(sensor)
        {}

        protected override void InnerStart()
        {
           this.Sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(Sensor_SkeletonFrameReady);
        }

        protected override void InnerStop()
        {
            this.Sensor.SkeletonFrameReady -= new EventHandler<SkeletonFrameReadyEventArgs>(Sensor_SkeletonFrameReady);
        }

        public override int Width
        {
            get { throw new NotImplementedException(); }
        }

        public override int Height
        {
            get { throw new NotImplementedException(); }
        }

        private void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Microsoft.Kinect.Skeleton[] skeletons = new Microsoft.Kinect.Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Microsoft.Kinect.Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                    skeletonDataSource = convertFromSDKSkeleton(skeletons);//VER SI SE PUEDE ABSTRAER
                    this.CurrentValue = skeletonDataSource;
                    this.OnNewDataAvailable();
                }
            }
        }
       
        private SkeletonDataSource convertFromSDKSkeleton(Microsoft.Kinect.Skeleton[] skeletons)
        {
            skeletonDataSource = new SkeletonDataSource();
            if (skeletons.Length != 0)
            {
                foreach (Microsoft.Kinect.Skeleton skel in skeletons)
                {
                    SkeletonsData data = null;
                    if (skel.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        data = new SkeletonsData(skel.TrackingId);
                        foreach (Joint joint in skel.Joints)
                        {
                            Point p = new Point(joint.Position.X,joint.Position.Y,joint.Position.Z);
                            JointSkeleton joints = new JointSkeleton(joint.JointType.ToString(), p);
                            data.addJointSkeleton(joints);
                        }
                    }

                    if (data != null)
                        skeletonDataSource.addSkeletonData(data);
                }
            }
            return skeletonDataSource;
        }
    }
}
