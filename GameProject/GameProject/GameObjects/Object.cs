using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects
{
    internal abstract class Object : IGameObject
    {
        public Texture2D Texture;
        public Vector2 Position { get; set; }

        // ICollidable
        public bool Passable { get; set; }
        public Rectangle Hitbox { get; set; }
        public Rectangle BoundingBox { get; set; }
    }
}
