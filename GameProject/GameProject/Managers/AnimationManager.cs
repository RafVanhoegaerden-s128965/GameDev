using GameProject.Animations;
using GameProject.GameObjects;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GameProject.Managers
{
    internal class AnimationManager
    {
        public void DrawAnimation(SpriteBatch spriteBatch, Entity entity)
        {
            switch (entity.CurrentMovementState)
            {
                case CurrentMovementState.Idle:
                    //MainCharacter
                    spriteBatch.Draw(entity.IdleTexture, entity.Position, entity.IdleAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                case CurrentMovementState.Running:
                    //MainCharacter
                    spriteBatch.Draw(entity.RunningTexture, entity.Position, entity.RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                case CurrentMovementState.Attacking:
                    //MainCharacter
                    spriteBatch.Draw(entity.AttackTexture, entity.Position, entity.AttackAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
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
                    hitbox.Width = 40;
                    hitbox.Height = 71;
                    break;
                default:
                    break;
            }
            entity.Hitbox = hitbox;
        }

        public void DrawEnemyAnimation(SpriteBatch spriteBatch, Enemy enemy) 
        {
            spriteBatch.Draw(enemy.RunningTexture, enemy.Position, enemy.RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.4f, enemy.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
        }

        public void UpdateEnemyAnimation(GameTime gameTime, Enemy enemy)
        {
            enemy.RunningAnimation.Update(gameTime);
        }
    }
}
