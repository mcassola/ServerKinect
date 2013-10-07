using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenNI;
using System.Windows.Forms;
using ServerKinect.DataSource;
using ServerKinect.Clustering;
using ServerKinect.Skeleton;
using ServerKinect.Video;
using ServerKinect.Shape;

namespace ServerKinect.OpenNI
{
    public class OpenNIDataSourceFactory : IDataSourceFactory
    {
        private Context context;
        private IDepthPointerDataSource depthPointerDataSource = null;
        private ISkeletonPointerDataSource skeletonPointerDataSource = null;
        private IRgbPointerDataSource rgbPointerDataSource = null;
        private UserGenerator userGenerator;
        public static SkeletonCapability skeletonCapbility;
        public static PoseDetectionCapability poseDetectionCapability;
        public static string calibPose;
        private OpenNIRunner runner;
        public static Dictionary<int, Dictionary<SkeletonJoint, SkeletonJointPosition>> joints;
        private ListBox textBoxKinectStatus;
      
        public OpenNIDataSourceFactory(string configFile,ListBox text)
        {
            textBoxKinectStatus = text;
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException("Config file is missing: " + configFile);
            }
            ScriptNode node = null;
            this.context = Context.CreateFromXmlFile(configFile, out node);
            this.context.ErrorStateChanged += context_ErrorStateChanged;

      
            this.userGenerator = new UserGenerator(this.context);

            OpenNIDataSourceFactory.skeletonCapbility = this.userGenerator.SkeletonCapability;
            OpenNIDataSourceFactory.poseDetectionCapability = this.userGenerator.PoseDetectionCapability;
            OpenNIDataSourceFactory.calibPose = OpenNIDataSourceFactory.skeletonCapbility.CalibrationPose;

            this.userGenerator.NewUser += userGenerator_NewUser;
            this.userGenerator.LostUser += userGenerator_LostUser;
            OpenNIDataSourceFactory.poseDetectionCapability.PoseDetected += poseDetectionCapability_PoseDetected;
            OpenNIDataSourceFactory.skeletonCapbility.CalibrationComplete += skeletonCapbility_CalibrationComplete;
            joints = new Dictionary<int, Dictionary<SkeletonJoint, SkeletonJointPosition>>();
            OpenNIDataSourceFactory.skeletonCapbility.SetSkeletonProfile(SkeletonProfile.All);
           
            this.userGenerator.GenerationRunningChanged += userGenerator_GenerationRunningChanged;

            this.userGenerator.StartGenerating();


            this.runner = new OpenNIRunner(this.context,textBoxKinectStatus);
         
            this.runner.Start();
        }


        public OpenNIDataSourceFactory(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException("Config file is missing: " + configFile);
            }
            ScriptNode node = null;
            this.context = Context.CreateFromXmlFile(configFile, out node);
            this.context.ErrorStateChanged += context_ErrorStateChanged;


            this.userGenerator = new UserGenerator(this.context);

            OpenNIDataSourceFactory.skeletonCapbility = this.userGenerator.SkeletonCapability;
            OpenNIDataSourceFactory.poseDetectionCapability = this.userGenerator.PoseDetectionCapability;
            OpenNIDataSourceFactory.calibPose = OpenNIDataSourceFactory.skeletonCapbility.CalibrationPose;

            this.userGenerator.NewUser += userGenerator_NewUser;
            this.userGenerator.LostUser += userGenerator_LostUser;
            OpenNIDataSourceFactory.poseDetectionCapability.PoseDetected += poseDetectionCapability_PoseDetected;
            OpenNIDataSourceFactory.skeletonCapbility.CalibrationComplete += skeletonCapbility_CalibrationComplete;
            joints = new Dictionary<int, Dictionary<SkeletonJoint, SkeletonJointPosition>>();
            OpenNIDataSourceFactory.skeletonCapbility.SetSkeletonProfile(SkeletonProfile.All);

            this.userGenerator.GenerationRunningChanged += userGenerator_GenerationRunningChanged;

            this.userGenerator.StartGenerating();


            this.runner = new OpenNIRunner(this.context, textBoxKinectStatus);

            this.runner.Start();
        }


        private void userGenerator_GenerationRunningChanged(object sender, EventArgs e)
        {
            textBoxKinectStatus.Text += e.ToString() + "\t" + DateTime.Now.ToString("T") + "\r\n";
        }

        private void context_ErrorStateChanged(object sender, ErrorStateEventArgs e)
        {
           // textBoxKinectStatus.Text += e.ToString() + "\t" + DateTime.Now + "\r\n";
            //text1 = e.ToString() + "\t" + DateTime.Now + "\r\n";
           // Console.WriteLine(text1);
        }


        void skeletonCapbility_CalibrationComplete(object sender, CalibrationProgressEventArgs e)
        {
            if (e.Status == CalibrationStatus.OK)
            {
                OpenNIDataSourceFactory.skeletonCapbility.StartTracking(e.ID);
                OpenNIDataSourceFactory.joints.Add(e.ID, new Dictionary<SkeletonJoint, SkeletonJointPosition>());
            }
            else if (e.Status != CalibrationStatus.ManualAbort)
            {
                if (OpenNIDataSourceFactory.skeletonCapbility.DoesNeedPoseForCalibration)
                {
                    OpenNIDataSourceFactory.poseDetectionCapability.StartPoseDetection(calibPose, e.ID);
                }
                else
                {
                    OpenNIDataSourceFactory.skeletonCapbility.RequestCalibration(e.ID, true);
                }
            }
        }

        void poseDetectionCapability_PoseDetected(object sender, PoseDetectedEventArgs e)
        {
            OpenNIDataSourceFactory.poseDetectionCapability.StopPoseDetection(e.ID);
            OpenNIDataSourceFactory.skeletonCapbility.RequestCalibration(e.ID, true);
        }

        void userGenerator_NewUser(object sender, NewUserEventArgs e)
        {
            if (OpenNIDataSourceFactory.skeletonCapbility.DoesNeedPoseForCalibration)
            {
                OpenNIDataSourceFactory.poseDetectionCapability.StartPoseDetection(OpenNIDataSourceFactory.calibPose, e.ID);
            }
            else
            {
                OpenNIDataSourceFactory.skeletonCapbility.RequestCalibration(e.ID, true);
            }
        }

        void userGenerator_LostUser(object sender, UserLostEventArgs e)
        {
            OpenNIDataSourceFactory.joints.Remove(e.ID);
        }

        public OpenNIRunner Runner
        {
            get { return this.runner; }
        }

        public Context Context
        {
            get { return this.context; }
        }

        public DepthGenerator GetDepthGenerator()
        {
            return this.context.FindExistingNode(NodeType.Depth) as DepthGenerator;
        }

        public UserGenerator GetUserGenerator() { 
          //  return this.context.FindExistingNode(NodeType.User) as UserGenerator;        
            return userGenerator;
        }

        public ImageGenerator GetImageGenerator()
        {
            return this.context.FindExistingNode(NodeType.Image) as ImageGenerator;
        }

        public IImageDataSource CreateRGBImageDataSource()
        {
            return new RgbImageDataSource(this.GetRGBPointerDataSource());
        }

        public IImageDataSource CreateDepthImageDataSource()
        {
            return new DepthImageDataSource(this.GetDepthPointerDataSource());
        }

        public IBitmapDataSource CreateRGBBitmapDataSource()
        {
            return new RGBBitmapDataSource(this.GetRGBPointerDataSource());
        }

        public IBitmapDataSource CreateDepthBitmapDataSource()
        {
            return new DepthBitmapDataSource(this.GetDepthPointerDataSource());
        }

        public ISkeletonDataSource CreateSkeletonDateSource()
        {
            return new OpenNISkeletonDataSource(this.GetSkeletonPointerDataSource());
        }

        public IClusterDataSource CreateClusterDataSource(ClusterDataSourceSettings clusterDataSourceSettings)
        {
            return new OpenNIClusterDataSource(this.GetDepthPointerDataSource(), clusterDataSourceSettings);
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

        private IDepthPointerDataSource GetDepthPointerDataSource()
        {
            lock (this)
            {
                if (this.depthPointerDataSource == null)
                {
                    var adapter = new DepthGeneratorAdapter(this.GetDepthGenerator());
                    this.runner.Add(adapter);
                    this.depthPointerDataSource = new DepthPointerDataSource(adapter);
                }
            }
            return this.depthPointerDataSource;
        }

        private ISkeletonPointerDataSource GetSkeletonPointerDataSource()
        {
            lock (this)
            {
                if (this.skeletonPointerDataSource == null)
                {
                    var adapter = new SkeletonGeneratorAdapter(this.GetUserGenerator());
                    this.runner.Add(adapter);
                    
                    this.skeletonPointerDataSource = new SkeletonPointerDataSource(adapter);
                }
            }
            return this.skeletonPointerDataSource;
        }

        

        private IRgbPointerDataSource GetRGBPointerDataSource()
        {
            lock (this)
            {
                if (this.rgbPointerDataSource == null)
                {
                    var adapter = new ImageGeneratorAdapter(this.GetImageGenerator());
                    this.runner.Add(adapter);
                    this.rgbPointerDataSource = new RgbPointerDataSource(adapter);
                }
            }
            return this.rgbPointerDataSource;
        }

        public void Dispose()
        {
            this.runner.Stop();
            this.context.Dispose();
        }

        public void SetAlternativeViewpointCapability()
        {
            this.GetDepthGenerator().AlternativeViewpointCapability.SetViewpoint(this.GetImageGenerator());
        }

        public TrackingClusterDataSource CreateTrackingClusterDataSource()
        {
            return new TrackingClusterDataSource(this.Context, this.GetDepthGenerator(), this.GetDepthPointerDataSource());
        }


        
    }
}
