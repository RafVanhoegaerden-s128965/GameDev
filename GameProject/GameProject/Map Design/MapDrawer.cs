using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace GameProject.Map
{
    internal class MapDrawer : Map
    {
        // DRAW Level
        public MapDrawer(SpriteBatch _spriteBatch, TmxMap _map, Texture2D _tileset)
        {
            this.SpriteBatch = _spriteBatch;
            this.TileMap = _map;
            this.Tileset = _tileset;

            /// Fixed values
            this.TileWidth = _map.Tilesets[0].TileWidth;
            this.TilesetTilesWide = _tileset.Width / TileWidth;
            this.TileHeight = _map.Tilesets[0].TileHeight;
        }

        public void Draw()
        {
            for (int i = 0; i < TileMap.TileLayers.Count; i++)
            {
                for (int j = 0; j < TileMap.TileLayers[i].Tiles.Count; j++)
                {
                    int gid = TileMap.TileLayers[i].Tiles[j].Gid;
                    if(gid == 0)
                    {
                        // do nothing
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame%TilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)TilesetTilesWide);
                        float x = (j%TileMap.Width)*TileMap.TileWidth;
                        float y = (float)Math.Floor(j / (double)TileMap.Width) * TileMap.TileHeight;
                        Rectangle tilesetRec = new Rectangle((TileWidth)*column, (TileHeight)*row, TileWidth, TileHeight);
                        SpriteBatch.Draw(Tileset, new Rectangle((int)x, (int)y, TileWidth, TileHeight), tilesetRec, Color.White);
                    }
                }
            }
        }
    }
}
