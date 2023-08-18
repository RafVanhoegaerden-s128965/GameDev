using GameProject.Animations;
using GameProject.Managers;
using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.GameObjects.Non_Playable_Character
{
    internal class Bat : Enemy
    {
        public Bat(ContentManager content, Rectangle path)
        {
            #region Textures
            RunningTexture = content.Load<Texture2D>("Sprites\\Enemies\\BatMovement");
            #endregion

            #region Animations
            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 3, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight
            #endregion

            #region Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, RunningAnimation.CurrentFrame.SourceRectangle.Width, RunningAnimation.CurrentFrame.SourceRectangle.Height);
            #endregion

            #region Combat
            HP = 1;
            MaxHP = 1;
            Damage = 1;
            #endregion

            #region Moving
            CurrentMovementState = Interface.CurrentMovementState.Running;

            Position = new Vector2(path.X, path.Y);
            Speed = new Vector2(2, 0);

            Pathway = path;
            IsFacingLeft = false;
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
