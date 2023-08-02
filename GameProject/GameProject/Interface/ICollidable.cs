using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface ICollidable
    {
        public bool Passable { get; set; }
        public Rectangle Hitbox { get; set; }
        public Rectangle BoundingBox { get; set; }
    }
}
