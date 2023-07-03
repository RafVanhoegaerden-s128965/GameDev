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
    internal class MainCharacter : IGameObject, IMovable
    {
        public Texture2D MCTexture;
        public Rectangle MCHitbox;

        // Managers
        private MovementManager _movementManager;

        // IMovable
        public IInputReader InputReader { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Acceleration { get; set; }


        public MainCharacter(Texture2D _texture, IInputReader _inputReader)
        {
            this.MCTexture = _texture;
            this.InputReader = _inputReader;

            Position = new Vector2(100, 100);
            Speed = new Vector2(10, 10);
            Acceleration = new Vector2(0f, 0f);

            this.MCHitbox = new Rectangle((int)Position.X, (int)Position.Y, 100, 100); // X, Y, width, height

            _movementManager = new MovementManager();
        }

        public void Update(GameTime gameTime)
        {
            _movementManager.Move(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MCTexture, Position, MCHitbox, Color.Red); // Texture, Position, Hitbox, Color
        }
    }
}
