using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServerKinect.Video;
using ServerKinect.SKDMicrosoft;


namespace ServerKinect.Samples
{
    public partial class SettingServerKinect : Form
    {
        private MainForm padre;
        private System.Timers.Timer timer;
        private int INTERVAL = 2000;
        private int lastAngleElevation;

        public SettingServerKinect(MainForm p)
        {
            this.padre = p;
            InitializeComponent();
            if (padre.getCoreProcessor().getDataSourceFactory() != null)
            {
                setElevationAngle();
                initVideoControl();
            }
            else {
                trackBar1.Enabled = false;
            }
        }

        private void initVideoControl() {
            IBitmapDataSource dataSource = padre.getCoreProcessor().getDataSourceFactory().CreateRGBBitmapDataSource();

            this.padre.getCoreProcessor().getActiveDataSources().Add(dataSource);
            this.videoControlSetting.SetImageSource(dataSource); 
            dataSource.Start();
        }

        private void initTimerAngleElevation()
        {
            this.timer = new System.Timers.Timer();
            this.timer.Enabled = true;
            this.timer.Interval = INTERVAL;
            this.timer.SynchronizingObject = this;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lastAngleElevation != trackBar1.Value)
                ((SDKDataSourceFactory)padre.getCoreProcessor().getDataSourceFactory()).setTiltAngleElevation(trackBar1.Value);
        }

        private void setElevationAngle() {           
            string type = padre.getCoreProcessor().getDataSourceFactory().GetType().Name;
            if (type.Equals("SDKDataSourceFactory"))
            {
                int angle = ((SDKDataSourceFactory)padre.getCoreProcessor().getDataSourceFactory()).getTiltAngleElevation();
                textBoxSlider.Text = angle.ToString();
                this.trackBar1.Value = angle;
                lastAngleElevation = angle;
                initTimerAngleElevation();
            }
            else
            {
                trackBar1.Enabled = false;
            }            
        }


        private void saveData() {
            MainForm.allSkeleton = getButtonChecked();
            if (this.timer != null)
                this.timer.Elapsed -= new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveData();
            this.Dispose();
        }

        private bool getButtonChecked() {
            if (checkBox1.Checked)
                return true;
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          //  ((SDKDataSourceFactory)padre.getCoreProcessor().getDataSourceFactory()).setTiltAngleElevation(trackBar1.Value);
            textBoxSlider.Text = trackBar1.Value.ToString();
        }

        private void SettingServerKinect_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }

       


      
    }
}
