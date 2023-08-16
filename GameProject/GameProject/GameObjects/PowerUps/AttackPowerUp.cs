using GameProject.Animations;
using GameProject.GameObjects.Playable;
using GameProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.PowerUps
{
    internal class AttackPowerUp : PowerUp
    {
        public AttackPowerUp(ContentManager content, Rectangle position, MainCharacter mainCharacter)
        {
            #region Textures
            IdleTexture = content.Load<Texture2D>("Sprites\\PowerUps\\PowerUp");
            #endregion

            #region Animations
            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight
            #endregion

            Position = new Vector2(position.X, position.Y);

            #region Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, IdleAnimation.CurrentFrame.SourceRectangle.Width, IdleAnimation.CurrentFrame.SourceRectangle.Height);
            #endregion

            #region Effect
            Effect = 2; // Enhance jump effect --> Jumps higher
            mainCharacter.AttackEffect = Effect;
            #endregion

            #region Managers
            AnimationManager = new AnimationManager();
            #endregion
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
