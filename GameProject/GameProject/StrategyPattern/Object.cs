using GameProject.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.StrategyPattern
{
    internal class Object : IGameObject
    {
        // ICollidable
        public Rectangle Hitbox { get; set; }
    }
}
