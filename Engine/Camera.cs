using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    public class Camera
    {
        public int Scale { get; private set; }
        public Size Bounds { get; private set; }
        public Point Location { get; private set; }

        public Camera(Point location, Size bounds, int scale)
        {
            Location = location;
            Bounds = bounds;
            Scale = scale;
        }

        public void ChangeScale(int newScale)
        {
            Scale = newScale;
        }

        public void Reshape(Size newBounds)
        {
            Bounds = newBounds;
        }

        public void Relocate(Point newLocation)
        {
            Location = newLocation;
        }
    }
}
