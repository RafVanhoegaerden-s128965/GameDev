using GameProject.GameObjects.Playable;
using GameProject.HUD;
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

        private MainCharacter _mainCharacter;

        private HPBar _hpBar;
        private Texture2D _hpBarTexture;

        #region Levels
        private Level1 _level1;
        #endregion


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            #region Screen
            _graphics.IsFullScreen = false;

            // Screen WIDTH
            _graphics.PreferredBackBufferWidth = Settings.Screen.Width;

            // Screen HEIGHT
            _graphics.PreferredBackBufferHeight = Settings.Screen.Height;

            _graphics.ApplyChanges();
            #endregion

            IsMouseVisible = true;

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _mainCharacter = new MainCharacter(Content);

            #region HpBar
            _hpBarTexture = new Texture2D(GraphicsDevice, 1, 1);
            _hpBarTexture.SetData(new[] { Color.White });

            _hpBar = new HPBar(_mainCharacter, _hpBarTexture, Content);
            #endregion

            #region levels
            _level1 = new Level1(this, _mainCharacter, _hpBar);
            _screenManager.LoadScreen(_level1);
            #endregion

            _level1.MainCharacter.Position = new Vector2(_level1.RespawnZone[0].X, _level1.RespawnZone[0].Y);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}