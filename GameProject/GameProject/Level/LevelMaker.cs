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
    internal abstract class LevelMaker : GameScreen
    {
        public LevelMaker(Game game) : base(game) { } // Gamescreen
        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D Background { get; set; }

        public MainCharacter MainCharacter { get; set; }
        public Vector2 MainCharacterInitPosition { get; set; }

        #region Tiled
        public TmxMap Level { get; set; }
        public Texture2D Tileset { get; set; }
        public MapDrawer Map { get; set; }
        #endregion

        #region Collision
        public MapCollision CollisionController { get; set; } = new MapCollision();
        public LevelInteractions LevelCollisionController { get; set; } = new LevelInteractions();
        public List<Rectangle> CollisionTiles { get; set; } = new List<Rectangle>();
        #endregion

        public List<Rectangle> RespawnZone { get; set; } = new List<Rectangle>();


        public void GetCollisionOfMap()
        {
            CollisionTiles = CollisionController.GetTilesCollision(Level, CollisionTiles);
            RespawnZone = CollisionController.GetRespawnCollision(Level, RespawnZone);
        }

        public void DrawLevel(GameTime gameTime)
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(Background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f); // Draw Background

            CollisionController.DrawLevel(Map); // Draw Level

            MainCharacter.Draw(SpriteBatch); // Draw MainCharacter

            SpriteBatch.End();
        }

        public void UpdateLevel(GameTime gameTime)
        {
            MainCharacterInitPosition = MainCharacter.Position;

            MainCharacter.Update(gameTime, SpriteBatch); // Update MainCharacter

            LevelCollisionController.GetMainCharacterCollides(MainCharacter, CollisionTiles, MainCharacterInitPosition);
        }
    }
}
