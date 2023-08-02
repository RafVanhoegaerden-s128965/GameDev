using GameProject.Animations;
using GameProject.GameObjects.Playable;
using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Managers
{
    internal class AnimationManager
    {
        public void DrawAnimation(SpriteBatch spriteBatch, Player entity)
        {
            switch (entity.CurrentMovementState)
            {
                case CurrentMovementState.Idle:
                    //spriteBatch.Draw(_testHitboxTexture, entity.Position, entity.Hitbox, Color.Red * 0.6f, 0f, Vector2.Zero, 1.5f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    spriteBatch.Draw(entity.IdleTexture, entity.Position, entity.IdleAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                case CurrentMovementState.Running:
                    //spriteBatch.Draw(_testHitboxTexture, entity.Position, entity.Hitbox, Color.Yellow * 0.6f, 0f, Vector2.Zero, 1.5f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    spriteBatch.Draw(entity.RunningTexture, entity.Position, entity.RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                case CurrentMovementState.Attacking:
                    //spriteBatch.Draw(_testHitboxTexture, entity.Position, entity.Hitbox, Color.Black * 0.6f, 0f, Vector2.Zero, 1.5f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    spriteBatch.Draw(entity.AttackTexture, entity.Position, entity.AttackAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                default:
                    break;
            }
        }
        public void UpdateAnimation(GameTime gameTime, Player entity) 
        {
            switch (entity.CurrentMovementState)
            {
                case CurrentMovementState.Idle:
                    entity.IdleAnimation.Update(gameTime);
                    entity.Hitbox = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.IdleAnimation.CurrentFrame.SourceRectangle.Width, entity.IdleAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
                    break;
                case CurrentMovementState.Running:
                    entity.RunningAnimation.Update(gameTime);
                    entity.Hitbox = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.RunningAnimation.CurrentFrame.SourceRectangle.Width, entity.RunningAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
                    break;
                case CurrentMovementState.Attacking:
                    entity.AttackAnimation.Update(gameTime);
                    entity.Hitbox = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.AttackAnimation.CurrentFrame.SourceRectangle.Width, entity.AttackAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
                    break;
                default:
                    break;
            }
        }
    }
}
