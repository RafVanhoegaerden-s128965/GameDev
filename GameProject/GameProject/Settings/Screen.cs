using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Settings
{
    public class Screen
    {
        static public int Width { get; set; }
        static public int Height { get; set; }

        public Screen(int _width, int _height)
        {
            Width = _width;
            Height = _height;
        }

    }
}
