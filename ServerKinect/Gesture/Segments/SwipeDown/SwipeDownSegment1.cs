﻿using ServerKinect.Skeleton;
using System.Diagnostics;

namespace Fizbin.Kinect.Gestures.Segments
{
    /// <summary>
    /// The first part of the swipe down gesture with the right hand
    /// </summary>
    public class SwipeDownSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonsData skeleton)
        {
            
            // right hand in front of right shoulder
            if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Z < skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.ShoulderCenter.ToString()).getJointPosition().Y)
            {
                // right hand below head height and hand higher than elbow
                if (skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y < skeleton.getJointByName(jointsTypes.JointType.Head.ToString()).getJointPosition().Z && skeleton.getJointByName(jointsTypes.JointType.HandRight.ToString()).getJointPosition().Y > skeleton.getJointByName(jointsTypes.JointType.ElbowRight.ToString()).getJointPosition().Y)
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
}