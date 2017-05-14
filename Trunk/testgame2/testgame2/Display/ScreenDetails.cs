using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Display
{
    public class ScreenDetails
    {
        public float Width;
        public float Height;

        public float MiddleX
        {
            get { return Width / 2; }
        }

        public float MiddleY
        {
            get { return Height / 2; }
        }


    }
}
