using GameProject.Animations;
using GameProject.Interface;
using GameProject.Managers;
using GameProject.Settings;
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
        public Texture2D MCTexture;
        public Animation MCAnimation;

        // Managers
        private MovementManager _movementManager;

        // IControllable
        public IInputReader InputReader { get; set; }

        public MainCharacter(Texture2D _texture, IInputReader _inputReader)
        {
            this.MCTexture = _texture;
            this.InputReader = _inputReader;

            //MCAnimation = new Animation();
            //MCAnimation.GetFramesFromTextureProperties(MCTexture.Width, MCTexture.Height, 5, 2); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            Position = new Vector2(100, 100);
            Speed = new Vector2(10, 10);
            Acceleration = new Vector2(0f, 0f);

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 100, 100); // X, Y, width, height

            _movementManager = new MovementManager();
        }

        public void OnCollision(IGameObject other)
        {
            // Code voor de reactie van het hoofdpersonage op de botsing
        }

        public void Update(GameTime gameTime)
        {
            // Update Direction
            Direction = InputReader.ReadInput(this);

            // Update Hitbox position

            //MCAnimation.Update(gameTime);
            _movementManager.Move(this);            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MCTexture, Position, Hitbox /*MCAnimation.CurrentFrame.SourceRectangle*/, Color.Red); // Texture, Position, Hitbox, Color
        }
    }
}
