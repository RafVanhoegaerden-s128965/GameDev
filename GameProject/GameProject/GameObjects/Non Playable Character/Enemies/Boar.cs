using GameProject.Animations;
using GameProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Non_Playable_Character.Enemies
{
    internal class Boar : Enemy
    {
        public Boar(ContentManager content, Rectangle path)
        {
            #region Textures
            RunningTexture = content.Load<Texture2D>("Sprites\\Enemies\\BoarMovement");
            #endregion

            #region Animations
            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 6, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight
            #endregion

            #region Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, RunningAnimation.CurrentFrame.SourceRectangle.Width, RunningAnimation.CurrentFrame.SourceRectangle.Height);
            #endregion

            #region Combat
            HP = 2;
            MaxHP = 2;
            Damage = 2;
            #endregion

            #region Moving
            CurrentMovementState = Interface.CurrentMovementState.Running;

            Position = new Vector2(path.X, path.Y);

            Pathway = path;
            IsFacingLeft = true;
            #endregion
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // DrawLevel Animations
            AnimationManager.DrawEnemyAnimation(spriteBatch, this);

        }

        public void Update(GameTime gameTime)
        {
            // Movement
            MovementManager.EnemyMove(this);

            // UpdateLevel Animations + Hitbox
            AnimationManager.UpdateEnemyAnimation(gameTime, this);
        }
    }
}
