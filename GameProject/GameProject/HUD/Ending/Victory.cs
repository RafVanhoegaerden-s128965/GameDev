using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.HUD.Menu.Buttons;

namespace GameProject.HUD.Ending
{
    internal class Victory : GameScreen
    {
        private new Game1 game => (Game1)base.Game;

        public SpriteBatch SpriteBatch;

        private List<Button> _components = new List<Button>();

        private Texture2D _background;

        private Texture2D _texture;
        public SpriteFont Font;
        private SpriteFont TitleFont;

        public Victory(Game1 game) : base(game)
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            _background = Content.Load<Texture2D>("Backgrounds\\EndBackground");

            #region ButtonTexture
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new[] { Color.White });
            #endregion

            Font = game.Content.Load<SpriteFont>("Fonts\\MenuFont");
            TitleFont = game.Content.Load<SpriteFont>("Fonts\\EndFont");


            #region Buttons
            // Load Buttons
            var RestartButton = new RestartButton(game, _texture, new Vector2(760, 500), Font); // Only Playbutton because Level1 & Level2 can't be completed without the JumpBoost from Level1
            var ExitButton = new ExitButton(game, _texture, new Vector2(825, 630), Font);

            // Add Buttons to List
            _components.Add(RestartButton);
            _components.Add(ExitButton);
            #endregion
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(_background, new Vector2(-50, -200), null, Color.White, 0f, Vector2.Zero, 1.2f, SpriteEffects.None, 0f); // Draw Background

            #region VictoryText
            Color TextColor = new Color(255, 206, 99);
            string labelExitText = "Victory";
            var LabelPosition = new Vector2(540, 300);
            SpriteBatch.DrawString(TitleFont, labelExitText, LabelPosition, TextColor);
            #endregion

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
