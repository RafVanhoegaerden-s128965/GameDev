using GameProject.GameObjects;
using GameProject.InputReader;
using GameProject.Managers;
using GameProject.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private static Screen _screen;
        private static int _screenWidth;
        private static int _screenHeight;

        private Texture2D _blockTexture;

        //Main Character
        private MainCharacter _mainCharacter;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;

            // Screen WIDTH
            _graphics.PreferredBackBufferWidth = 1280;
            _screenWidth = _graphics.PreferredBackBufferWidth;

            // Screen HEIGHT
            _graphics.PreferredBackBufferHeight = 720;
            _screenHeight = _graphics.PreferredBackBufferHeight;

            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            _screen = new Screen(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            // TODO: Add your initialization logic here

            // Add objects to MovementManagerList

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blockTexture.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _mainCharacter = new MainCharacter(this.Content, _blockTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _mainCharacter.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            _mainCharacter.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}