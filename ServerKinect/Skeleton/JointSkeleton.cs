using ServerKinect.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Skeleton
{
    public class JointSkeleton
    {
        private string jointName;
        private Point jointPosition;

        public JointSkeleton(string name, Point p) {
            this.jointName = name;
            this.jointPosition = p;        
        }

        public string getJointName() { return jointName; }
        public Point getJointPosition() { return jointPosition; }
    }
}
