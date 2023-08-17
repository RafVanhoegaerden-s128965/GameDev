using FontStashSharp;
using GameProject.GameObjects.Playable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Menu.Buttons
{
    internal class PlayButton : Button
    {
        public PlayButton(Game1 game, Texture2D texture, Vector2 position, SpriteFont font)
        {
            Game = game;

            Texture = texture;

            Font = font;

            Position = position;

            BackgroundButton = new Rectangle((int)Position.X, (int)Position.Y, ButtonWidth + 20, ButtonHeight + 20);
            BorderButton = new Rectangle((int)Position.X + 10, (int)Position.Y + 10, ButtonWidth, ButtonHeight);
            FillButton = new Rectangle((int)Position.X + 20, (int)Position.Y + 20, ButtonWidth - 20, ButtonHeight - 20);

            PreviousMouseState = Mouse.GetState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            BorderButtonColor = IsHovered ? new Color(254, 253, 230) : OriginalBorderButtonColor;

            // Background Button
            spriteBatch.Draw(Texture, BackgroundButton, BackgroundButtonColor);

            // Border Button
            spriteBatch.Draw(Texture, BorderButton, BorderButtonColor);

            // Fill Button
            spriteBatch.Draw(Texture, FillButton, FillButtonColor);

            // Text Label
            LabelPlayText = "Play";
            LabelPosition = new Vector2((int)Position.X + 48, (int)Position.Y + 28);
            spriteBatch.DrawString(Font, LabelPlayText, LabelPosition, TextColor);
        }

        public override void Update(GameTime gameTime)
        {
            CurrentMouseState = Mouse.GetState();

            IsHovered = FillButton.Contains(CurrentMouseState.Position);

            if (IsHovered && CurrentMouseState.LeftButton == ButtonState.Released && PreviousMouseState.LeftButton == ButtonState.Pressed)
            {
                if (IsClicked())
                {
                    Game.StateOfGame = CurrentGameState.Level1;
                }
            }

            PreviousMouseState = CurrentMouseState;
        }
    }
}
