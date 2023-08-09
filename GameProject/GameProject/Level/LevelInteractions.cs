using GameProject.GameObjects.Playable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Level
{
    internal class LevelInteractions
    {
        public void GetMainCharacterCollides(MainCharacter _mainCharacter, List<Rectangle> _collisionTiles, Vector2 _mainCharacterInitPosition)
        {
            foreach (var rectangle in _collisionTiles)
            {
                if (!_mainCharacter.IsJumping) _mainCharacter.IsFalling = true;

                if (rectangle.Intersects(_mainCharacter.Hitbox))
                {
                    _mainCharacter.Position = new Vector2(_mainCharacterInitPosition.X, _mainCharacterInitPosition.Y);
                    _mainCharacter.IsFalling = false;
                    break;
                }

            }

        }
    }
}
