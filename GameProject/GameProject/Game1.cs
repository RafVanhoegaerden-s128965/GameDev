﻿using GameProject.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Main Character
        private Texture2D _mcTexture;
        private MainCharacter _mainCharacter;

        //Test Hitbox
        private Texture2D _testTexture;
        private Rectangle _testHitbox;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _testHitbox = new Rectangle(400, 100, 100, 100); // X, Y, width, height

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _mcTexture = new Texture2D(GraphicsDevice,1,1); // GraphicsDevice, width, height
            _mcTexture.SetData(new[] { Color.White });

            _mainCharacter = new MainCharacter(_mcTexture); // Move to initialize if a sprite is imported

            _testTexture = new Texture2D(GraphicsDevice, 1, 1); // GraphicsDevice, width, height
            _testTexture.SetData(new[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            _mainCharacter.Draw(_spriteBatch);

            _spriteBatch.Draw(_testTexture, _testHitbox, Color.Blue); // Texture, Hitbox, Color

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}