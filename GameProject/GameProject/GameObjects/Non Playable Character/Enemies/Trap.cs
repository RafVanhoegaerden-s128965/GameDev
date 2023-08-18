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
        // No effects because I generated the Sprite + reaction with CollisionRectangle in the Map already 
        public Trap(ContentManager content, Rectangle position)
        {
            Position = new Vector2(position.X, position.Y);

            #region Hitbox
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, position.Width, position.Height);
            #endregion
        }
    }
}
