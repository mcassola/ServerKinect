﻿using ServerKinect.Skeleton;
namespace Fizbin.Kinect.Gestures.Segments
{
    public class WaveRightSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // hand above elbow
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Y)
            {
                // hand right of elbow
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().X)
                {
                    return GesturePartResult.Succeed;
                }

                // hand has not dropped but is not quite where we expect it to be, pausing till next frame
                return GesturePartResult.Pausing;
            }

            // hand dropped - no gesture fails
            return GesturePartResult.Fail;
        }
    }

    public class WaveRightSegment2 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            // hand above elbow
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Y)
            {
                // hand right of elbow
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().X < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().X)
                {
                    return GesturePartResult.Succeed;
                }

                // hand has not dropped but is not quite where we expect it to be, pausing till next frame
                return GesturePartResult.Pausing;
            }

            // hand dropped - no gesture fails
            return GesturePartResult.Fail;
        }
    }
}
