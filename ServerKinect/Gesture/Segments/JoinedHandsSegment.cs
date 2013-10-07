

using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    public class JoinedHandsSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // Right and Left Hand in front of Shoulders
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z)
            {
                // Hands between shoulder and hip
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y &&
                    skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // Hands between shoulders
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X &&
                        skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X)
                    {
                        // Hands very close
                        if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X - skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < 0)
                        {
                            return GesturePartResult.Succeed;
                        }

                        return GesturePartResult.Pausing;
                    }

                    return GesturePartResult.Fail;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }

        /*
         *  public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // Right and Left Hand in front of Shoulders
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z)
            {
                // Hands between shoulder and hip
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
                {
                    // Hands between shoulders
                    if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                        skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X && skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X)
                    {
                        // Hands very close
                        if (skeleton.Joints[JointType.HandRight].Position.X - skeleton.Joints[JointType.HandLeft].Position.X < 0)
                        {
                            return GesturePartResult.Succeed;
                        }

                        return GesturePartResult.Pausing;
                    }

                    return GesturePartResult.Fail;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }*/

    }
}
