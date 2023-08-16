using GameProject.Animations;
using GameProject.GameObjects;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Non_Playable_Character.Enemies;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace GameProject.Managers
{
    internal class AnimationManager
    {
        #region MainCharacter
        public void DrawAnimation(SpriteBatch spriteBatch, Entity entity)
        {
            DateTime currentTime = DateTime.Now;

            switch (entity.CurrentMovementState)
            {
                case CurrentMovementState.Idle:
                    Color idleColor = entity.IsDamaged && currentTime.Millisecond % 500 < 250 ? Color.Red * 0.7f : Color.White;
                    spriteBatch.Draw(entity.IdleTexture, entity.Position, entity.IdleAnimation.CurrentFrame.SourceRectangle, idleColor, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f);
                    break;
                case CurrentMovementState.Running:
                    Color runningColor = entity.IsDamaged && currentTime.Millisecond % 500 < 250 ? Color.Red * 0.7f : Color.White;
                    spriteBatch.Draw(entity.RunningTexture, entity.Position, entity.RunningAnimation.CurrentFrame.SourceRectangle, runningColor, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f);
                    break;
                case CurrentMovementState.Attacking:
                    Color attackColor = entity.IsDamaged && currentTime.Millisecond % 500 < 250 ? Color.Red * 0.7f : Color.White;
                    spriteBatch.Draw(entity.AttackTexture, entity.Position, entity.AttackAnimation.CurrentFrame.SourceRectangle, attackColor, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f);
                    break;
                default:
                    break;
            }

        }
        public void UpdateAnimation(GameTime gameTime, Entity entity) 
        {
            Rectangle hitbox = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, 0, 0); // Initialize hitbox

            switch (entity.CurrentMovementState)
            {
                case CurrentMovementState.Idle:
                    entity.IdleAnimation.Update(gameTime);
                    hitbox.Width = 28;
                    hitbox.Height = 71;
                    break;
                case CurrentMovementState.Running:
                    entity.RunningAnimation.Update(gameTime);
                    hitbox.Width = 32;
                    hitbox.Height = 71;
                    break;
                case CurrentMovementState.Attacking:
                    entity.AttackAnimation.Update(gameTime);
                    hitbox.Width = 85;
                    hitbox.Height = 71;
                    break;
                default:
                    break;
            }
            entity.Hitbox = hitbox;
        }
        #endregion

        #region Enemy
        public void DrawEnemyAnimation(SpriteBatch spriteBatch, Enemy enemy) 
        {
            DateTime currentTime = DateTime.Now;

            Color runningColor = enemy.IsDamaged && currentTime.Millisecond % 500 < 250 ? Color.Red * 0.7f : Color.White;
            spriteBatch.Draw(enemy.RunningTexture, enemy.Position, enemy.RunningAnimation.CurrentFrame.SourceRectangle, runningColor, 0f, Vector2.Zero, 1.4f, enemy.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
        }
        public void UpdateEnemyAnimation(GameTime gameTime, Enemy enemy)
        {
            enemy.RunningAnimation.Update(gameTime);
        }
        #endregion

        #region PowerUp
        public void DrawPowerUpAnimation(SpriteBatch spriteBatch, PowerUp powerUp)
        {
            spriteBatch.Draw(powerUp.IdleTexture, powerUp.Position, powerUp.IdleAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.8f, SpriteEffects.None, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
        }
        public void UpdatePowerUpAnimation(GameTime gameTime, PowerUp powerUp)
        {
            powerUp.IdleAnimation.Update(gameTime);
        }
        #endregion
    }
}
