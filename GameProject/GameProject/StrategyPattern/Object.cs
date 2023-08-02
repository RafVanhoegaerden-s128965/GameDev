using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.StrategyPattern
{
    internal class Object : IGameObject
    {
        public Vector2 Position { get; set; }

        // ICollidable
        public Rectangle Hitbox { get; set; }
    }
}
