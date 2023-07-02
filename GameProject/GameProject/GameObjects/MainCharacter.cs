using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects
{
    internal class MainCharacter
    {
        public Texture2D MCTexture;
        public Rectangle MCHitbox;

        public MainCharacter(Texture2D _texture)
        {
            this.MCTexture = _texture;
            this.MCHitbox = new Rectangle(100, 100, 100, 100); // X, Y, width, height
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MCTexture, MCHitbox, Color.Red); // Texture, Hitbox, Color
        }
    }
}
