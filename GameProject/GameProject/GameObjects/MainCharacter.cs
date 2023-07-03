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
    internal class MainCharacter : Entity, IControllable
    {
        // IControllable
        public IInputReader InputReader { get; set; }

        public MainCharacter(Texture2D _idleTexture, Texture2D _runningTexture, IInputReader _inputReader)
        {
            this.IdleTexture = _idleTexture;
            this.RunningTexture = _runningTexture;
            this.InputReader = _inputReader;

            // Animations

            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

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
            // Update Direction
            Direction = InputReader.ReadInput(this);        

            // Moving
            MovementManager.Move(this);
            if (AnimationManager.IsWalking(this))
            {
                RunningAnimation.Update(gameTime);
            }
            else
            {
                IdleAnimation.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsMoving == false)
            {
                spriteBatch.Draw(IdleTexture, Position, IdleAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }
            else
            {
                spriteBatch.Draw(RunningTexture, Position, RunningAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1.5f, DirectionPosition, 0f); // Texture, Position, Hitbox, Color, Rotation, Origin, Scale, Effects, LayerDepth
            }


        }
    }
}
