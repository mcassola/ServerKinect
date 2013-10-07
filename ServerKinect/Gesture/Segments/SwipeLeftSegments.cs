
using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    /// <summary>
    /// The first part of the swipe left gesture
    /// </summary>
    public class SwipeLeftSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {

            // right hand in front of right shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y)
            {
                // right hand below shoulder height but above hip height
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.Head.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // right hand right of right shoulder
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X)
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

    /// <summary>
    /// The second part of the swipe left gesture
    /// </summary>
    public class SwipeLeftSegment2 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // right hand in front of right shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y)
            {
                // right hand below shoulder height but above hip height
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.Head.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // right hand left of right shoulder & right of left shoulder
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X)
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

    /// <summary>
    /// The third part of the swipe left gesture
    /// </summary>
    public class SwipeLeftSegment3 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // //Right hand in front of right Shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y)
            {
                // //right hand below shoulder height but above hip height
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // //right hand left of center hip
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X)
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
