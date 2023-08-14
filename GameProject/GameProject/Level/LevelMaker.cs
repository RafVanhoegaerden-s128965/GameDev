using GameProject.GameObjects.Non_Playable_Character;
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

        public Vector2 EnemyInitPosition { get; set; }

        #region Tiled
        public TmxMap Level { get; set; }
        public Texture2D Tileset { get; set; }
        public MapDrawer Map { get; set; }
        #endregion

        #region Collision
        public MapCollision CollisionController { get; set; } = new MapCollision();
        public LevelInteractions LevelInteractions { get; set; } = new LevelInteractions();
        public List<Rectangle> CollisionTiles { get; set; } = new List<Rectangle>();
        #endregion

        #region Zones
        public List<Rectangle> RespawnZone { get; set; } = new List<Rectangle>();
        public Rectangle FinishZone { get; set; } = new Rectangle();
        #endregion

        #region Enemies
        public List<Rectangle> EnemyPath { get; set; } = new List<Rectangle>();
        public List<Enemy> EnemyList { get; set; } = new List<Enemy>();
        #endregion

        public void GetCollisionOfMap()
        {
            CollisionTiles = CollisionController.GetTilesCollision(Level, CollisionTiles);
            EnemyPath = CollisionController.GetEnemyPathCollision(Level, EnemyPath);
            RespawnZone = CollisionController.GetRespawnCollision(Level, RespawnZone);
            FinishZone = CollisionController.GetFinishCollision(Level, FinishZone);
        }

        public void DrawLevel(GameTime gameTime)
        {
            SpriteBatch.Draw(Background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f); // Draw Background

            CollisionController.DrawLevel(SpriteBatch, Map); // Draw Level

            MainCharacter.Draw(SpriteBatch); // Draw MainCharacter
        }

        public void UpdateLevel(GameTime gameTime)
        {
            EnemyInitPosition = LevelInteractions.GetEnemyPosition(EnemyList, EnemyInitPosition);

            #region MainCharacter
            MainCharacterInitPosition = MainCharacter.Position; // Position
            MainCharacter.Update(gameTime); // Update
            LevelInteractions.GetMainCharacterCollides(MainCharacter, CollisionTiles, MainCharacterInitPosition); // Collision
            #endregion

            //LevelInteractions.GetEnemyCollides(CollisionTiles, EnemyList, EnemyInitPosition);

        }
    }
}
