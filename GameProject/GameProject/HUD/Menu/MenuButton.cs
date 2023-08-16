using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Menu
{
    internal class MenuButton : HudComponent
    {
        private Rectangle _rectangle;
        private Texture2D _texture;

        private SpriteFont _font;

        private Vector2 _position;

        public MenuButton(Texture2D texture, Vector2 position, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            _position = position;

            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, 100, 200);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
