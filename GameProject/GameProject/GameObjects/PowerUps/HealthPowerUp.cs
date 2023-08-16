using GameProject.Animations;
using GameProject.GameObjects.Playable;
using GameProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.PowerUps
{
    internal class HealthPowerUp : PowerUp
    {
        public HealthPowerUp(ContentManager content, Rectangle position, MainCharacter mainCharacter)
        {
            #region Textures
            IdleTexture = content.Load<Texture2D>("Sprites\\PowerUps\\JumpPowerUp");
            #endregion

            #region Animations
            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight
            #endregion

            Position = new Vector2(position.X, position.Y);

            // Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, IdleAnimation.CurrentFrame.SourceRectangle.Width, IdleAnimation.CurrentFrame.SourceRectangle.Height);

            // Effect

            Effect = 2; // Give 2 extra Lives + Refill HP
            mainCharacter.HealthEffect = Effect;

            // Manager

            AnimationManager = new AnimationManager();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // DrawUpdate Animations
            AnimationManager.DrawPowerUpAnimation(spriteBatch, this);
        }

        public void Update(GameTime gameTime)
        {
            // UpdatePowerUp Animations
            AnimationManager.UpdatePowerUpAnimation(gameTime, this);
        }
    }
}
