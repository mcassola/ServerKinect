
using Microsoft.Kinect;
using ServerKinect.HandTracking.Visual;
using ServerKinect.Skeleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Ventuz.OSC;

namespace ServerKinect.OSCServer
{
    public class OscServer
    {
        private List<string> oscWriterListString = new List<string>();
        private static List<UdpWriter> oscWriterList = new List<UdpWriter>();
        private static UdpReader oscReader;
        private static string[] oscArgs = new string[3];
        public bool sending;
        private bool oscVideo = false;
        private Thread sendThread;
        private int countFrame = 0;

        public OscServer()
        {



            //oscReader = new UdpReader(3002);
        }

        public List<string> getOscWriterList() {
            return oscWriterListString;
         }
        public void removeClient(int index)
        {
            oscWriterListString.RemoveAt(index);
            UdpWriter udp = oscWriterList.ElementAt(index);
            udp.Dispose();
            oscWriterList.RemoveAt(index);
        }

        public void addClient(string host, string send)
        {
            string[] Args = new string[2];
            Args[0] = host;
            Args[1] = send;


            //guardar el puerto asi no se conecta 2 veces
            foreach (String oscWriter in oscWriterListString)
            {
                if (!(oscWriter.Contains(host) && oscWriter.Contains(send)))
                {
                    oscWriterList.Add(new UdpWriter(Args[0], Convert.ToInt32(Args[1])));
                    oscWriterListString.Add(Args[0] + ":" + Args[1]);
                    return;
                }
            }

            if (oscWriterList.Count == 0)
            {
                oscWriterList.Add(new UdpWriter(Args[0], Convert.ToInt32(Args[1])));
                oscWriterListString.Add(Args[0] + ":" + Args[1]);
            }
        }

        /*******************************************************************************************/
        /* PARA RECORTAR EL DEPTH EN Z!!!!!!!!!!!!!!!!!
         * 
         *
                  BitmapSource depthBmp = null;
           
                        depthBmp = depthFrame.SliceDepthImage((int)sliderMin.Value, (int)sliderMax.Value);
        /***************************************************************************************/

        /* public void sendImage(object state)
         {
             sending = true;
             sendThread = new Thread(sendDataThread);
             sendThread.Name = "hilo " + countFrame;
             sendThread.IsBackground = true;
             sendThread.Priority = ThreadPriority.Highest;
             sendThread.Start(state);
         }*/

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }



        private byte[] sendImage(System.Drawing.Image tempData)// private void sendDataThread(object tempData)
        {
            if (tempData != null)
            {
                var image = tempData;
                //  image.Save("Shapes0.jpg");

                //OscImage imageToSend1 = new OscImage(image);
                //byte[] data1 = imageToSend1.data;
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                ImageCodecInfo myImageCodecInfo = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;

                // Create an Encoder object based on the GUID 
                // for the Quality parameter category.
                myEncoder = System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object. 
                // An EncoderParameters object has an array of EncoderParameter 
                // objects. In this case, there is only one 
                // EncoderParameter object in the array.
                myEncoderParameters = new EncoderParameters(1);

                // Save the bitmap as a JPEG file with quality level 25.
                /* myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                 myEncoderParameters.Param[0] = myEncoderParameter;
                 image.Save("Shapes025.jpg", myImageCodecInfo, myEncoderParameters);

                 // Save the bitmap as a JPEG file with quality level 50.
                 myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                 myEncoderParameters.Param[0] = myEncoderParameter;
                 image.Save("Shapes050.jpg", myImageCodecInfo, myEncoderParameters);*/

                // Save the bitmap as a JPEG file with quality level 75.
                myEncoderParameter = new EncoderParameter(myEncoder, 75L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                //  image.Save("Shapes075.jpg", myImageCodecInfo, myEncoderParameters);
                image.Save(stream, myImageCodecInfo, myEncoderParameters);

                byte[] imageBytes = stream.ToArray();
                stream.Dispose();
                countFrame++;

                /* OscImage imageToSend = new OscImage(image);
                  byte[] data = imageToSend.data;
                 int totalBytes = data.Length;*/
                return imageBytes;
            }
            return null;

        }


        public void sendData(SkeletonDataSource data, string gesture, HandLayer hands, System.Drawing.Image image, string pps, string kinectStatus)
        {
            string infoPackage = "";

            Object[] args2 = new Object[7];
            args2[0] = (string)DateTime.Now.Millisecond.ToString();

            if (data != null)
            {
                args2[1] = (string)data.ToString();
                infoPackage += "/Skeleton";
            }
            else
                args2[1] = "not skeleton";

            args2[2] = (string)gesture;

            if (hands != null)
                args2[3] = (string)hands.ToString();
            else
                args2[3] = "";


            byte[] imageToSend = sendImage(image);

            if (imageToSend != null)
            {
                args2[4] = (byte[])imageToSend;
                infoPackage += "/video/color";
            }
            else
                args2[4] = "not image";

            args2[5] = (string)pps;

            if (infoPackage == "")
                infoPackage += "/status";
            args2[6] = (string)kinectStatus;

            OscElement elem2 = new OscElement(infoPackage, args2);//imageToSend.data);
            foreach (UdpWriter oscWriter in oscWriterList)
                oscWriter.Send(new OscBundle(DateTime.Now, elem2));

            // Console.WriteLine(countFrame + " send video/color");
            sending = false;

        }
    }
}
