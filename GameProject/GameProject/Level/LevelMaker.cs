using GameProject.GameObjects.Playable;
using GameProject.Map;
using GameProject.Map_Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using TiledSharp;

namespace GameProject.Level
{
    internal class LevelMaker : GameScreen
    {
        public LevelMaker(Game game) : base(game) { }       //dit is van gamescreen
        private SpriteBatch _spriteBatch { get; set; }

        private MainCharacter _mainCharacter;

        private TmxMap _map { get; set; }
        private Texture2D _tileset { get; set; }
        private MapDrawer _mapMaker { get; set; }

        public List<Rectangle> CollisionTiles { get; set; } = new List<Rectangle>();
        public List<Rectangle> RespawnZone { get; set; } = new List<Rectangle>();

        public MapCollision _collisionController { get; set; } = new MapCollision();

        public void GetCollisionOfMap()
        {
            CollisionTiles = _collisionController.GetTilesCollision(_map, CollisionTiles);
            RespawnZone = _collisionController.GetRespawnCollision(_map, RespawnZone);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _collisionController.DrawLevel(_mapMaker); // Tekenen van de map

            _mainCharacter.Draw(_spriteBatch); //Tekenen van Player

            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
