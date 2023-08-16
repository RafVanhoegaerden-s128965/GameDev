using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Ending
{
    internal class GameOver : GameScreen
    {
        private new Game1 game => (Game1)Game;

        public SpriteBatch SpriteBatch;

        public GameOver(Game game) : base(game)
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            var Font = game.Content.Load<SpriteFont>("Fonts\\Font");
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            SpriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"You Lost", new Vector2(330, 150), Color.Red);

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
