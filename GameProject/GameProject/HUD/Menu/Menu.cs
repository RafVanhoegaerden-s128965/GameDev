using GameProject.HUD.Menu.Buttons;
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

        private List<Button> _components = new List<Button>();

        private Texture2D _background;

        private Texture2D _texture;
        public SpriteFont Font;


        public Menu(Game1 game) : base(game)
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            _background = Content.Load<Texture2D>("Backgrounds\\MenuBackground");

            #region ButtonTexture
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new[] { Color.White });
            #endregion

            Font = game.Content.Load<SpriteFont>("Fonts\\MenuFont");

            #region Buttons
            // Load Buttons
            var PlayButton = new PlayButton(game, _texture,new Vector2(650,800), Font); // Only Playbutton because Level1 & Level2 can't be completed without the JumpBoost from Level1
            var ExitButton = new ExitButton(game, _texture, new Vector2(1000, 800), Font);

            // Add Buttons to List
            _components.Add(PlayButton);
            _components.Add(ExitButton);
            #endregion
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(_background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f); // Draw Background


            // Draw Buttons
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
