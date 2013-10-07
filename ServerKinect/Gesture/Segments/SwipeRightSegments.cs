
using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    /// <summary>
    /// The first part of the swipe right gesture
    /// </summary>
    public class SwipeRightSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // //left hand in front of left Shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
            {
                // Debug.WriteLine("GesturePart 0 - left hand in front of left Shoulder - PASS");
                // //left hand below shoulder height but above hip height
                if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.Head.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // Debug.WriteLine("GesturePart 0 - left hand below shoulder height but above hip height - PASS");
                    // //left hand left of left Shoulder
                    if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X)
                    {
                        // Debug.WriteLine("GesturePart 0 - left hand left of left Shoulder - PASS");
                        return GesturePartResult.Succeed;
                    }

                    // Debug.WriteLine("GesturePart 0 - left hand left of left Shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }

                // Debug.WriteLine("GesturePart 0 - left hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

            // Debug.WriteLine("GesturePart 0 - left hand in front of left Shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }

    /// <summary>
    /// The second part of the swipe right gesture
    /// </summary>
    public class SwipeRightSegment2 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // //left hand in front of left Shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
            {
                // Debug.WriteLine("GesturePart 1 - left hand in front of left Shoulder - PASS");
                // /left hand below shoulder height but above hip height
                if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.Head.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // Debug.WriteLine("GesturePart 1 - left hand below shoulder height but above hip height - PASS");
                    // //left hand left of left Shoulder
                    if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderLeft.ToString()).getJointPosition().X)
                    {
                        // Debug.WriteLine("GesturePart 1 - left hand left of left Shoulder - PASS");
                        return GesturePartResult.Succeed;
                    }

                    // Debug.WriteLine("GesturePart 1 - left hand left of left Shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }

                // Debug.WriteLine("GesturePart 1 - left hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

            // Debug.WriteLine("GesturePart 1 - left hand in front of left Shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }

    /// <summary>
    /// The third part of the swipe right gesture
    /// </summary>
    public class SwipeRightSegment3 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // //left hand in front of left Shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowLeft.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
            {
                // //left hand below shoulder height but above hip height
                if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.Head.ToString()).getJointPosition().Y && skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.HipCenter.ToString()).getJointPosition().Y)
                {
                    // //left hand left of left Shoulder
                    if (skeleton.getJointByName(jointsTypes.JointType.HandLeft.ToString()).getJointPosition().X > skeleton.getJointByName(jointsTypes.JointType.ShoulderRight.ToString()).getJointPosition().X)
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
