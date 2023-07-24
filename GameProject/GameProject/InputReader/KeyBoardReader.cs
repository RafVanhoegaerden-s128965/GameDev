using GameProject.Interface;
using GameProject.StrategyPattern;
using Microsoft.Xna.Framework;
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
        public Vector2 ReadMovementInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            // Controls

            if (state.IsKeyDown(Keys.A) && !(state.IsKeyDown(Keys.D))) // Move LEFT
            {
                direction.X -= 1;
            }
            else if (state.IsKeyDown(Keys.D) && !(state.IsKeyDown(Keys.A))) // Move RIGHT
            {
                direction.X += 1;
            }

            return direction;
        }
        public bool ReadIsFighting() // Attack
        {
            return Keyboard.GetState().IsKeyDown(Keys.Space);
        }
        public bool ReadIsJumping() // Jump
        {
            return Keyboard.GetState().IsKeyDown(Keys.W);
        }
    }
}
