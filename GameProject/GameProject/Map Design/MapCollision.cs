using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace GameProject.Map_Design
{
    internal class MapCollision
    {
        // COLLISION Map
        public void DrawLevelMap(SpriteBatch spriteBatch, MapDrawer _desiredMap)
        {
            _desiredMap.Draw(spriteBatch);
        }
    }
}
