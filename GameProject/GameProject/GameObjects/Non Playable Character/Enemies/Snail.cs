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
    internal class Snail : Enemy
    {
        public Snail(ContentManager content, Rectangle path)
        {
            #region Textures
            RunningTexture = content.Load<Texture2D>("Sprites\\Enemies\\SnailMovement");
            #endregion
            
            #region Animations
            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight
            #endregion

            #region Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, RunningAnimation.CurrentFrame.SourceRectangle.Width, RunningAnimation.CurrentFrame.SourceRectangle.Height);
            #endregion

            #region Combat
            HP = 1;
            MaxHP = 1;
            Damage = 2;
            #endregion

            #region Moving
            CurrentMovementState = Interface.CurrentMovementState.Running;

            Position = new Vector2(path.X, path.Y);
            Speed = new Vector2(0.5f, 0);
            Acceleration = new Vector2(0f, 0f);

            Pathway = path;
            IsFacingLeft = true;
            #endregion

            #region Managers
            MovementManager = new MovementManager();
            AnimationManager = new AnimationManager();
            #endregion
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // DrawEnemy Animations
            AnimationManager.DrawEnemyAnimation(spriteBatch, this);
        }

        public void Update(GameTime gameTime)
        {
            // Movement
            MovementManager.EnemyMove(this);

            // UpdateEnemy Animations
            AnimationManager.UpdateEnemyAnimation(gameTime, this);
        }
    }
}
