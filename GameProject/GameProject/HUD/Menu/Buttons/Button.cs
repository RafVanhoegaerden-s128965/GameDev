using GameProject.InputReader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Menu.Buttons
{
    internal abstract class Button : HudComponent
    {
        public Game1 Game { get; set; }
        public ScreenManager ScreenManager { get; set; }

        public Texture2D Texture { get; set; }
        public SpriteFont Font { get; set; }

        public Vector2 Position { get; set; }

        public int ButtonWidth { get; set; } = 225;
        public int ButtonHeight { get; set; } = 75;

        #region Mouse
        public MouseState CurrentMouseState { get; set; }
        public MouseState PreviousMouseState { get; set; }
        public bool IsHovered { get; set; }
        #endregion

        #region BackgroundButton
        public Rectangle BackgroundButton { get; set; }
        public Color BackgroundButtonColor { get; set; } = new Color(98, 92, 127); // Pruple
        #endregion

        #region BorderButton
        public Rectangle BorderButton { get; set; }
        public Color BorderButtonColor { get; set; } = new Color(255, 206, 99); // Yellow
        public Color OriginalBorderButtonColor { get; set; } = new Color(255, 206, 99); // Yellow
        #endregion

        #region FillButton
        public Rectangle FillButton { get; set; }
        public Color FillButtonColor { get; set; } = new Color(98, 92, 127); // Purple
        #endregion

        #region Text
        public string LabelPlayText { get; set; }
        public Vector2 LabelPosition { get; set; }
        public Color TextColor { get; set; } = new Color(228, 142, 215); // Pink
        #endregion

        public bool IsClicked()
        {
            MouseState currentMouseState = Mouse.GetState();

            if (BackgroundButton.Contains(currentMouseState.Position) &&
                currentMouseState.LeftButton == ButtonState.Released &&
                PreviousMouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            PreviousMouseState = currentMouseState;
            return false;
        }
    }
}
