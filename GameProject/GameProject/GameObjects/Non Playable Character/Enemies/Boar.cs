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

            // Moving

            Position = new Vector2(path.X, path.Y);
            Speed = new Vector2(1, 0);
            Acceleration = new Vector2(0f, 0f);

            Pathway = path;
            IsFacingLeft = true;

            // Managers

            MovementManager = new MovementManager();
            AnimationManager = new AnimationManager();
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
