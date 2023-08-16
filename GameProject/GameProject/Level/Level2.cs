using GameProject.GameObjects.Non_Playable_Character.Enemies;
using GameProject.GameObjects.Non_Playable_Character;
using GameProject.GameObjects.Playable;
using GameProject.GameObjects.PowerUps;
using GameProject.HUD.Menu.LevelComponents;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace GameProject.Level
{
    internal class Level2 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;

        #region Enemies

        #endregion

        #region PowerUps

        #endregion

        public Level2(Game game, ContentManager content, MainCharacter mainCharacter, HPBar hpBar, bool jumpPowerUpActive) : base(game)
        {
            this.MainCharacter = mainCharacter;
            //this.MainCharacter.JumpPowerUpActive = jumpPowerUpActive;
            this.MainCharacter.JumpPowerUpActive = true;


            this.HpBar = hpBar;

            this.Font = content.Load<SpriteFont>("Fonts\\Font");
        }

        public override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            #region Map
            // Load Background
            Background = Content.Load<Texture2D>("Background");

            // Load Level
            Level = new TmxMap("Content\\Levels\\Level2.tmx");
            Tileset = Content.Load<Texture2D>("TileSheets\\Level2 TileSheet");
            Map = new MapDrawer(Level, Tileset);
            GetCollisionOfMap();

            MainCharacter.Position = new Vector2(RespawnZone[0].X, RespawnZone[0].Y);
            #endregion

            #region Enemies
            // Load Enemies

            // Add to List

            #endregion

            #region PowerUps

            #endregion

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            DrawLevel(gameTime); // Draw Map

            #region Enemies
            // Draw Enemies

            #endregion

            #region PowerUps
            // Draw PowerUps

            #region PowerUpText
            // Text Label
            if (MainCharacter.JumpPowerUpActive)
            {
                string labelText = $"JumpBoost Activated";
                Vector2 labelPosition = new Vector2(85, 995);
                Color labelColor = Color.Yellow;
                SpriteBatch.DrawString(Font, labelText, labelPosition, labelColor);
            }
            #endregion
            #endregion

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateLevel(gameTime, this.Game, 3); // Update Map + Last value = State of Game ==> load new screen

            #region Enemies
            // Update Enemies

            #endregion

            #region PowerUps
            // Update PowerUps

            #endregion
        }
    }
}
