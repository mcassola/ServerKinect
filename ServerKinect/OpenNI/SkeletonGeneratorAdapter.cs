using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenNI;
using ServerKinect.Skeleton;
using ServerKinect.Shape;

namespace ServerKinect.OpenNI
{
    public class SkeletonGeneratorAdapter : GeneratorAdapterBase<UserGenerator>, ISkeletonGenerator
    {
       // private SkeletonCapability skeletonCapbility;
      //  private PoseDetectionCapability poseDetectionCapability;
      //  private string calibPose;
        
        public SkeletonGeneratorAdapter(UserGenerator generator)
            : base(generator)
        {
            /*this.skeletonCapbility = generator.SkeletonCapability;
            this.poseDetectionCapability = generator.PoseDetectionCapability;
            this.calibPose = this.skeletonCapbility.CalibrationPose;*/
        }

        private void GetJoints(SkeletonsData skel, int user)
        {
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.Head));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.Neck));

            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.LeftShoulder));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.LeftElbow));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.LeftHand));

            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.RightShoulder));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.RightElbow));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.RightHand));

            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.Torso));

            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.LeftHip));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.LeftKnee));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.LeftFoot));

            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.RightHip));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.RightKnee));
            skel.addJointSkeleton( GetJoint(user, SkeletonJoint.RightFoot));
        }

        private JointSkeleton GetJoint(int user, SkeletonJoint joint)
        {
            SkeletonJointPosition pos = OpenNIDataSourceFactory.skeletonCapbility.GetSkeletonJointPosition(user, joint);
            //VER COMO SE ACOMODA ESTA PROYECCION
            /*
            if (pos.Position.Z == 0)
            {
                pos.Confidence = 0;
            }
            else
            {
                
                pos.Position = this.depth.ConvertRealWorldToProjective(pos.Position);
            }*/
            return new JointSkeleton(this.getJointNormalized(joint), new Point(pos.Position.X, pos.Position.Y ,pos.Position.Z));

        }

        public String getJointNormalized(SkeletonJoint joint)
        {
            if (joint.Equals(SkeletonJoint.Head))
            {
                return jointsTypes.JointType.Head.ToString();
            }
            if (joint.Equals(SkeletonJoint.Neck))
            {
                return jointsTypes.JointType.ShoulderCenter.ToString();
            }
            if (joint.Equals(SkeletonJoint.LeftShoulder))
            {
                return jointsTypes.JointType.ShoulderLeft.ToString();
            }
            if (joint.Equals(SkeletonJoint.LeftElbow))
            {
                return jointsTypes.JointType.ElbowLeft.ToString();
            }
            if (joint.Equals(SkeletonJoint.LeftHand))
            {
                return jointsTypes.JointType.HandLeft.ToString();
            }
            if (joint.Equals(SkeletonJoint.RightShoulder))
            {
                return jointsTypes.JointType.ShoulderRight.ToString();
            }
            if (joint.Equals(SkeletonJoint.RightElbow))
            {
                return jointsTypes.JointType.ElbowRight.ToString();
            }
            if (joint.Equals(SkeletonJoint.RightHand))
            {
                return jointsTypes.JointType.HandRight.ToString();
            }
            if (joint.Equals(SkeletonJoint.Torso))
            {
                return jointsTypes.JointType.HipCenter.ToString();
            }
            if (joint.Equals(SkeletonJoint.LeftHip))
            {
                return jointsTypes.JointType.HipLeft.ToString();
            }
            if (joint.Equals(SkeletonJoint.LeftKnee))
            {
                return jointsTypes.JointType.KneeLeft.ToString();
            }
            if (joint.Equals(SkeletonJoint.LeftFoot))
            {
                return jointsTypes.JointType.FootLeft.ToString();
            }
            if (joint.Equals(SkeletonJoint.RightHip))
            {
                return jointsTypes.JointType.HipRight.ToString();
            }
            if (joint.Equals(SkeletonJoint.RightKnee))
            {
                return jointsTypes.JointType.KneeRight.ToString();
            }
            if (joint.Equals(SkeletonJoint.RightFoot))
            {
                return jointsTypes.JointType.FootRight.ToString();
            }
            return null;
        }

        public SkeletonDataSource SkeletonData()
        {
           SkeletonDataSource data = new SkeletonDataSource();
           foreach (int user in this.Generator.GetUsers())
           {
               if (OpenNIDataSourceFactory.skeletonCapbility.IsTracking(user))
               {
                   SkeletonsData skeleton = new SkeletonsData(user);
                   GetJoints(skeleton, user);
                   data.addSkeletonData(skeleton);
               }
           }
          //  data.addSkeletonData(new SkeletonsData(25));
           return data;
        }


    }
}
