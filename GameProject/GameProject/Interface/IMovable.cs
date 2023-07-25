using GameProject.Animations;
using GameProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    public enum CurrentMovementState { Idle, Running, Jumping, Attacking }
    internal interface IMovable
    {
        public MovementManager MovementManager { get; set; }
        public Texture2D RunningTexture { get; set; }
        public Animation RunningAnimation { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Acceleration { get; set; }
        public SpriteEffects DirectionPosition { get; set; }
        public CurrentMovementState CurrentMovementState { get; set; }




        public bool IsMoving { get; set; }
    }
}
