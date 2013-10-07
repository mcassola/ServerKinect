
using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    /// <summary>
    /// The menu gesture segment
    /// </summary>
    public class MenuSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // Left and right hands below hip
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
            {
                // left hand 0.3 to left of center hip
                if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().X - 0.3)
                {
                    // left hand 0.2 to left of left elbow
                    if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().X - 0.2)
                    {
                        return GesturePartResult.Succeed;
                    }
                }

                return GesturePartResult.Pausing;
            }

            return GesturePartResult.Fail;
        }
    }
}
