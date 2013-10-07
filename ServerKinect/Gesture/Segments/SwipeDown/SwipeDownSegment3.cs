
using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    /// <summary>
    /// The third part of the swipe down gesture for the right hand
    /// </summary>
    public class SwipeDownSegment3 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // //Right hand in front of right Shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y)
            {
                // right hand below hip
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.HipRight.ToString()).getJointPosition().Y)
                {
                    // right hand right of right shoulder
                    if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.HipRight.ToString()).getJointPosition().X)
                    {
                        return GesturePartResult.Succeed;
                    }
                    return GesturePartResult.Pausing;
                }

                // Debug.WriteLine("GesturePart 2 - right hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

            // Debug.WriteLine("GesturePart 2 - Right hand in front of right Shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }
}