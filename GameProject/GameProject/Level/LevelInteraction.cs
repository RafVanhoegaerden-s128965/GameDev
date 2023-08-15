using GameProject.GameObjects;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.Interface;
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
            }
        }

        public void GetEnemyCollides(MainCharacter mainCharacter, List<Enemy> enemyList)
        {
            DateTime currentTime = DateTime.Now;

            mainCharacter.IsDamaged = (currentTime - mainCharacter.LastHitTime).TotalSeconds < 3; // Adjust the time duration if needed

            // MainCharacter DOES Damage
            foreach (var enemy in enemyList)
            {
                enemy.IsDamaged = (currentTime - enemy.LastHitTime).TotalSeconds < 1; // Adjust the time duration if needed

                if (!enemy.IsDamaged && mainCharacter.CurrentMovementState == CurrentMovementState.Attacking && mainCharacter.Hitbox.Intersects(enemy.Hitbox))
                {
                    // Check if enough time has passed since the last hit
                    if ((currentTime - enemy.LastHitTime).TotalSeconds >= 1)
                    {
                        if (enemy.IsAlive)
                        {
                            enemy.HP -= mainCharacter.Damage;
                            enemy.IsDamaged = true;

                            if (enemy.HP <= 0)
                            {
                                enemy.IsAlive = false;
                            }

                            // Update the last hit time
                            enemy.LastHitTime = currentTime;
                        }
                    }
                }
            }

            // MainCharacter IS Damaged
            foreach (var enemy in enemyList)
            {
                if (!mainCharacter.IsDamaged && mainCharacter.CurrentMovementState != CurrentMovementState.Attacking && mainCharacter.Hitbox.Intersects(enemy.Hitbox))
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
            }

            // Check if enough time has passed since the character was last hit
            if (!mainCharacter.IsDamaged && (currentTime - mainCharacter.LastHitTime).TotalSeconds >= 3)
            {
                mainCharacter.IsDamaged = false;
            }

            // Check if enough time has passed since the enemy was last hit
            foreach (var enemy in enemyList)
            {
                if (!enemy.IsDamaged && (currentTime - enemy.LastHitTime).TotalSeconds >= 1)
                {
                    enemy.IsDamaged = false;
                }
            }
        }


        public void GetPowerUpCollides(MainCharacter mainCharacter, List<PowerUp> powerUpList)
        {
            foreach (var powerUp in powerUpList)
            {
                if (mainCharacter.Hitbox.Intersects(powerUp.Hitbox))
                {
                    mainCharacter.PowerUpActive = true;
                }
            }
        }
    }
}

