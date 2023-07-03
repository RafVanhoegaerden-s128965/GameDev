using GameProject.Animations;
using GameProject.Interface;
using GameProject.Managers;
using GameProject.Settings;
using GameProject.StrategyPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects
{
    internal class MainCharacter : Player
    {
        

        public MainCharacter(Texture2D _idleTexture, Texture2D _runningTexture, Texture2D _attackTexture, IInputReader _inputReader, Texture2D _testHitboxTexture)
        {
            this.IdleTexture = _idleTexture;
            this.RunningTexture = _runningTexture;
            this.AttackTexture = _attackTexture;
            this.InputReader = _inputReader;
            this.TestHitboxTexture = _testHitboxTexture;

            // Animations

            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            AttackAnimation = new Animation();
            AttackAnimation.GetFramesFromTextureProperties(AttackTexture.Width, AttackTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            // Moving

            Position = new Vector2(100, 100);
            Speed = new Vector2(10, 10);
            Acceleration = new Vector2(0f, 0f);

            // Hitboxes

            this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, IdleAnimation.CurrentFrame.SourceRectangle.Width, IdleAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height

            // Managers

            MovementManager = new MovementManager();
            AnimationManager = new AnimationManager();
        }

        public void OnCollision(IGameObject other)
        {
            // Code voor de reactie van het hoofdpersonage op de botsing
        }

        public void Update(GameTime gameTime)
        {
            // Read Input
            InputReader.ReadInput(this);

            // Movement
            MovementManager.Move(this);
            if (AnimationManager.IsWalking(this))
            {
                RunningAnimation.Update(gameTime);
                this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, RunningAnimation.CurrentFrame.SourceRectangle.Width, RunningAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
            }
            else if (AnimationManager.IsAttacking(this))
            {
                AttackAnimation.Update(gameTime);
                this.Hitbox = new Rectangle((int)Position.X, (int)Position.Y, AttackAnimation.CurrentFrame.SourceRectangle.Width, AttackAnimation.CurrentFrame.SourceRectangle.Height); // X, Y, width, height
            }
            else
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
            else if (IsMoving == true && IsAttacking == false)
            {
                spriteBatch.Draw(TestHitboxTexture, Position, Hitbox, Color.Yellow * 0.6f, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                spriteBatch.Draw(RunningTexture, Position, RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }
            // Attacking
            else if (IsAttacking == true && IsMoving == false)
            {
                spriteBatch.Draw(TestHitboxTexture, Position, Hitbox, Color.Blue * 0.6f, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                spriteBatch.Draw(AttackTexture, Position, AttackAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }else{
                spriteBatch.Draw(TestHitboxTexture, Position, Hitbox, Color.Yellow * 0.6f, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
                spriteBatch.Draw(RunningTexture, Position, RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }
        }
    }
}
