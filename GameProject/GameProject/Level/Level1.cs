using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Non_Playable_Character.Enemies;
using GameProject.GameObjects.Playable;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using TiledSharp;

namespace GameProject.Level
{
    internal class Level1 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;

        private Bat Bat1 { get; set; }
        private Bat Bat2 { get; set; }
        private Boar Boar { get; set; }


        public Level1(Game game, MainCharacter mainCharacter) : base(game) 
        {
            this.MainCharacter = mainCharacter;
        }

        public override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Background
            Background = Content.Load<Texture2D>("Background");

            // Load Level
            Level = new  TmxMap("Content\\Levels\\Level1.tmx");
            Tileset = Content.Load<Texture2D>("TileSheets\\" + Level.Tilesets[0].Name.ToString());
            Map = new MapDrawer(Level, Tileset);

            GetCollisionOfMap();

            #region Enemies
            // Load Enemies
            Boar = new Boar(Content, EnemyPath[0]);
            Bat1 = new Bat(Content, EnemyPath[1]);
            Bat2 = new Bat(Content, EnemyPath[2]);

            // Add to List
            EnemyList.Add(Bat1);
            EnemyList.Add(Bat2);
            EnemyList.Add(Boar);
            #endregion

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            DrawLevel(gameTime); // Draw Map

            #region Entities
            // Draw Enemies
            Boar.Draw(SpriteBatch);
            Bat1.Draw(SpriteBatch);
            Bat2.Draw(SpriteBatch);
            #endregion

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateLevel(gameTime); // Update Map

            #region Entities
            // Update Enemies
            Boar.Update(gameTime);
            Bat1.Update(gameTime);
            Bat2.Update(gameTime);
            #endregion
        }
    }
}
