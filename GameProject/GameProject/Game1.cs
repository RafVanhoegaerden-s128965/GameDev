﻿using GameProject.GameObjects;
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

        private MovementManager _movementManager;

        //Main Character
        private Texture2D _mcTexture;
        private MainCharacter _mainCharacter;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;

            // Screen WIDTH
            _graphics.PreferredBackBufferWidth = 1920;
            _screenWidth = _graphics.PreferredBackBufferWidth;

            // Screen HEIGHT
            _graphics.PreferredBackBufferHeight = 1080;
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
            _movementManager = new MovementManager();

            _movementManager.CollidableObjects.Add(_mainCharacter);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _mcTexture = new Texture2D(GraphicsDevice,1,1); // GraphicsDevice, width, height
            _mcTexture.SetData(new[] { Color.White });

            // Load any necessary content for your game objects here
            // For example:
            // _mainCharacter.MCTexture = Content.Load<Texture2D>("main_character_texture");

            _mainCharacter = new MainCharacter(_mcTexture, new KeyBoardReader()); // Move to initialize if a sprite is imported
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