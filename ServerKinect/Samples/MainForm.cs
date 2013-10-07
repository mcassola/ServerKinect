using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Fizbin.Kinect.Gestures;
using Fizbin.Kinect.Gestures.Segments;
using System.Management;
using System.Net;
using ServerKinect.Core;
using ServerKinect.SKDMicrosoft;
using ServerKinect.HandTracking;
using ServerKinect.Samples.ImageManipulation;
using ServerKinect.Shape;
using ServerKinect.OpenNI;
using ServerKinect.OSCServer;
using ServerKinect.HandTracking.Visual;

namespace ServerKinect.Samples
{
    public partial class MainForm : Form
    {
        //private OscServer server;
        private CoreProcessor core;
        private bool kinectInitialized = false;
        // skeleton gesture recognizer
        private string driverVersion = "";
        public static List<kinectStatus> status;
        public static bool allSkeleton = false;
        public static bool serverConnected = false;
        public static bool sendAllData = false;
        private System.Timers.Timer timer1;
        public static int INTERVAL = 5000;
        private List<bool> clientConnected = new List<bool>();
        private OscServer server;

        public MainForm()
        {
            InitializeComponent();
            core = new CoreProcessor(videoControl, labelServerStatus, this);
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            status = new List<kinectStatus>();
            InitializeKinect();
            initTimerPPS();
            setLabelClientConnected();
            server = new OscServer();

        }

        private void initTimerPPS()
        {
            this.timer1 = new System.Timers.Timer();
            this.timer1.Enabled = true;
            this.timer1.Interval = INTERVAL;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
        }

        private void setLabelClientConnected()
        {
            if (server != null)
            {
                int i = 0;
                foreach (string oscWriter in server.getOscWriterList())
                {
                    int port = Convert.ToInt32(oscWriter.Split(':')[1]);
                    bool alreadyinuse = (from p in System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners() where p.Port == port select p).Count() == 1;
                    labelClientConnected.Text = alreadyinuse.ToString();
                    if (!clientConnected[i].Equals(alreadyinuse))
                    {
                        clientConnected[i] = alreadyinuse;
                        if (alreadyinuse)
                            listBoxLOG.Items.Add("Client Connected " + oscWriter + "  " + DateTime.Now.ToString("T"));
                        else
                            listBoxLOG.Items.Add("Client Disconnected " + oscWriter + "  " + DateTime.Now.ToString("T"));
                    }
                    i++;
                }
            }

        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int seg = INTERVAL / 1000;
            labelPPS.Text = (CoreProcessor.countPPS / seg).ToString();
            CoreProcessor.PPS = (CoreProcessor.countPPS / seg).ToString();
            CoreProcessor.countPPS = 0;

            setLabelClientConnected();
        }

        public void setSkeletonCount(int count)
        {
            this.labelSkeletonDetected.Text = count.ToString();

        }


        public CoreProcessor getCoreProcessor() { return core; }

        private void InitializeKinect()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                core.InitializeOpenNI(listBoxKinectStatus);
                //       radioButtonOpenNI.Checked = true;
                kinectInitialized = true;
                labelFramework.Text = "OpenNI V" + getDriverVersion("openNI");
                pictureBoxKinect.Image = ServerKinect.Properties.Resources.openNI1;
                listBoxKinectStatus.Items.Add("Connected" + "\t" + DateTime.Now.ToString("T"));
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message.ToString()); 
                try
                {
                    core.getClusteDataSourceSettings().MaximumDepthThreshold = 1000;
                    core.setDataSourceFactory(new SDKDataSourceFactory(listBoxKinectStatus, useNearMode: false));
                    //        radioButtonKinectWONear.Checked = true;
                    kinectInitialized = true;
                    pictureBoxKinect.Image = ServerKinect.Properties.Resources.kinect_0011;
                    labelFramework.Text = "Microsoft Kineck SDK V" + getDriverVersion("Microsoft");

                }
                catch (Exception exc)
                {
                    //Cursor.Current = Cursors.Default;
                    // MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelFramework.Text = "Not Detected";
                    pictureBoxKinect.Image = ServerKinect.Properties.Resources.kinectNotFound1;
                    string msg = exc.Message.ToString();
                    if (exc.Message.ToString().Contains("La secuencia"))
                        msg = "disconnected";

                    listBoxKinectStatus.Items.Add(msg + "\t" + DateTime.Now.ToString("T"));

                    return;
                }
            }

            labelFramework.SetBounds(splitContainer2.Panel1.Bounds.Width / 2 - labelFramework.Bounds.Width / 2, labelFramework.Bounds.Y, labelFramework.Bounds.Width, labelFramework.Bounds.Height);
            //  this.ToggleButtons();
            // this.buttonHandDataFactory.Enabled = true;
            Cursor.Current = Cursors.Default;

        }

        public ListBox getListBoxKinectStatus() { return listBoxKinectStatus; }

        public ListBox getListBoxGesture() { return listBoxGesture; }

        public ListBox getListBoxLOG() { return listBoxLOG; }

        private void buttonRGB_Click(object sender, EventArgs e)
        {
            core.SetImageDataSource(core.getDataSourceFactory().CreateRGBBitmapDataSource());

        }

        private void buttonDepth_Click(object sender, EventArgs e)
        {
            core.SetImageDataSource(core.getDataSourceFactory().CreateDepthBitmapDataSource());
        }

        private void buttonClustering_Click(object sender, EventArgs e)
        {
            core.SetClusterDataSource(core.getDataSourceFactory().CreateClusterDataSource(core.getClusteDataSourceSettings()));
        }

        private void SkeletonTrackingButton_Click(object sender, EventArgs e)
        {
            //core.SetHandDataSource(new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings()), core.getHandDataSourceSettings()));

            core.SetSkeletonDataSource(core.getDataSourceFactory().CreateSkeletonDateSource());


        }

        void layer_RequestRefresh(object sender, EventArgs e)
        {
            this.videoControl.Invalidate();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (core != null)
            {
                core.Clear();
                if (core.getDataSourceFactory() != null)
                {
                    core.getDataSourceFactory().Dispose();
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
        }

        //button Exit
        /*
         *            this.Close();
         * */

        //button settings
        /*
         *             new SettingsForm(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings(), core.getHandDataSourceSettings()).Show();
         *             
         * */

        //button clustering
        /*
         * 
         *             core.SetClusterDataSource(core.getDataSourceFactory().CreateClusterDataSource(core.getClusteDataSourceSettings()));

         * 
         * */

        private void buttonHandAndFinger_Click(object sender, EventArgs e)
        {
            core.SetHandDataSource(new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings()), core.getHandDataSourceSettings()));
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings(), core.getHandDataSourceSettings()).Show();
        }

        private void radioButtonSDK_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                core.setDataSourceFactory(new SDKDataSourceFactory());
            }
            catch (Exception exc)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.ToggleButtons();
            Cursor.Current = Cursors.Default;
        }

        private void ToggleButtons()
        {
            // this.Enable(this.buttonClustering, this.buttonDepth, this.buttonRGB, this.buttonHandAndFinger, this.buttonImageManipulation);
            // this.Disable(this.radioButtonOpenNI, this.radioButtonSDK, this.radioOpenNINite, this.radioButtonKinectWONear);
        }

        private void Enable(params Control[] controls)
        {
            this.SetEnabled(controls, true);
        }

        private void Disable(params Control[] controls)
        {
            this.SetEnabled(controls, false);
        }

        private void SetEnabled(IEnumerable<Control> controls, bool value)
        {
            foreach (var control in controls)
            {
                control.Enabled = value;
            }
        }

        private void radioButtonOpenNI_CheckedChanged(object sender, EventArgs e)
        {
            /* Cursor.Current = Cursors.WaitCursor;
             try
             {
                 core.InitializeOpenNI();
             }
             catch (Exception ex) { Console.WriteLine(ex.Message.ToString()); }
             this.ToggleButtons();
             this.buttonHandDataFactory.Enabled = true;
             Cursor.Current = Cursors.Default;*/
        }

        //button handTracking NITE
        /*
         * 
         *  core.SetImageDataSource(core.getDataSourceFactory().CreateDepthBitmapDataSource());
            var dataSource = (core.getDataSourceFactory() as OpenNIDataSourceFactory).CreateTrackingClusterDataSource();
            var handDataSource = new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(dataSource, core.getShapeDataSourceSettings()), core.getHandDataSourceSettings());
            core.getActiveDataSources().Add(handDataSource);
            var layer = new HandLayer(handDataSource);
            this.videoControl.AddLayer(layer);
            handDataSource.Start();
         * 
         * */

        //button handData source factory
        /*
         * 
         *     var factory = new HandDataFactory(new IntSize(640, 480));
            var handData = factory.Create((core.getDataSourceFactory() as OpenNIDataSourceFactory).GetDepthGenerator().DataPtr);
            MessageBox.Show(string.Format("{0} hands detected", handData.Count), "Detection Message");
        }
         * 
         * */

        //button image manipulation
        /*
         * 
         * 
            var dataSource = new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings()));
            new ImageForm(dataSource).Show();
            dataSource.Start();
         * 
         * */

        private void buttonImageManipulation_Click(object sender, EventArgs e)
        {
            var dataSource = new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings()));
            new ImageForm(dataSource).Show();
            dataSource.Start();
        }

        private void buttonHandDataFactory_Click(object sender, EventArgs e)
        {
            var factory = new HandDataFactory(new IntSize(640, 480));
            var handData = factory.Create((core.getDataSourceFactory() as OpenNIDataSourceFactory).GetDepthGenerator().DataPtr);
            MessageBox.Show(string.Format("{0} hands detected", handData.Count), "Detection Message");
        }

        private void buttonHandTracking_Click(object sender, EventArgs e)
        {
            core.SetImageDataSource(core.getDataSourceFactory().CreateDepthBitmapDataSource());
            var dataSource = (core.getDataSourceFactory() as OpenNIDataSourceFactory).CreateTrackingClusterDataSource();
            var handDataSource = new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(dataSource, core.getShapeDataSourceSettings()), core.getHandDataSourceSettings());
            core.getActiveDataSources().Add(handDataSource);
            var layer = new HandLayer(handDataSource);
            this.videoControl.AddLayer(layer);
            handDataSource.Start();
        }

        private void radioOpenNINite_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // this.Disable(this.radioButtonOpenNI, this.radioButtonSDK, this.radioButtonOpenNI);
            core.InitializeOpenNI(listBoxKinectStatus);
            //     this.buttonHandTracking.Enabled = true;
            //     this.buttonHandDataFactory.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void radioButtonKinectWONear_CheckedChanged(object sender, EventArgs e)
        {
            /*Cursor.Current = Cursors.WaitCursor;
            try
            {
                core.getClusteDataSourceSettings().MaximumDepthThreshold = 1000;
                core.setDataSourceFactory(new SDKDataSourceFactory(useNearMode: false));
            }
            catch (Exception exc)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.ToggleButtons();
            Cursor.Current = Cursors.Default;*/
        }

        private string getDriverVersion(string driver)
        {
            ManagementObjectSearcher searcher = null;
            if (driver.Equals("Microsoft"))
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPSignedDriver");
                ManagementObjectCollection moc = searcher.Get();
                foreach (var manObj in moc)
                {
                    if (manObj["DeviceID"].ToString().Contains("VID_045E&PID_02AE"))
                        // Console.WriteLine("Device Name: {0}\r\nDeviceID: {1}\r\nDriverDate: {2}\r\nDriverVersion: {3}\r\n==============================\r\n", manObj["FriendlyName"], manObj["DeviceID"], manObj["DriverDate"], manObj["DriverVersion"]);
                        driverVersion = manObj["DriverVersion"].ToString();

                }
            }
            else
                if (driver.Equals("openNI"))
                {
                    searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPSignedDriver where DeviceID LIKE '%VID_045E&PID_02AE%'");

                    ManagementObjectCollection moc = searcher.Get();
                    foreach (var manObj in moc)
                    {
                        //      if (manObj["DeviceID"].ToString().Contains("VID_045E&PID_02AE"))
                        // Console.WriteLine("Device Name: {0}\r\nDeviceID: {1}\r\nDriverDate: {2}\r\nDriverVersion: {3}\r\n==============================\r\n", manObj["FriendlyName"], manObj["DeviceID"], manObj["DriverDate"], manObj["DriverVersion"]);
                        driverVersion = manObj["DriverVersion"].ToString();

                    }

                }
            return driverVersion;
        }

        private void checkSendAllData()
        {
            if (((this.checkBoxDepthImage.Checked || this.checkBoxRGBImage.Checked)) && (this.checkBoxSkeleton.Checked))
            {
                sendAllData = true;
            }
            else
                sendAllData = false;
        }

        public bool canSendData()
        {
            foreach (string oscWriter in server.getOscWriterList())
            {
                int port = Convert.ToInt32(oscWriter.Split(':')[1]);
                bool alreadyinuse = (from p in System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners() where p.Port == port select p).Count() == 1;
                if (serverConnected && alreadyinuse && kinectInitialized)
                    return true;
            }
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkSendAllData();
            if (checkBoxRGBImage.Checked)
            {
                foreach (string oscWriter in server.getOscWriterList())
                {
                    int port = Convert.ToInt32(oscWriter.Split(':')[1]);
                    bool alreadyinuse = (from p in System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners() where p.Port == port select p).Count() == 1;

                    if (serverConnected && alreadyinuse && kinectInitialized)
                        core.SetImageDataSource(core.getDataSourceFactory().CreateRGBBitmapDataSource());
                    else
                    {
                        if (!serverConnected)
                            MessageBox.Show("Server Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            if (!alreadyinuse)
                                MessageBox.Show("Client Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                if (!kinectInitialized)
                                    MessageBox.Show("Kinect unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkBoxRGBImage.Checked = false;
                    }
                }
            }
            else
            {
                if (core.getDataSourceFactory() != null)
                    core.ImageStop(core.getDataSourceFactory().CreateRGBBitmapDataSource());
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkSendAllData();

            if (checkBoxDepthImage.Checked)
            {
                foreach (string oscWriter in server.getOscWriterList())
                {
                    int port = Convert.ToInt32(oscWriter.Split(':')[1]);
                    bool alreadyinuse = (from p in System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners() where p.Port == port select p).Count() == 1;

                    if (serverConnected && alreadyinuse && kinectInitialized)
                        core.SetImageDataSource(core.getDataSourceFactory().CreateDepthBitmapDataSource());
                    else
                    {
                        if (!serverConnected)
                            MessageBox.Show("Server Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            if (!alreadyinuse)
                                MessageBox.Show("Client Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                if (!kinectInitialized)
                                    MessageBox.Show("Kinect unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkBoxDepthImage.Checked = false;
                    }
                }
            }
            else
            {
                if (core.getDataSourceFactory() != null)
                    core.ImageStop(core.getDataSourceFactory().CreateDepthBitmapDataSource());
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHand.Checked)
            {
                foreach (string oscWriter in server.getOscWriterList())
                {
                    int port = Convert.ToInt32(oscWriter.Split(':')[1]);
                    bool alreadyinuse = (from p in System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners() where p.Port == port select p).Count() == 1;

                    if (serverConnected && alreadyinuse && kinectInitialized)
                        core.SetHandDataSource(new HandDataSource(core.getDataSourceFactory().CreateShapeDataSource(core.getClusteDataSourceSettings(), core.getShapeDataSourceSettings()), core.getHandDataSourceSettings()));
                    else
                    {
                        if (!serverConnected)
                            MessageBox.Show("Server Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            if (!alreadyinuse)
                                MessageBox.Show("Client Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                if (!kinectInitialized)
                                    MessageBox.Show("Kinect unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkBoxHand.Checked = false;
                    }
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkSendAllData();

            if (checkBoxSkeleton.Checked)
            {
                checkBoxHand.Enabled = true;
                foreach (string oscWriter in server.getOscWriterList())
                {
                    int port = Convert.ToInt32(oscWriter.Split(':')[1]);
                    bool alreadyinuse = (from p in System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners() where p.Port == port select p).Count() == 1;

                    if (serverConnected && alreadyinuse && kinectInitialized)
                    {
                        core.SetSkeletonDataSource(core.getDataSourceFactory().CreateSkeletonDateSource());
                    }
                    else
                    {
                        if (!serverConnected)
                            MessageBox.Show("Server Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            if (!alreadyinuse)
                                MessageBox.Show("Client Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                if (!kinectInitialized)
                                    MessageBox.Show("Kinect unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        checkBoxSkeleton.Checked = false;
                        checkBoxHand.Enabled = false;

                    }
                }
            }
            else
            {
                if (core.getDataSourceFactory() != null)
                    core.skeletonStop(core.getDataSourceFactory().CreateSkeletonDateSource());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!kinectInitialized)
                InitializeKinect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  if (!serverConnected)
            //  {
            server.addClient(textBoxHost.Text.ToString(), textBoxSend.Text.ToString());
            clientConnected.Add(false);
            core.addServer(server);
            this.videoControl.addServerControl(server);
            serverConnected = true;
            this.getListBoxLOG().Items.Add("Server Connected  " + textBoxHost.Text.ToString() + ":" + textBoxSend.Text.ToString() + "  " + DateTime.Now.ToString("T"));

            string text = "Server " + textBoxHost.Text.ToString() + ":" + textBoxSend.Text.ToString();
            this.comboBoxConnection.Items.Add(text);
            comboBoxConnection.Text = text;

            // button2.Text = "Disconnect";
            // button2.Image = CCT.NUI.Samples.Properties.Resources.disconnect; 
            //  }
            /*   else {
                   serverConnected = false;
                   this.getListBoxLOG().Items.Add("Server Disconnected" + "\t" + DateTime.Now.ToString("T"));
                   restartDataToSend();
                   button2.Text = "Connected";
                   labelServerStatus.Text = "Disconnected";
                   button2.Image = CCT.NUI.Samples.Properties.Resources.connect_icon; 
               }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new SettingServerKinect(this).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBoxGesture.Items.Clear();
            listBoxLOG.Items.Clear();
        }


        public void restartDataToSend()
        {
            if (checkBoxSkeleton.Checked)
                checkBoxSkeleton.Checked = false;
            if (checkBoxDepthImage.Checked)
                checkBoxDepthImage.Checked = false;
            if (checkBoxHand.Checked)
                checkBoxHand.Checked = false;
            if (checkBoxRGBImage.Checked)
                checkBoxRGBImage.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.comboBoxConnection.Items.Count > 0)
            {
                if (this.comboBoxConnection.SelectedItem != null)
                {
                    string udpWriterSelected = this.comboBoxConnection.SelectedItem.ToString();
                    if (!udpWriterSelected.Equals(""))
                    {

                        int index = this.comboBoxConnection.SelectedIndex;

                        this.comboBoxConnection.Items.RemoveAt(index);

                        if (this.comboBoxConnection.Items.Count == 0)
                        {
                            serverConnected = false;
                            labelServerStatus.Text = "Disconnected";
                            comboBoxConnection.Text = "";
                            restartDataToSend();

                        }
                        this.getListBoxLOG().Items.Add("Server Disconnected " + udpWriterSelected.Split(' ')[1] + "  " + DateTime.Now.ToString("T"));
                        server.removeClient(index);
                        clientConnected.RemoveAt(index);

                    }
                }
            }
        }
    }
}
