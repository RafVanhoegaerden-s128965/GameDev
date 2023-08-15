using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Menu
{
    internal class GameOver : GameScreen
    {
        private new Game1 game => (Game1)base.Game;

        public SpriteBatch SpriteBatch;

        public GameOver(Game game) : base(game)
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            var Font = game.Content.Load<SpriteFont>("Fonts\\Font");
        }

        public override void Draw(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
