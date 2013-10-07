using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using OpenNI;
using System.Windows.Forms;

namespace ServerKinect.OpenNI
{
    public class OpenNIRunner 
    {
        private bool existing = false;
        private ConcurrentBag<IGenerator> generators;
        private ListBox textBoxKinectStatus;
        private Context context;
        private Thread thread;
        private bool run;

        public OpenNIRunner(Context context, ListBox textBox)
        {
            lock (typeof(OpenNIRunner))
            {
                if (existing)
                {
                    throw new NotSupportedException("Only one instance of OpenNIRunner must exist");
                }
                existing = true;
            }
            this.context = context;
            this.textBoxKinectStatus = textBox;
            this.generators = new ConcurrentBag<IGenerator>();
        }

        public void Add(IGenerator generator)
        {
            this.generators.Add(generator);
        }

        public bool IsRunning
        {
            get { return this.thread != null; }
        }

        public void Start()
        {
            this.thread = new Thread(new ThreadStart(Run));
            this.run = true;
            this.thread.Start();
        }


 
        public void Stop()
        {
            if (this.thread != null)
            {
                this.run = false;
                this.thread.Join();
                this.thread = null;
            }
        }

        [HandleProcessCorruptedStateExceptions]
        private void Run()
        {
            while (this.run)
            {
                try
                {
                    this.context.WaitAnyUpdateAll();
                    foreach (var generator in this.generators)
                    {
                        generator.Update();
                    }
                }
                catch (AccessViolationException)
                { }
                catch (SEHException)
                { }
                catch (Exception ex) {
                 //   Console.WriteLine("asdasd asds  " + ex.Message.ToString());
                }
            }
        }
    }
}
