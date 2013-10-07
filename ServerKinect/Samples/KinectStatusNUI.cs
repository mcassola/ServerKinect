using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Summary:
//     Status of the KinectSensor.
public enum KinectStatus
{
    // Summary:
    //     The status is undefined.
    Undefined = 0,
    //
    // Summary:
    //     USB unplugged or device not found.
    Disconnected = 1,
    //
    // Summary:
    //     Kinect is fully connected and ready to use.
    Connected = 2,
    //
    // Summary:
    //     The device has been attached and is initializing.
    Initializing = 3,
    //
    // Summary:
    //     The device returned an unexpected error.
    Error = 4,
    //
    // Summary:
    //     Audio not found. Device likely unpowered.
    NotPowered = 5,
    //
    // Summary:
    //     Some part of the devices is not connected.
    NotReady = 6,
    //
    // Summary:
    //     This device is not a genuine Kinect.
    DeviceNotGenuine = 7,
    //
    // Summary:
    //     This device is not supported.
    DeviceNotSupported = 8,
    //
    // Summary:
    //     There is not enough bandwidth on the USB hub.
    InsufficientBandwidth = 9,
}


namespace ServerKinect.Samples
{
    public class kinectStatus
    {
        public string Id { get; set; }

        public DateTime DateTime { get; set; }
    }
}
