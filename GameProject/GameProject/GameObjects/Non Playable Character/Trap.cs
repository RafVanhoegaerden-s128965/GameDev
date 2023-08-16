using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Non_Playable_Character
{
    internal class Trap : Object
    {
        public Trap(ContentManager content, Rectangle position)
        {
            Position = new Vector2(position.X, position.Y);

            // Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, position.Width, position.Height);

        }
    }
}
