using GameProject.GameObjects.Playable;
using GameProject.HUD.Menu;
using GameProject.HUD.Menu.LevelComponents;
using GameProject.Level;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Sprites;
using System.Diagnostics;
using TiledSharp;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;

        #region GameState
        private CurrentGameState StateOfGame { get; set; }
        private CurrentPlayerState StateOfPlayer { get; set; }
        private CurrentGameState PreviousStateOfGame { get; set; }
        #endregion

        private MainCharacter _mainCharacter;

        #region HPBar
        private HPBar _hpBar;
        private Texture2D _hpBarTexture;
        #endregion

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
            StateOfGame = CurrentGameState.Level1;
            PreviousStateOfGame = CurrentGameState.Menu;

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
            _level1 = new Level1(this, Content, _mainCharacter, _hpBar);
            #endregion
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit Control
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Debug.WriteLine($"StateOfGame: {StateOfGame}");
            Debug.WriteLine(PreviousStateOfGame);


            if (PreviousStateOfGame != StateOfGame)
            {
                switch (StateOfGame)
                {
                    case CurrentGameState.Level1:
                        _screenManager.LoadScreen(_level1, new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    //case CurrentGameState.level2:
                        //_screenManager.LoadScreen(new Level2(this), new FadeTransition(GraphicsDevice, Color.Black));
                        //break;
                    //case CurrentGameState.Menu:
                    //    _screenManager.LoadScreen(new MenuState(this), new FadeTransition(GraphicsDevice, Color.Black));
                    //    break;
                    //case CurrentGameState.GameOver:
                    //    _screenManager.LoadScreen(new GameOverPanel(this), new FadeTransition(GraphicsDevice, Color.Black));
                    //    break;
                    default:
                        break;
                }
            }

            PreviousStateOfGame = StateOfGame;

            base.Update(gameTime);
        }
    }
}