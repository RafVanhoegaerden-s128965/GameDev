using GameProject.GameObjects.Playable;
using GameProject.HUD.Ending;
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
        public CurrentGameState StateOfGame { get; set; }
        public CurrentPlayerState StateOfPlayer { get; set; }
        public CurrentGameState PreviousStateOfGame { get; set; }
        #endregion

        private MainCharacter _mainCharacter;

        #region HPBar
        private HPBar _hpBar;
        private Texture2D _hpBarTexture;
        #endregion

        #region GameScreens
        private Menu _menu;
        private Victory _victory;
        private GameOver _gameOver;
        #endregion

        #region Levels
        private Level1 _level1;
        private Level2 _level2;
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
            StateOfGame = CurrentGameState.Menu;
            PreviousStateOfGame = CurrentGameState.Ended;

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

            #region GameScreens
            _menu = new Menu(this);
            _victory = new Victory(this);
            _gameOver = new GameOver(this);
            #endregion

            #region levels
            _level1 = new Level1(this, Content, _mainCharacter, _hpBar);
            _level2 = new Level2(this, Content, _mainCharacter, _hpBar, _mainCharacter.JumpPowerUpActive);
            #endregion
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Nothing here ==> LoadScreen is in Update() method - This loads the different screens

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
                    case CurrentGameState.Level2:
                        _screenManager.LoadScreen(_level2, new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    case CurrentGameState.Menu:
                        _screenManager.LoadScreen(_menu, new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    case CurrentGameState.Ended:
                        if (StateOfGame == CurrentGameState.Ended) 
                        {
                            if (StateOfPlayer == CurrentPlayerState.Won) 
                            {
                                _screenManager.LoadScreen(_victory, new FadeTransition(GraphicsDevice, Color.Black));
                            }
                            if (StateOfPlayer == CurrentPlayerState.Lost)
                            {
                                _screenManager.LoadScreen(_gameOver, new FadeTransition(GraphicsDevice, Color.Black));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            PreviousStateOfGame = StateOfGame;

            base.Update(gameTime);
        }
    }
}