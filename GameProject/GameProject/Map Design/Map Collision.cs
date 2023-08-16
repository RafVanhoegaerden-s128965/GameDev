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

        public Rectangle GetFinishCollision(TmxMap _map, Rectangle endRect)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collision"].Objects)
            {
                if (CollisionRect.Name == "Finish")
                {
                    endRect = new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height);
                }
            }
            return endRect;

        }

        public List<Rectangle> GetEnemyPathCollision(TmxMap map, List<Rectangle> enemyPath)
        {
            foreach (var CollisionRect in map.ObjectGroups["EnemyPath"].Objects)
            {
                enemyPath.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }

            return enemyPath;
        }

        public List<Rectangle> GetTrapCollision(TmxMap map, List<Rectangle> trapPosition)
        {
            foreach (var CollisionRect in map.ObjectGroups["Trap"].Objects)
            {
                trapPosition.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }

            return trapPosition;
        }

        public List<Rectangle> GetPowerUpPositionCollision(TmxMap _map, List<Rectangle> position)
        {
            foreach (var CollisionRect in _map.ObjectGroups["PowerUpPosition"].Objects)
            {
                position.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }

            return position;
        }
    }
}
