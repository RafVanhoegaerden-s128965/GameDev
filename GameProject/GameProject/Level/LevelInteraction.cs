using GameProject.GameObjects;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.HUD.Menu;
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
        public void GetMainCharacterGameState(MainCharacter mainCharacter, Game1 game)
        {
            if (!mainCharacter.IsAlive)
            {
                game.StateOfGame = CurrentGameState.Ended;
                game.StateOfPlayer = CurrentPlayerState.Lost;
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

                            EntityDead(enemy);

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

                            EntityDead(mainCharacter);

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

        public void GetTrapCollides(MainCharacter mainCharacter, List<Trap> trapList)
        {
            foreach (var trap in trapList) 
            {
                if (mainCharacter.Hitbox.Intersects(trap.Hitbox))
                {
                    mainCharacter.HP = 0;

                    EntityDead(mainCharacter);
                }
            }
        }

        public void GetPowerUpCollides(MainCharacter mainCharacter, List<PowerUp> powerUpList)
        {
            foreach (var powerUp in powerUpList)
            {
                if (mainCharacter.Hitbox.Intersects(powerUp.Hitbox))
                {
                    mainCharacter.JumpPowerUpActive = true;
                }
            }
        }

        public void GetMainCharacterToNextZone(MainCharacter mainCharacter, Rectangle endZone, Game1 game, int desiredLVL)
        {
            if (endZone.Intersects(mainCharacter.Hitbox))
            {
                switch (desiredLVL)
                {
                    case 0:
                        game.StateOfPlayer = CurrentPlayerState.Won;
                        game.StateOfGame = CurrentGameState.Ended;
                        break;
                    case 1:
                        game.StateOfGame = CurrentGameState.Level1;
                        break;
                    case 2:
                        game.StateOfGame = CurrentGameState.Level2;
                        break;
                    case 3:
                        game.StateOfGame = CurrentGameState.Menu;
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetEndzone(MainCharacter mainCharacter, Rectangle endZone, Game1 game)
        {
            if (endZone.Intersects(mainCharacter.Hitbox)) { game.StateOfGame = CurrentGameState.Ended; }
        }


        public void EntityDead(Entity entity)
        {
            if (entity.HP <= 0)
            {
                entity.IsAlive = false;
            }
        }
    }
}

