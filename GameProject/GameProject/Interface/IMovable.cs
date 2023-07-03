using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface IMovable
    {
        public IInputReader InputReader { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Acceleration { get; set; }
    }
}
