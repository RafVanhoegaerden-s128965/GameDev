using GameProject.Animations;
using GameProject.Interface;
using GameProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects
{
    internal abstract class Object : IGameObject, IAnimatable
    {
        public Vector2 Position { get; set; }

        // ICollidable
        public Rectangle Hitbox { get; set; }
        public Rectangle BoundingBox { get; set; }

        // IAnimatable
        public AnimationManager AnimationManager { get; set; }
        public Texture2D IdleTexture { get; set; }
        public Animation IdleAnimation { get; set; }
        public Texture2D RunningTexture { get; set; }
        public Animation RunningAnimation { get; set; }
        public Texture2D AttackTexture { get; set; }
        public Animation AttackAnimation { get; set; }
    }
}
