using GameProject.GameObjects;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GameProject.Level
{
    internal class LevelInteractions
    {
        public void GetMainCharacterCollides(MainCharacter mainCharacter, List<Rectangle> collisionTiles, Vector2 mainCharacterInitPosition)
        {
            foreach (var rectangle in collisionTiles)
            {
                if (!mainCharacter.IsJumping)
                {
                    mainCharacter.IsFalling = true;
                }

                if (rectangle.Intersects(mainCharacter.Hitbox) && mainCharacter.Direction.Y == 0)
                {
                    mainCharacter.Position = new Vector2(mainCharacter.Position.X, mainCharacterInitPosition.Y);

                    mainCharacter.IsFalling = false;
                    break;
                }

                //bool IsTouchingLeft()
                //{
                //    return mainCharacter.Hitbox.Right + mainCharacter.Direction.X > rectangle.Left &&
                //        mainCharacter.Hitbox.Left < rectangle.Left &&
                //        mainCharacter.Hitbox.Bottom > rectangle.Top &&
                //        mainCharacter.Hitbox.Top < rectangle.Bottom;
                //}

                //bool IsTouchingRight()
                //{
                //    return mainCharacter.Hitbox.Left + mainCharacter.Direction.X < rectangle.Right &&
                //        mainCharacter.Hitbox.Right > rectangle.Right &&
                //        mainCharacter.Hitbox.Bottom > rectangle.Top &&
                //        mainCharacter.Hitbox.Top < rectangle.Bottom;
                //}

                //bool IsTouchingTop()
                //{
                //    return mainCharacter.Hitbox.Bottom + mainCharacter.Direction.Y > rectangle.Top &&
                //        mainCharacter.Hitbox.Top < rectangle.Top &&
                //        mainCharacter.Hitbox.Right > rectangle.Left &&
                //        mainCharacter.Hitbox.Left < rectangle.Right;
                //}

                //bool IsTouchingBottom()
                //{
                //    return mainCharacter.Hitbox.Top + mainCharacter.Direction.Y < rectangle.Bottom &&
                //        mainCharacter.Hitbox.Bottom > rectangle.Bottom &&
                //        mainCharacter.Hitbox.Right > rectangle.Left &&
                //        mainCharacter.Hitbox.Left < rectangle.Right;
                //}
            }
        }

        public void GetEnemyCollides(MainCharacter mainCharacter, List<Enemy> enemyList)
        {
            DateTime currentTime = DateTime.Now;

            mainCharacter.IsDamaged = (currentTime - mainCharacter.LastHitTime).TotalSeconds < 3; // Adjust the time duration if needed

            foreach (var enemy in enemyList)
            {
                if (!mainCharacter.IsDamaged && mainCharacter.Hitbox.Intersects(enemy.Hitbox))
                {
                    // Check if enough time has passed since the last hit
                    if ((currentTime - mainCharacter.LastHitTime).TotalSeconds >= 1)
                    {
                        if (enemy.IsAlive)
                        {
                            mainCharacter.HP -= enemy.Damage;
                            mainCharacter.IsDamaged = true;

                            // Update the last hit time
                            mainCharacter.LastHitTime = currentTime;
                        }
                    }
                }

                // Check if enough time has passed since the character was last hit
                if (!mainCharacter.IsDamaged && mainCharacter.IsDamaged >= 3)
                {
                    mainCharacter.IsDamaged = false;
                }
            }
            Debug.WriteLine($"HP: {mainCharacter.HP}");

        }
    }
}

