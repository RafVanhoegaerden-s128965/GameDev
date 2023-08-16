using GameProject.Animations;
using GameProject.Interface;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Playable
{
    internal class Player : Entity, IControllable, IJumpable, IActivatePowerUp
    {
        public float GravityFactor { get; set; }

        // IActivatePowerUp
        public bool JumpPowerUpActive { get; set; } = false;
        public int JumpEffect { get; set; }
        public bool HealthPowerUpActive { get; set; } = false;
        public int HealthEffect { get; set; }
        public bool HealthEffectApplied { get; set; }
        public bool AttackPowerUpActive { get; set; } = false;
        public int AttackEffect { get; set; }

        // IControllable
        public IInputReader InputReader { get; set; }

        // Hitbox Texture
        public Texture2D TestHitboxTexture { get; set; }

    }
}
