using GameProject.GameObjects;
using GameProject.Interface;
using GameProject.Settings;
using GameProject.StrategyPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Managers
{
    internal class MovementManager
    {
        public List<ICollidable> CollidableObjects { get; private set; }

        public MovementManager()
        {
            CollidableObjects = new List<ICollidable>();
        }

        public void Move(Entity entity)
        {
            entity.Speed += entity.Acceleration;
            entity.Direction *= entity.Speed;
            entity.Position += entity.Direction;

            // Collision with screen boundaries
            if (entity.Position.X > Screen.Width - (entity.IdleAnimation.CurrentFrame.SourceRectangle.Width) * 1.5f)
            {
                entity.Position = new Vector2(Screen.Width - (entity.IdleAnimation.CurrentFrame.SourceRectangle.Width) * 1.5f, entity.Position.Y);
            }
            else if (entity.Position.X <= 0)
            {
                entity.Position = new Vector2(0, entity.Position.Y);
            }
        }
    }
}
