using GameProject.GameObjects.Playable;
using GameProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace GameProject.Level
{
    internal class Level1 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;
        public Level1(Game game) : base(game) { }

        public override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Background
            Background = Content.Load<Texture2D>("Background");

            // Load Level
            Level = new  TmxMap("Content\\Levels\\Level1.tmx");
            Tileset = Content.Load<Texture2D>("TileSheets\\" + Level.Tilesets[0].Name.ToString());
            Map = new MapDrawer(SpriteBatch, Level, Tileset);

            GetCollisionOfMap();

            MainCharacter = new MainCharacter(new Vector2(RespawnZone[0].X, RespawnZone[0].Y), Content);

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            DrawLevel(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateLevel(gameTime);
        }
    }
}
