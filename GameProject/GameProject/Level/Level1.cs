using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Non_Playable_Character.Enemies;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.HUD;
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

        private JumpPowerUp PowerUp1 { get; set; }

        public Level1(Game game, MainCharacter mainCharacter, HPBar hpBar) : base(game) 
        {
            this.MainCharacter = mainCharacter;
            this.HpBar = hpBar;
        }

        public override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            #region Map
            // Load Background
            Background = Content.Load<Texture2D>("Background");

            // Load Level
            Level = new  TmxMap("Content\\Levels\\Level1.tmx");
            Tileset = Content.Load<Texture2D>("TileSheets\\" + Level.Tilesets[0].Name.ToString());
            Map = new MapDrawer(Level, Tileset);

            GetCollisionOfMap();
            #endregion

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

            #region PowerUps
            PowerUp1 = new JumpPowerUp(Content, PowerUpPosition[0]);
            PowerUpList.Add(PowerUp1);
            #endregion

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            DrawLevel(gameTime); // Draw Map

            #region Objects
            // Draw Enemies
            if (Boar.IsAlive){ Boar.Draw(SpriteBatch); }
            if (Bat1.IsAlive){ Bat1.Draw(SpriteBatch); }
            if (Bat2.IsAlive) { Bat2.Draw(SpriteBatch); }

            // Draw PowerUps
            if (!MainCharacter.PowerUpActive) { PowerUp1.Draw(SpriteBatch); }
            #endregion

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateLevel(gameTime); // Update Map

            #region Objects
            // Update Enemies
            if (Boar.IsAlive) { Boar.Update(gameTime); }
            if (Bat1.IsAlive) { Bat1.Update(gameTime); }
            if (Bat2.IsAlive) { Bat2.Update(gameTime); }

            // Update PowerUps
            if (!MainCharacter.PowerUpActive) { PowerUp1.Update(gameTime); }
            #endregion
        }
    }
}
