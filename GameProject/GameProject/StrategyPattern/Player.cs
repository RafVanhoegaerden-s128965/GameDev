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
    internal class Player : Entity, IControllable
    {
        // IControllable
        public IInputReader InputReader { get; set; }

        // IAnimatable
        public Texture2D AttackTexture { get; set; }
        public Animation AttackAnimation { get; set; }

        // Hitbox Texture
        public Texture2D TestHitboxTexture { get; set; }
    }
}
