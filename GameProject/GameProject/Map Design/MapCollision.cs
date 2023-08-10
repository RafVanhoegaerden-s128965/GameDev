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
        public void DrawLevel(MapDrawer _desiredLevel)
        {
            _desiredLevel.Draw();
        }

        public List<Rectangle> GetTilesCollision(TmxMap _map, List<Rectangle> _collisionTiles)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collision"].Objects)
            {
                if (CollisionRect.Name == "")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height - 10));
                }
            }
            return _collisionTiles;
        }

        public List<Rectangle> GetRespawnCollision(TmxMap _map, List<Rectangle> _collisionTiles)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collision"].Objects)
            {
                if (CollisionRect.Name == "Spawn")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height));
                }
            }
            return _collisionTiles;
        }
    }
}
