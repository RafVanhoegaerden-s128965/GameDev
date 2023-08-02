using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.GameObjects.Playable;
using GameProject.Map;
using TiledSharp;
using GameProject.Map_Design;

namespace GameProject.Level_Design
{
    internal abstract class LevelMaker : GameScreen
    {
        #region Initialise
        public LevelMaker(Game game) : base(game) { } // GameScreen
        public SpriteBatch _spriteBatch { get; set; }
        public List<Rectangle> RespawnZone { get; set; } = new List<Rectangle>(); // Respawn point

        #region GameObjects
        private MainCharacter _mainCharacter; // Player
        #endregion

        #region Map
        public TmxMap _map { get; set; }
        public Texture2D _tileset { get; set; }
        public MapDrawer _mapMaker { get; set; }
        #endregion

        #region Collision
        public List<Rectangle> CollisionTiles { get; set; } = new List<Rectangle>();
        public Rectangle EndZone { get; set; } = new Rectangle();
        public MapCollision _collisionController { get; set; } = new MapCollision();
        //public LevelInteraction LevelCollisionControler { get; set; } = new LevelInteraction();
        #endregion

        #endregion

        public void DrawLevel(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _collisionController.DrawLevelMap(_spriteBatch, _mapMaker); // Draw: Map

            // Draw entities =>
            _mainCharacter.Draw(_spriteBatch); // Draw: Player

            _spriteBatch.End();
        }
        public void UpdateLevel(GameTime gameTime, Game1 Game)
        {
            _mainCharacter.Update(gameTime);
        }
    }
}
