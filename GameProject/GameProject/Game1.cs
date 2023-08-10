using GameProject.GameObjects.Playable;
using GameProject.Level;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Sprites;
using TiledSharp;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;

        private Texture2D _background;
        private Level1 _level1;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            #region Screen
            _graphics.IsFullScreen = false;

            // Screen WIDTH
            _graphics.PreferredBackBufferWidth = Settings.Screen.Width;

            // Screen HEIGHT
            _graphics.PreferredBackBufferHeight = Settings.Screen.Height;

            _graphics.ApplyChanges();
            #endregion

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Add objects to MovementManagerList
            _level1 = new Level1(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            //_spriteBatch.Draw(_background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}