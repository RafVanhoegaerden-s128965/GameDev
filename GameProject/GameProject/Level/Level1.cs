﻿using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Non_Playable_Character.Enemies;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.HUD;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace GameProject.Level
{
    internal class Level1 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;

        private SpriteFont _font { get; set; }

        #region Enemies
        private Bat _bat1 { get; set; }
        private Bat _bat2 { get; set; }
        private Boar _boar { get; set; }
        #endregion

        #region PowerUps
        private JumpPowerUp _powerUp1 { get; set; }
        #endregion

        public Level1(Game game, ContentManager content, MainCharacter mainCharacter, HPBar hpBar) : base(game) 
        {
            this.MainCharacter = mainCharacter;
            this.HpBar = hpBar;
            this._font = content.Load<SpriteFont>("Fonts\\Font");
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
            _boar = new Boar(Content, EnemyPath[0]);
            _bat1 = new Bat(Content, EnemyPath[1]);
            _bat2 = new Bat(Content, EnemyPath[2]);

            // Add to List
            EnemyList.Add(_bat1);
            EnemyList.Add(_bat2);
            EnemyList.Add(_boar);
            #endregion

            #region PowerUps
            _powerUp1 = new JumpPowerUp(Content, PowerUpPosition[0]);
            PowerUpList.Add(_powerUp1);
            #endregion

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            DrawLevel(gameTime); // Draw Map

            #region Enemies
            // Draw Enemies
            if (_boar.IsAlive){ _boar.Draw(SpriteBatch); }
            if (_bat1.IsAlive){ _bat1.Draw(SpriteBatch); }
            if (_bat2.IsAlive) { _bat2.Draw(SpriteBatch); }
            #endregion

            #region PowerUps
            // Draw PowerUps
            if (!MainCharacter.PowerUpActive) { _powerUp1.Draw(SpriteBatch); }

            #region PowerUpText
            // Text Label
            if (MainCharacter.PowerUpActive)
            {
                string labelText = $"JumpBoost Activated";
                Vector2 labelPosition = new Vector2(780, 920);
                Color labelColor = Color.Yellow;
                SpriteBatch.DrawString(_font, labelText, labelPosition, labelColor);
            }
            #endregion
            #endregion

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateLevel(gameTime); // Update Map

            #region Enemies
            // Update Enemies
            if (_boar.IsAlive) { _boar.Update(gameTime); }
            if (_bat1.IsAlive) { _bat1.Update(gameTime); }
            if (_bat2.IsAlive) { _bat2.Update(gameTime); }
            #endregion

            #region PowerUps
            // Update PowerUps
            if (!MainCharacter.PowerUpActive) { _powerUp1.Update(gameTime); }
            #endregion
        }
    }
}
