using ServerKinect.Clustering;
using ServerKinect.Shape;
using ServerKinect.Skeleton;
using ServerKinect.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ServerKinect.DataSource
{
    public interface IDataSourceFactory : IDisposable
    {
        IBitmapDataSource CreateRGBBitmapDataSource();

        IBitmapDataSource CreateDepthBitmapDataSource();

        IImageDataSource CreateDepthImageDataSource();

        IImageDataSource CreateRGBImageDataSource();

        IClusterDataSource CreateClusterDataSource();

        ISkeletonDataSource CreateSkeletonDateSource();

        IClusterDataSource CreateClusterDataSource(ClusterDataSourceSettings clusterDataSourceSettings);

        IShapeDataSource CreateShapeDataSource();

        IShapeDataSource CreateShapeDataSource(IClusterDataSource clusterdataSource);

        IShapeDataSource CreateShapeDataSource(IClusterDataSource clusterdataSource, ShapeDataSourceSettings shapeDataSourceSettings);

        IShapeDataSource CreateShapeDataSource(ClusterDataSourceSettings clusterDataSourceSettings, ShapeDataSourceSettings shapeDataSourceSettings);
    }
}
