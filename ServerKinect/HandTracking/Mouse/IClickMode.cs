using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.HandTracking.Mouse
{
    public interface IClickMode
    {
        void Process(HandCollection handData);

        ClickMode EnumValue { get; }
    }
}
