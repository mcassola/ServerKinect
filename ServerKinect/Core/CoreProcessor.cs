
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fizbin.Kinect.Gestures;
using Fizbin.Kinect.Gestures.Segments;
using Microsoft.Kinect;
using System.Collections;
using ServerKinect.OSCServer;
using ServerKinect.Video;
using ServerKinect.DataSource;
using ServerKinect.Clustering;
using ServerKinect.Shape;
using ServerKinect.HandTracking;
using ServerKinect.Skeleton;
using ServerKinect.Samples;
using ServerKinect.OpenNI;
using ServerKinect.SKDMicrosoft;
using ServerKinect.HandTracking.Visual;

namespace ServerKinect.Core
{
    public  class CoreProcessor
    {
        private OscServer server;
        private IBitmapDataSource imageSource;
        private IList<IDataSource> activeDataSources;
        private IDataSourceFactory dataSourceFactory;
        private VideoControl videoControl;
        private ClusterDataSourceSettings clusteringSettings = new ClusterDataSourceSettings();
        private ShapeDataSourceSettings shapeSettings = new ShapeDataSourceSettings();
        private HandDataSourceSettings handDetectionSettings = new HandDataSourceSettings();
        private ISkeletonDataSource SkeletonDataSource;
        private GestureController gestureController;
        private string Gesture ="";
        private HandLayer Hands;
        private Bitmap bufferBitmap;
        private Label serverStatus;
        private MainForm padre;
        private SkeletonDataSource bufferSkeletonData;
        public static int countPPS;
        public static string PPS = "0";

        public CoreProcessor(VideoControl video, OscServer server, Label label, MainForm padre) {
            this.server = server;
            this.padre = padre;
            this.serverStatus = label;
            this.serverStatus.Text = "Connected";
            this.videoControl = video;
            this.activeDataSources = new List<IDataSource>();
            InitializeGesture();
            //initTimer();
        }

      /*  private void initTimer()
        {
            this.timer = new System.Timers.Timer();
            // 
            // timer1
            // 
           
            this.timer.Enabled = true;
            this.timer.Interval =100D;
          //  this.timer.SynchronizingObject = this.padre;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (MainForm.serverConnected)
                sendUPDOSCDataImage();
        }*/


        public CoreProcessor(VideoControl video, Label label, MainForm padre)
        {
            this.padre = padre;
            this.videoControl = video;
            this.serverStatus = label;
            this.activeDataSources = new List<IDataSource>();
            InitializeGesture();
          //  initTimer();

        }

        public void addServer(OscServer server) {
            this.server = server;
            this.serverStatus.Text = "Connected";
        }

        private void InitializeGesture()
        {
            gestureController = new GestureController();
            gestureController.GestureRecognized += OnGestureRecognized;

            // register the gestures for this demo
            RegisterGestures();           
        }


        private void RegisterGestures()
        {
            // define the gestures for the demo

            IRelativeGestureSegment[] joinedhandsSegments = new IRelativeGestureSegment[20];
            JoinedHandsSegment1 joinedhandsSegment = new JoinedHandsSegment1();
            for (int i = 0; i < 20; i++)
            {
                // gesture consists of the same thing 10 times 
                joinedhandsSegments[i] = joinedhandsSegment;
            }
            gestureController.AddGesture("JoinedHands", joinedhandsSegments);

            IRelativeGestureSegment[] menuSegments = new IRelativeGestureSegment[20];
            MenuSegment1 menuSegment = new MenuSegment1();
            for (int i = 0; i < 20; i++)
            {
                // gesture consists of the same thing 20 times 
                menuSegments[i] = menuSegment;
            }
            gestureController.AddGesture("Menu", menuSegments);

            IRelativeGestureSegment[] swipeleftSegments = new IRelativeGestureSegment[3];
            swipeleftSegments[0] = new SwipeLeftSegment1();
            swipeleftSegments[1] = new SwipeLeftSegment2();
            swipeleftSegments[2] = new SwipeLeftSegment3();
            gestureController.AddGesture("SwipeLeft", swipeleftSegments);

            IRelativeGestureSegment[] swiperightSegments = new IRelativeGestureSegment[3];
            swiperightSegments[0] = new SwipeRightSegment1();
            swiperightSegments[1] = new SwipeRightSegment2();
            swiperightSegments[2] = new SwipeRightSegment3();
            gestureController.AddGesture("SwipeRight", swiperightSegments);
            /*
            IRelativeGestureSegment[] waveRightSegments = new IRelativeGestureSegment[6];
            WaveRightSegment1 waveRightSegment1 = new WaveRightSegment1();
            WaveRightSegment2 waveRightSegment2 = new WaveRightSegment2();
            waveRightSegments[0] = waveRightSegment1;
            waveRightSegments[1] = waveRightSegment2;
            waveRightSegments[2] = waveRightSegment1;
            waveRightSegments[3] = waveRightSegment2;
            waveRightSegments[4] = waveRightSegment1;
            waveRightSegments[5] = waveRightSegment2;
            gestureController.AddGesture("WaveRight", waveRightSegments);

            IRelativeGestureSegment[] waveLeftSegments = new IRelativeGestureSegment[6];
            WaveLeftSegment1 waveLeftSegment1 = new WaveLeftSegment1();
            WaveLeftSegment2 waveLeftSegment2 = new WaveLeftSegment2();
            waveLeftSegments[0] = waveLeftSegment1;
            waveLeftSegments[1] = waveLeftSegment2;
            waveLeftSegments[2] = waveLeftSegment1;
            waveLeftSegments[3] = waveLeftSegment2;
            waveLeftSegments[4] = waveLeftSegment1;
            waveLeftSegments[5] = waveLeftSegment2;
            gestureController.AddGesture("WaveLeft", waveLeftSegments);*/

            IRelativeGestureSegment[] zoomInSegments = new IRelativeGestureSegment[3];
            zoomInSegments[0] = new ZoomSegment1();
            zoomInSegments[1] = new ZoomSegment2();
            zoomInSegments[2] = new ZoomSegment3();
            gestureController.AddGesture("ZoomIn", zoomInSegments);

            IRelativeGestureSegment[] zoomOutSegments = new IRelativeGestureSegment[3];
            zoomOutSegments[0] = new ZoomSegment3();
            zoomOutSegments[1] = new ZoomSegment2();
            zoomOutSegments[2] = new ZoomSegment1();
            gestureController.AddGesture("ZoomOut", zoomOutSegments);

            IRelativeGestureSegment[] swipeUpSegments = new IRelativeGestureSegment[3];
            swipeUpSegments[0] = new SwipeUpSegment1();
            swipeUpSegments[1] = new SwipeUpSegment2();
            swipeUpSegments[2] = new SwipeUpSegment3();
            gestureController.AddGesture("SwipeUp", swipeUpSegments);

            IRelativeGestureSegment[] swipeDownSegments = new IRelativeGestureSegment[3];
            swipeDownSegments[0] = new SwipeDownSegment1();
            swipeDownSegments[1] = new SwipeDownSegment2();
            swipeDownSegments[2] = new SwipeDownSegment3();
            gestureController.AddGesture("SwipeDown", swipeDownSegments);
        }



        private void OnGestureRecognized(object sender, GestureEventArgs e)
        {
            switch (e.GestureName)
            {
                case "Menu":
                    Gesture = "Menu";
                    break;
                case "WaveRight":
                    Gesture = "Wave Right";
                    break;
                case "WaveLeft":
                    Gesture = "Wave Left";
                    break;
                case "JoinedHands":
                    Gesture = "Joined Hands";
                    break;
                case "SwipeLeft":
                    Gesture = "Swipe Left";
                    break;
                case "SwipeRight":
                    Gesture = "Swipe Right";
                    break;
                case "SwipeUp":
                    Gesture = "Swipe Up";
                    break;
                case "SwipeDown":
                    Gesture = "Swipe Down";
                    break;
                case "ZoomIn":
                    Gesture = "Zoom In";
                    break;
                case "ZoomOut":
                    Gesture = "Zoom Out";
                    break;

                default:
                    break;
            }
            padre.getListBoxGesture().Items.Add(Gesture + "\t" + DateTime.Now.ToString("T"));
        }

        public ClusterDataSourceSettings getClusteDataSourceSettings() { return clusteringSettings; }

        public ShapeDataSourceSettings getShapeDataSourceSettings() { return shapeSettings; }

        public HandDataSourceSettings getHandDataSourceSettings() { return handDetectionSettings; }
         

        public IList<IDataSource> getActiveDataSources() { return activeDataSources; }

        public IDataSourceFactory getDataSourceFactory() { return dataSourceFactory; }

        public void setDataSourceFactory(IDataSourceFactory data) { this.dataSourceFactory = data; }


        public void SetClusterDataSource(IClusterDataSource dataSource)
        {
            this.SetDataSource(dataSource, new ClusterLayer(dataSource));
        }

        public void SetHandDataSource(IHandDataSource dataSource)
        {
            this.SetDataSource(dataSource, new HandLayer(dataSource));
        }

        public void SetDataSource(IDataSource dataSource, ILayer layer)
        {
           // this.Clear();
            this.activeDataSources.Add(dataSource);
         //  this.videoControl.AddLayer(layer);
            this.AddLayer(layer);

            dataSource.Start();
        }


        private void AddLayer(ILayer layer)
        {
            layer.RequestRefresh += new EventHandler(layer_RequestRefresh);
          //  this.layers.Add(layer);
        }

        private void layer_RequestRefresh(object sender, EventArgs e)
        {
            Hands = (HandLayer)sender;
            if (Hands != null)
                Console.WriteLine( Hands.ToString());

           // foreach (HandData hand in Hands.getCurrentHandCollection().Hands)

           // Console.WriteLine(hand.FingerCount);
        }
       

        public void SetImageDataSource(IBitmapDataSource dataSource)
        {
            this.activeDataSources.Add(dataSource);
          // this.videoControl.SetImageSource(dataSource);
            this.SetImageSource(dataSource);
            dataSource.Start();
        }

        public void ImageStop(IBitmapDataSource imageSource) {
            this.Clear(imageSource.GetType().Name);

            if (this.imageSource != null)
            {
                if (imageSource.IsRunning)
                {

                    imageSource.NewDataAvailable -= new NewDataHandler<Bitmap>(imageSource_NewImageAvailable);

                    imageSource.Stop();
                }
            }
        }

        private void SetImageSource(IBitmapDataSource imageSource)
        {
            this.imageSource = imageSource;
            imageSource.NewDataAvailable += new NewDataHandler<Bitmap>(imageSource_NewImageAvailable);
        }


        void imageSource_NewImageAvailable(Bitmap newImage)
        {
            bufferBitmap = newImage;
            if (MainForm.serverConnected)
                sendUPDOSCData();          
        }
      

        private void sendUPDOSCData() {
            if (padre.canSendData())
            {
                // this.SetImage(newImage);
                // if (SDKRgbBitmapDataSource.ImageInUse && bufferBitmap != null)
                System.Drawing.Image image = null;
                if (bufferBitmap != null)
                {
                    image = bufferBitmap;
                }

                SkeletonDataSource skeletonDataTosend = null;
                if (bufferSkeletonData != null)
                {
                    skeletonDataTosend = bufferSkeletonData;
                    if (bufferSkeletonData.getSkeletons().Count > 0)
                    {
                        if (!MainForm.allSkeleton)
                        {
                            skeletonDataTosend = GetPrimarySkeleton(bufferSkeletonData);
                        }
                    }
                }




                if (Hands == null)
                    server.sendData(skeletonDataTosend, Gesture, "", image, PPS);
                else
                    server.sendData(skeletonDataTosend, Gesture, Hands.ToString(), image, PPS);
                countPPS++;
                SDKRgbBitmapDataSource.ImageInUse = false;
                Gesture = "";
                Hands = null;

                if (skeletonDataTosend != null)
                    foreach (SkeletonsData skeleton in skeletonDataTosend.getSkeletons())
                        gestureController.UpdateAllGestures(skeleton);
            }
            else {
               // MessageBox.Show("problem to send data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                padre.restartDataToSend();
            }
        }


        public void SetSkeletonDataSource(ISkeletonDataSource SkeletonDataSource)
        {
            
            this.activeDataSources.Add(SkeletonDataSource);
           
            this.SkeletonDataSource = SkeletonDataSource;

            SkeletonDataSource.NewDataAvailable += new NewDataHandler<SkeletonDataSource>(SkeletonDataSource_NewDataAvailable);

            SkeletonDataSource.Start();
        }

        public void skeletonStop(ISkeletonDataSource SkeletonDataSource)
        {
            this.Clear(SkeletonDataSource.GetType().Name);
            if (this.SkeletonDataSource != null)
            {
                SkeletonDataSource.NewDataAvailable -= new NewDataHandler<SkeletonDataSource>(SkeletonDataSource_NewDataAvailable);
                if (SkeletonDataSource.IsRunning)
                    SkeletonDataSource.Stop();
            }
        }

        //get the skeleton closest to the Kinect sensor
        private SkeletonDataSource GetPrimarySkeleton(SkeletonDataSource skeleton)
        {

            SkeletonsData skeletonData = null;
            List<SkeletonsData> Skeletons = skeleton.getSkeletons();
            foreach (SkeletonsData skel in Skeletons)
            {
                if (skeletonData == null)
                {
                    skeletonData = skel;
                }
                else
                {
                    if (skeletonData.getSkeletonPosition().Z > skel.getSkeletonPosition().Z)
                    {
                        skeletonData = skel;
                    }
                }
            
            }

            SkeletonDataSource s = new SkeletonDataSource();
            s.addSkeletonData(skeletonData);
            return s;
        }




        public void SkeletonDataSource_NewDataAvailable(SkeletonDataSource data)
        {
          
            padre.setSkeletonCount(data.getSkeletons().Count);
          //  if (data.getSkeletons().Count > 0)
          //  {
                bufferSkeletonData = data;
                if (!MainForm.sendAllData)
                    sendUPDOSCData();
           // }
            
        }

        public void Clear(string type)
        {
          
            foreach (var dataSource in new List<IDataSource>(this.activeDataSources))
            {
                if (dataSource.GetType().Name.Equals(type))
                {
                //    Console.WriteLine(dataSource.GetType().Name);
                    dataSource.Stop();
                    this.activeDataSources.Remove(dataSource);
                }
            }
            //this.activeDataSources.Clear();
           // this.videoControl.Clear();
        }

        public void Clear()
        {
            foreach (var dataSource in this.activeDataSources)
            {
                    dataSource.Stop(); 
            }
           this.activeDataSources.Clear();
            // this.videoControl.Clear();
        }

        public void InitializeOpenNI(ListBox text)
        {
           // try
            //{
                this.dataSourceFactory = new OpenNIDataSourceFactory("Config.xml",text);
          /*}
           catch (Exception exc)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }


    }
}
