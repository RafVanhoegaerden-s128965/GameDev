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
        public void DrawLevel(SpriteBatch spriteBatch, MapDrawer desiredLevel)
        {
            desiredLevel.Draw(spriteBatch);
        }

        public List<Rectangle> GetTilesCollision(TmxMap map, List<Rectangle> collisionTiles)
        {
            foreach (var CollisionRect in map.ObjectGroups["Collision"].Objects)
            {
                if (CollisionRect.Name == "")
                {
                    collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height - 10));
                }
            }
            return collisionTiles;
        }

        public List<Rectangle> GetRespawnCollision(TmxMap map, List<Rectangle> collisionTiles)
        {
            foreach (var CollisionRect in map.ObjectGroups["Collision"].Objects)
            {
                if (CollisionRect.Name == "Spawn")
                {
                    collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height));
                }
            }
            return collisionTiles;
        }

        public Rectangle GetFinishCollision(TmxMap _map, Rectangle _endRect)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collision"].Objects)
            {
                if (CollisionRect.Name == "Finish")
                {
                    _endRect = new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height);
                }
            }
            return _endRect;

        }

        public List<Rectangle> GetEnemyPathCollision(TmxMap _map, List<Rectangle> _enemyPath)
        {
            foreach (var CollisionRect in _map.ObjectGroups["EnemyPath"].Objects)
            {
                _enemyPath.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }

            return _enemyPath;
        }

    }
}
