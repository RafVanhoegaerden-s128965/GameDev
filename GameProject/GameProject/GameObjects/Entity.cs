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
    internal abstract class Entity : Object, ICombat, IMovable
    {
        // ICombat
        public DateTime LastHitTime { get; set; } = DateTime.MinValue;
        public bool IsAlive { get; set; } = true;
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Damage { get; set; }
        public bool IsDamaged { get; set; } = false;

        // IMovable
        public MovementManager MovementManager { get; set; } = new MovementManager();
        public Vector2 Speed { get; set; } =  new Vector2(1, 0);
        public Vector2 Direction { get; set; }
        public Vector2 Acceleration { get; set; } = new Vector2(0f, 0f);
        public SpriteEffects DirectionPosition { get; set; }
        public CurrentMovementState CurrentMovementState { get; set; }
    }
}
