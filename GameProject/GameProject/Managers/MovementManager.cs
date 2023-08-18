using GameProject.GameObjects;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Linq;

namespace GameProject.Managers
{
    internal class MovementManager
    {
        #region MainCharacter
        public void Move(Entity entity)
        {
            entity.Speed += entity.Acceleration;
            entity.Direction *= entity.Speed;
            entity.Position += entity.Direction;
            Debug.WriteLine($"Position: {entity.Position} // Direction: {entity.Direction}");
        }
        public void Jump(Player player)
        {
            // credits => https://flatformer.blogspot.com/
            if (player.IsJumping)
            {
                player.StartY = player.Position.Y;
                player.Position += new Vector2(0, player.JumpSpeed);
                player.JumpSpeed += 1;
                Debug.WriteLine($"Jump: {player.Position}");


                if (player.JumpSpeed > 0)
                {
                    player.IsFalling = true;
                    player.IsJumping = false;
                }

                //Debug.WriteLine($"JUMP END Jumping: {player.IsJumping} // Falling: {player.IsFalling}");

                if (player.Position.Y >= player.StartY)
                //If it's farther than ground
                {
                    player.Speed = new Vector2(player.Speed.X, player.StartY); // Then set it on
                    player.IsJumping = false;
                    //Debug.WriteLine($"ON GROUND Jumping: {player.IsJumping} // Falling: {player.IsFalling}");
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && !player.IsFalling)
                {
                    player.IsJumping = true;
                    player.IsFalling = false;
                    player.JumpSpeed = -20; // Give it upward thrust

                    if (player.JumpPowerUpActive) 
                    {
                        player.JumpSpeed -= player.JumpEffect;
                    }
                    //Debug.WriteLine($"JUMP START Jumping: {player.IsJumping} // Falling: {player.IsFalling}");
                }
            }
        }
        public void Gravity(Player player)
        {
            player.Position += new Vector2(0, player.GravityFactor);
            player.GravityFactor += 1f;
            if (player.GravityFactor > 8f)
            {
                player.GravityFactor = 8f;
            }
        }
        #endregion

        #region Enemy
        public void EnemyMove(Enemy enemy)
        {
            if (!enemy.Pathway.Contains(enemy.Hitbox))
            {
                enemy.Speed = -enemy.Speed;
                enemy.IsFacingLeft = !enemy.IsFacingLeft;
            }

            if (!enemy.IsFacingLeft)
            {
                enemy.DirectionPosition = SpriteEffects.None;
            }
            else
            {
                enemy.DirectionPosition = SpriteEffects.FlipHorizontally;
            }

            enemy.Position += new Vector2(enemy.Speed.X, enemy.Speed.Y);

            enemy.Hitbox = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, enemy.Hitbox.Width, enemy.Hitbox.Height);
        }
        #endregion
    }
}
