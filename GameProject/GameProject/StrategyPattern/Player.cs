using GameProject.Animations;
using GameProject.Interface;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.StrategyPattern
{
    internal class Player : Entity, IControllable, IJumpable
    {
        // IControllable
        public IInputReader InputReader { get; set; }

        // IAnimatable
        public Texture2D AttackTexture { get; set; }
        public Animation AttackAnimation { get; set; }

        // IJumpable
        public float StartY { get; set; }
        public float JumpSpeed { get; set; }
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }

        // Hitbox Texture
        public Texture2D TestHitboxTexture { get; set; }
    }
}
