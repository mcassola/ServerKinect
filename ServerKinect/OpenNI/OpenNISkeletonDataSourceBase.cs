using ServerKinect.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServerKinect.OpenNI
{
    public abstract class OpenNISkeletonDataSourceBase<TValue, TGenerator> : IDataSource<TValue>
        where TGenerator : ISkeletonGenerator
    {
        private TValue data;
        private TGenerator generator;
        private bool isRunning = false;
        private volatile bool isProcessing = false;

        public OpenNISkeletonDataSourceBase(TGenerator generator)
        {
            this.generator = generator;
        }

        protected TGenerator Generator
        {
            get { return this.generator; }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
        }

        public virtual TValue CurrentValue
        {
            get { return this.data; }
            protected set { this.data = value; }
        }

        public void Start()
        {
            if (!this.IsRunning)
            {
                this.generator.NewData += new EventHandler(generator_NewData);
                this.isRunning = true;
            }
        }

        public void Stop()
        {
            if (this.IsRunning)
            {
                this.generator.NewData -= new EventHandler(generator_NewData);
                this.isRunning = false;
            }
        }

        public virtual void Dispose()
        {
            this.Stop();
            SpinWait.SpinUntil(() => !isProcessing);
        }

        protected abstract unsafe void Run();

        protected void OnNewDataAvailable(TValue newData)
        {
            if (this.NewDataAvailable != null)
            {
                this.NewDataAvailable(newData);
            }
        }
        public event NewDataHandler<TValue> NewDataAvailable;

        void generator_NewData(object sender, EventArgs e)
        {
            isProcessing = true;
            this.Run();
            isProcessing = false;
        }
    }
}
