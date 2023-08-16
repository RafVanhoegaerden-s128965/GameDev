using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Menu
{
    internal class Menu : GameScreen
    {
        private new Game1 game => (Game1)base.Game;

        public SpriteBatch SpriteBatch;

        private List<MenuButton> _components = new List<MenuButton>();

        private Texture2D _texture;
        public SpriteFont Font;


        public Menu(Game game) : base(game)
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            #region ButtonTexture
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new[] { Color.White });
            #endregion

            Font = game.Content.Load<SpriteFont>("Fonts\\Font");

            #region Buttons
            // Load Buttons
            var Level1Button = new MenuButton(_texture,new Vector2(100,100), Font);

            // Add Buttons to List
            _components.Add(Level1Button);
            #endregion
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            Vector2 position = new Vector2(800, 400);
            Color textColor = Color.Black;
            string text = "Welcome!";
            SpriteBatch.DrawString(Font, text, position + new Vector2(1, 1), textColor);
            SpriteBatch.DrawString(Font, text, position + new Vector2(-1, 1), textColor);
            SpriteBatch.DrawString(Font, text, position + new Vector2(1, -1), textColor);
            SpriteBatch.DrawString(Font, text, position + new Vector2(-1, -1), textColor);
            foreach (var component in _components)
            {
                component.Draw(SpriteBatch);
            }

            SpriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
