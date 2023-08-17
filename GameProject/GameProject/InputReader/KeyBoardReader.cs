using GameProject.GameObjects.Playable;
using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.InputReader
{
    internal class KeyBoardReader : IInputReader
    {
        public void ReadInput(Game1 game, Player entity)
        {
            KeyboardState state = Keyboard.GetState();

            Game1 Game = game;

            // Controls

            if (state.IsKeyDown(Keys.A) && !(state.IsKeyDown(Keys.D))) // Running Right state
            {
                entity.CurrentMovementState = CurrentMovementState.Running;

                entity.DirectionPosition = SpriteEffects.FlipHorizontally;

                entity.Direction = new Vector2(-1, 0);
            }
            else if (state.IsKeyDown(Keys.D) && !(state.IsKeyDown(Keys.A))) // Running Right state
            {
                entity.CurrentMovementState = CurrentMovementState.Running;
                
                entity.DirectionPosition = SpriteEffects.None;

                entity.Direction = new Vector2(1, 0);
            }
            else if (state.IsKeyDown(Keys.Space)) // Attack state
            {
                entity.CurrentMovementState = CurrentMovementState.Attacking;

                entity.Direction = new Vector2(0, 0);
            }
            else if (state.IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }
            else // Default state
            {
                entity.CurrentMovementState = CurrentMovementState.Idle;

                entity.Direction = new Vector2(0, 0);
            }
        }
    }
}
