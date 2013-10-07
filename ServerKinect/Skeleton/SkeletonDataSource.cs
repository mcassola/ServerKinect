using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.Skeleton
{
    public class SkeletonDataSource
    {
        private List<SkeletonsData> skeletons;

        public SkeletonDataSource() { 
           skeletons = new List<SkeletonsData>();            
        }

        public void addSkeletonData(SkeletonsData skeleton) {
            skeletons.Add(skeleton);
        }

        public List<SkeletonsData> getSkeletons() { return skeletons; }

        public override string ToString()
        {
            string data ="";
            foreach (SkeletonsData skel in skeletons)
            {
               data += skel.ToString() + "/";
            
            }
            return data;
        }
    }
}
