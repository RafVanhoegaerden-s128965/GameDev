using GameProject.GameObjects.Playable;
using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Managers
{
    internal class AnimationManager
    {

        public void DrawAnimation(SpriteBatch spriteBatch, Player entity)
        {
            switch (entity.CurrentMovementState)
            {
                case CurrentMovementState.Idle:
                    DrawTransparentRectangle(spriteBatch, entity.Position, entity.IdleAnimation.CurrentFrame.SourceRectangle, Color.Red * 0.6f);
                    spriteBatch.Draw(entity.IdleTexture, entity.Position, entity.IdleAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                case CurrentMovementState.Running:
                    DrawTransparentRectangle(spriteBatch, entity.Position, entity.RunningAnimation.CurrentFrame.SourceRectangle, Color.Yellow * 0.6f);
                    spriteBatch.Draw(entity.RunningTexture, entity.Position, entity.RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                case CurrentMovementState.Attacking:
                    DrawTransparentRectangle(spriteBatch, entity.Position, entity.AttackAnimation.CurrentFrame.SourceRectangle, Color.Black * 0.6f);
                    spriteBatch.Draw(entity.AttackTexture, entity.Position, entity.AttackAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.2f, entity.DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                    break;
                default:
                    break;
            }
        }
        public void UpdateAnimation(GameTime gameTime, SpriteBatch spriteBatch, Player entity) 
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

        private void DrawTransparentRectangle(SpriteBatch spriteBatch, Vector2 position, Rectangle rectangle, Color color)
        {
            Texture2D pixelTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixelTexture.SetData(new[] { Color.White });

            spriteBatch.Draw(pixelTexture, new Rectangle((int)position.X + rectangle.X, (int)position.Y + rectangle.Y, rectangle.Width, 1), color);
            spriteBatch.Draw(pixelTexture, new Rectangle((int)position.X + rectangle.X, (int)position.Y + rectangle.Y + rectangle.Height, rectangle.Width, 1), color);
            spriteBatch.Draw(pixelTexture, new Rectangle((int)position.X + rectangle.X, (int)position.Y + rectangle.Y, 1, rectangle.Height), color);
            spriteBatch.Draw(pixelTexture, new Rectangle((int)position.X + rectangle.X + rectangle.Width, (int)position.Y + rectangle.Y, 1, rectangle.Height), color);
        }
    }
}
