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
        private Texture2D _textureMC;
        private Rectangle _hitboxMC;
        //Test Hitbox
        private Texture2D _textureTest;
        private Rectangle _hitboxTest;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here8

            _hitboxMC = new Rectangle(100, 100, 100, 100); // X, Y, width, height

            _hitboxTest = new Rectangle(400, 100, 100, 100); // X, Y, width, height

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _textureMC = new Texture2D(GraphicsDevice,1,1); // GraphicsDevice, width, height
            _textureMC.SetData(new[] { Color.White });

            _textureTest = new Texture2D(GraphicsDevice, 1, 1); // GraphicsDevice, width, height
            _textureTest.SetData(new[] { Color.White });

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
            _spriteBatch.Draw(_textureMC, _hitboxMC, Color.Red); // Texture, Hitbox, Color
            _spriteBatch.Draw(_textureTest, _hitboxTest, Color.Blue); // Texture, Hitbox, Color

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}