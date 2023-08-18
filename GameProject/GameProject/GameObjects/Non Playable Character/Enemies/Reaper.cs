using GameProject.Animations;
using GameProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.GameObjects.Non_Playable_Character.Enemies
{
    internal class Reaper : Enemy
    {
        public Reaper(ContentManager content, Rectangle path)
        {
            #region Textures
            RunningTexture = content.Load<Texture2D>("Sprites\\Enemies\\Reaper\\ReaperMovement");
            #endregion

            #region Animations
            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight
            #endregion

            #region Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, RunningAnimation.CurrentFrame.SourceRectangle.Width, RunningAnimation.CurrentFrame.SourceRectangle.Height);
            #endregion 

            #region Combat
            HP = 4;
            MaxHP = 4;
            Damage = 3;
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
