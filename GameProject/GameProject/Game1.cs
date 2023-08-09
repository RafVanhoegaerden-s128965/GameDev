using GameProject.GameObjects.Playable;
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
        private Texture2D _background;
        private TmxMap _map;
        private MapDrawer _mapDrawer;


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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //_blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            //_blockTexture.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _background = Content.Load<Texture2D>("Background");

            _map = new TmxMap("Content\\Levels\\Level1.tmx");
            var _tileset = Content.Load<Texture2D>("TileSheets\\" + _map.Tilesets[0].Name.ToString());
            _mapDrawer = new MapDrawer(_spriteBatch,_map, _tileset);

            _mainCharacter = new MainCharacter(this.Content);
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
            _spriteBatch.Draw(_background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f);

            _mapDrawer.Draw();

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}