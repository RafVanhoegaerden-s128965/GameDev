using GameProject.GameObjects.Playable;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Level
{
    internal class LevelInteractions
    {
        public void GetMainCharacterCollides(MainCharacter mainCharacter, List<Rectangle> collisionTiles, Vector2 mainCharacterInitPosition)
        {
            foreach (var rectangle in collisionTiles)
            {
                if (!mainCharacter.IsJumping)
                {
                    mainCharacter.IsFalling = true;
                }

                if (rectangle.Intersects(mainCharacter.Hitbox))
                {
                    mainCharacter.Position = new Vector2(mainCharacter.Position.X, mainCharacterInitPosition.Y);

                    mainCharacter.IsFalling = false;
                    break;
                }

                //bool IsTouchingLeft()
                //{
                //    return mainCharacter.Hitbox.Right + mainCharacter.Direction.X > rectangle.Left &&
                //        mainCharacter.Hitbox.Left < rectangle.Left &&
                //        mainCharacter.Hitbox.Bottom > rectangle.Top &&
                //        mainCharacter.Hitbox.Top < rectangle.Bottom;
                //}

                //bool IsTouchingRight()
                //{
                //    return mainCharacter.Hitbox.Left + mainCharacter.Direction.X < rectangle.Right &&
                //        mainCharacter.Hitbox.Right > rectangle.Right &&
                //        mainCharacter.Hitbox.Bottom > rectangle.Top &&
                //        mainCharacter.Hitbox.Top < rectangle.Bottom;
                //}

                //bool IsTouchingTop()
                //{
                //    return mainCharacter.Hitbox.Bottom + mainCharacter.Direction.Y > rectangle.Top &&
                //        mainCharacter.Hitbox.Top < rectangle.Top &&
                //        mainCharacter.Hitbox.Right > rectangle.Left &&
                //        mainCharacter.Hitbox.Left < rectangle.Right;
                //}

                //bool IsTouchingBottom()
                //{
                //    return mainCharacter.Hitbox.Top + mainCharacter.Direction.Y < rectangle.Bottom &&
                //        mainCharacter.Hitbox.Bottom > rectangle.Bottom &&
                //        mainCharacter.Hitbox.Right > rectangle.Left &&
                //        mainCharacter.Hitbox.Left < rectangle.Right;
                //}
            }
        }
    }
}
