using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.HUD.Menu.LevelComponents;
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

        public SpriteFont Font { get; set; }

        public Texture2D Background { get; set; }

        #region MainCharacter
        public MainCharacter MainCharacter { get; set; }
        public Vector2 MainCharacterInitPosition { get; set; }
        public HPBar HpBar { get; set; }
        #endregion

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

        public List<Rectangle> TrapPosition { get; set; } = new List<Rectangle>();
        public List<Trap> TrapList { get; set; } = new List<Trap>();
        #endregion

        #region PowerUps
        public List<Rectangle> PowerUpPosition { get; set; } = new List<Rectangle>();
        public List<PowerUp> PowerUpList { get; set; } = new List<PowerUp>();
        #endregion

        public void GetCollisionOfMap()
        {
            CollisionTiles = CollisionController.GetTilesCollision(Level, CollisionTiles);
            EnemyPath = CollisionController.GetEnemyPathCollision(Level, EnemyPath);
            TrapPosition = CollisionController.GetTrapCollision(Level, TrapPosition);
            PowerUpPosition = CollisionController.GetPowerUpPositionCollision(Level, PowerUpPosition);
            RespawnZone = CollisionController.GetRespawnCollision(Level, RespawnZone);
            FinishZone = CollisionController.GetFinishCollision(Level, FinishZone);
        }

        public void DrawLevel(GameTime gameTime)
        {
            SpriteBatch.Draw(Background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f); // Draw Background

            CollisionController.DrawLevel(SpriteBatch, Map); // Draw Level

            #region MainCharacter
            MainCharacter.Draw(SpriteBatch); // Draw MainCharacter
            HpBar.Draw(SpriteBatch); // Draw HP Bar
            #endregion
        }

        public void UpdateLevel(GameTime gameTime, Game1 game, int nextState)
        {
            LevelInteractions.GetMainCharacterToNextZone(MainCharacter, FinishZone, game, nextState);

            #region MainCharacter
            MainCharacterInitPosition = MainCharacter.Position; // Position
            MainCharacter.Update(gameTime); // Update
            LevelInteractions.GetMainCharacterCollides(MainCharacter, CollisionTiles, MainCharacterInitPosition); // Collision
            HpBar.Update(gameTime); // Update HP
            #endregion

            #region GetCollisions
            LevelInteractions.GetEnemyCollides(MainCharacter, EnemyList); // Enemies
            LevelInteractions.GetTrapCollides(MainCharacter, TrapList); // Traps
            LevelInteractions.GetPowerUpCollides(MainCharacter, PowerUpList); // PowerUps
            #endregion

            LevelInteractions.GetMainCharacterGameState(MainCharacter, game); // MainCharacter State
        }
    }
}
