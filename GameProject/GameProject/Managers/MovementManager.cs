using GameProject.GameObjects;
using GameProject.Interface;
using GameProject.Settings;
using GameProject.StrategyPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            if (entity.Position.Y > Screen.Height - (entity.RunningAnimation.CurrentFrame.SourceRectangle.Height) * 1.5f) // BOTTOM
            {
                entity.Position = new Vector2(entity.Position.X, Screen.Height - (entity.RunningAnimation.CurrentFrame.SourceRectangle.Height) * 1.5f);
            }
        }
        public void Jump(Player entity)
        {
            entity.StartY = entity.Position.Y;
            // credits => https://flatformer.blogspot.com/
            if (entity.IsJumping)
            {
                entity.Position += new Vector2(0, entity.JumpSpeed);
                entity.JumpSpeed += 1;

                if (entity.Position.Y >= entity.StartY)
                //If it's farther than ground
                {
                    entity.Speed = new Vector2(entity.Speed.X, entity.StartY); // Then set it on
                    entity.IsJumping = false;
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && !entity.IsFalling)
                {
                    entity.IsJumping = true;
                    entity.IsFalling = false;
                    entity.JumpSpeed = -18; // Give it upward thrust
                }
            }
        }
    }
}
