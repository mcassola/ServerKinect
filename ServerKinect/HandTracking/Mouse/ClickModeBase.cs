using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerKinect.HandTracking.Mouse
{
    public abstract class ClickModeBase : IClickMode
    {
        public abstract void Process(HandCollection handData);

        protected void MouseUp()
        {
            UserInput.MouseUp();
        }

        protected void MouseDown()
        {
            UserInput.MouseDown();
        }

        public abstract ClickMode EnumValue
        {
            get;
        }
    }
}
