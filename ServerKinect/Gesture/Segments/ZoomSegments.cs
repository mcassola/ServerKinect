
using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    public class ZoomSegment1 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // Right and Left Hand in front of Shoulders
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z)
            {
                //Debug.WriteLine("Zoom 0 - Right hand in front of right shoudler - PASS");

                // Hands between shoulder and hip
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y &&
                    skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // Hands between shoulders
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X &&
                        skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X)
                    {
                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }
    }

    public class ZoomSegment2 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // Right and Left Hand in front of Shoulders
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z)
            {
                // Hands between shoulder and hip
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y &&
                    skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // Hands outside shoulders
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X)
                    {
                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }
    }

    public class ZoomSegment3 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // Right and Left Hand in front of Shoulders
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z)
            {
                // Hands between shoulder and hip
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y &&
                    skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // Hands outside elbows
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().X)
                    {
                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }
    }
}
