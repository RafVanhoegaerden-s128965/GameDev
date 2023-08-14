using GameProject.GameObjects;
using GameProject.GameObjects.Playable;
using GameProject.Interface;
using GameProject.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine($"Position: {entity.Position} // Direction: {entity.Direction}");
        }
        public void Jump(Player entity)
        {
            // credits => https://flatformer.blogspot.com/
            if (entity.IsJumping)
            {
                entity.StartY = entity.Position.Y;
                entity.Position += new Vector2(0, entity.JumpSpeed);
                entity.JumpSpeed += 1;

                if (entity.JumpSpeed > 0)
                {
                    entity.IsFalling = true;
                    entity.IsJumping = false;
                }

                //Debug.WriteLine($"JUMP END Jumping: {entity.IsJumping} // Falling: {entity.IsFalling}");

                if (entity.Position.Y >= entity.StartY)
                //If it's farther than ground
                {
                    entity.Speed = new Vector2(entity.Speed.X, entity.StartY); // Then set it on
                    entity.IsJumping = false;
                    //Debug.WriteLine($"ON GROUND Jumping: {entity.IsJumping} // Falling: {entity.IsFalling}");
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && !entity.IsFalling)
                {
                    entity.IsJumping = true;
                    entity.IsFalling = false;
                    entity.JumpSpeed = -20; // Give it upward thrust
                    //Debug.WriteLine($"JUMP START Jumping: {entity.IsJumping} // Falling: {entity.IsFalling}");
                }
            }
        }
    }
}
