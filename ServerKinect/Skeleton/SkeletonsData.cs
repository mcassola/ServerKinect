using Microsoft.Kinect;
using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Skeleton
{
    public class SkeletonsData
    {
        private int skeletonId;
        private List<JointSkeleton> skeletonJoint;
      //  private  Point skeletonPosition;

        public SkeletonsData(int id) {
            this.skeletonId = id;
            skeletonJoint = new List<JointSkeleton>();
        }

        public Point getSkeletonPosition() {
            foreach (JointSkeleton joint in skeletonJoint)
            {
                if (joint.getJointName().ToString().Equals(JointType.ShoulderCenter.ToString()))
                    return joint.getJointPosition();
            }
            return new Point();
        }

        public void addJointSkeleton(JointSkeleton joint) {
            skeletonJoint.Add(joint);        
        }
        public int getSkeletonID() { return skeletonId; }

        public List<JointSkeleton> getSkeletonJoints() { return skeletonJoint; }

        public JointSkeleton getJointByName(string name) {
            foreach (JointSkeleton joint in skeletonJoint) {
                if (joint.getJointName().Equals(name))
                    return joint;
            }
            return null;
        }

        public override string ToString()
        {
           string data = skeletonId + "#";
           foreach (JointSkeleton joint in skeletonJoint) { 
                data += joint.getJointName() +";" + joint.getJointPosition().ToString().Replace(',','.') +"#" ;
           }
           return data;
        }
    }
}
