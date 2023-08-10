using GameProject.Animations;
using GameProject.InputReader;
using GameProject.Interface;
using GameProject.Managers;
using GameProject.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Playable
{
    internal class MainCharacter : Player
    {

        public MainCharacter(Vector2 _position, ContentManager content)
        {
            InputReader = new KeyBoardReader();
            GravityFactor = 5;

            #region Textures
            IdleTexture = content.Load<Texture2D>("Sprites\\MainCharacter\\Idle-Sheet");
            RunningTexture = content.Load<Texture2D>("Sprites\\MainCharacter\\Run-Sheet");
            AttackTexture = content.Load<Texture2D>("Sprites\\MainCharacter\\Attack-01-Sheet");
            #endregion

            #region Animations
            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            AttackAnimation = new Animation();
            AttackAnimation.GetFramesFromTextureProperties(AttackTexture.Width, AttackTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            CurrentMovementState = CurrentMovementState.Idle;
            #endregion

            // Hitbox

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, IdleAnimation.CurrentFrame.SourceRectangle.Width, IdleAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height

            // Moving

            Position = new Vector2(_position.X, _position.Y);
            Speed = new Vector2(10, 10);
            Acceleration = new Vector2(0f, 0f);

            StartY = Position.Y;

            // Jump State

            IsFalling = true;
            IsJumping = false;

            // Managers

            MovementManager = new MovementManager();
            AnimationManager = new AnimationManager();
        }

        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Apply gravity
            Gravity();

            // Read Input
            InputReader.ReadInput(this);

            // Movement
            MovementManager.Move(this);
            MovementManager.Jump(this);

            // UpdateLevel Animations + Hitbox
            AnimationManager.UpdateAnimation(gameTime, spriteBatch, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // DrawLevel Animations
            AnimationManager.DrawAnimation(spriteBatch, this);
        }

        public void Gravity()
        {
            Position += new Vector2(0, GravityFactor);
            GravityFactor += 1f;
            if (GravityFactor > 7f)
            {
                GravityFactor = 7f;
            }
        }
    }
}
