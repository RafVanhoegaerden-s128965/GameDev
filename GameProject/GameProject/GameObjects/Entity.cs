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
    internal abstract class Entity : Object, ICombat, IMovable, IJumpable, IAnimatable
    {
        // Managers
        public MovementManager MovementManager { get; set; }
        public AnimationManager AnimationManager { get; set; }

        // ICombat
        public bool IsAlive { get; set; } = true;
        public int HP { get; set; }
        public int Damage { get; set; }
        public bool IsDamaged { get; set; } = false;

        // IMovable
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Acceleration { get; set; }
        public SpriteEffects DirectionPosition { get; set; }
        public CurrentMovementState CurrentMovementState { get; set; }

        // IJumpable
        public float StartY { get; set; }
        public float JumpSpeed { get; set; }
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }

        //// IAnimatable
        public Texture2D IdleTexture { get; set; }
        public Animation IdleAnimation { get; set; }
        public Texture2D RunningTexture { get; set; }
        public Animation RunningAnimation { get; set; }
        public Texture2D AttackTexture { get; set; }
        public Animation AttackAnimation { get; set; }
    }
}
