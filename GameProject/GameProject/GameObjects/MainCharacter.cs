using GameProject.Animations;
using GameProject.InputReader;
using GameProject.Interface;
using GameProject.Managers;
using GameProject.Settings;
using GameProject.StrategyPattern;
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

namespace GameProject.GameObjects
{
    internal class MainCharacter : Player
    {
        public MainCharacter(ContentManager content, Texture2D _testHitboxTexture)
        {
            this.IdleTexture = content.Load<Texture2D>("Idle-Sheet");
            this.RunningTexture = content.Load<Texture2D>("Run-Sheet");
            this.AttackTexture = content.Load<Texture2D>("Attack-01-Sheet");
            this.InputReader = new KeyBoardReader();
            this.TestHitboxTexture = _testHitboxTexture;

            // Animations

            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            AttackAnimation = new Animation();
            AttackAnimation.GetFramesFromTextureProperties(AttackTexture.Width, AttackTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            // Moving

            Position = new Vector2(100, 600);
            Speed = new Vector2(10, 10);
            Acceleration = new Vector2(0f, 0f);

            IsJumping = false;
            IsFalling = false;
            StartY = Position.Y;
            JumpSpeed = 0;

            // Hitbox

            this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, IdleAnimation.CurrentFrame.SourceRectangle.Width, IdleAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height

            // Managers

            MovementManager = new MovementManager();
            AnimationManager = new AnimationManager();
        }

        public void Update(GameTime gameTime)
        {
            // Read Input

            Direction = InputReader.ReadMovementInput();

            IsAttacking = InputReader.ReadIsFighting();

            //IsJumping = InputReader.ReadIsJumping();

            // Movement

            MovementManager.Move(this);
            Jump();

            // Update Hitbox

            if (AnimationManager.IsWalking(this)) // Running
            {
                RunningAnimation.Update(gameTime);
                this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, RunningAnimation.CurrentFrame.SourceRectangle.Width, RunningAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
            }
            else if (AnimationManager.IsAttacking(this)) // Attacking
            {
                AttackAnimation.Update(gameTime);
                this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, AttackAnimation.CurrentFrame.SourceRectangle.Width, AttackAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
            }
            else // Idle
            {
                IdleAnimation.Update(gameTime);
                this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, IdleAnimation.CurrentFrame.SourceRectangle.Width, IdleAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Idle
            if (IsMoving == false && IsAttacking == false)
            {
                spriteBatch.Draw(TestHitboxTexture, Position, Hitbox, Color.Red * 0.6f, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                spriteBatch.Draw(IdleTexture, Position, IdleAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }
            // Running
            else if (IsMoving == true)
            {
                spriteBatch.Draw(TestHitboxTexture, Position, Hitbox, Color.Yellow * 0.6f, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                spriteBatch.Draw(RunningTexture, Position, RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }
            // Attacking
            else if (IsAttacking == true)
            {
                spriteBatch.Draw(TestHitboxTexture, Position, Hitbox, Color.Blue * 0.6f, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                spriteBatch.Draw(AttackTexture, Position, AttackAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }
        }
        public void Jump()
        {
            // credits => https://flatformer.blogspot.com/
            if (IsJumping)
            {
                Position += new Vector2(0, JumpSpeed);
                JumpSpeed += 1;



                if (Position.Y >= StartY)
                //If it's farther than ground
                {
                    Speed = new Vector2(Speed.X, StartY); // Then set it on
                    IsJumping = false;
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && !IsFalling)
                {
                    IsJumping = true;
                    IsFalling = false;
                    JumpSpeed = -14; // Give it upward thrust
                }
            }
        }
    }
}
