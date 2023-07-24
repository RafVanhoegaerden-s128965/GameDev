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
        public void Move(Entity entity)
        {
            entity.Speed += entity.Acceleration;
            entity.Direction *= entity.Speed;
            entity.Position += entity.Direction;

            // Collision with screen boundaries

            //if (entity.Position.X > Screen.Width - (entity.RunningAnimation.CurrentFrame.SourceRectangle.Width) * 1.5f) // RIGHT
            //{
            //    entity.Position = new Vector2(Screen.Width - (entity.RunningAnimation.CurrentFrame.SourceRectangle.Width) * 1.5f, entity.Position.Y);
            //}
            //else if (entity.Position.X <= 0) // LEFT
            //{
            //    entity.Position = new Vector2(0, entity.Position.Y);
            //}
            //else if (entity.Position.Y <= 0) // TOP
            //{
            //    entity.Position = new Vector2(entity.Position.X, 0);
            //}
            //else if (entity.Position.Y > Screen.Height - (entity.RunningAnimation.CurrentFrame.SourceRectangle.Height) * 1.5f) // BOTTOM
            //{
            //    entity.Position = new Vector2(entity.Position.X, Screen.Height - (entity.RunningAnimation.CurrentFrame.SourceRectangle.Height) * 1.5f);
            //}
        }
    }
}
