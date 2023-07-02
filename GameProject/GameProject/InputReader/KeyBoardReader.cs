using GameProject.Interface;
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
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            // Move LEFT
            if (state.IsKeyDown(Keys.A) && !(state.IsKeyDown(Keys.D)))
            {
                direction.X -= 1;
            }
            // Move RIGHT
            else if (state.IsKeyDown(Keys.D) && !(state.IsKeyDown(Keys.A)))
            {
                direction.X += 1;
            }

            return direction;
        }
    }
}
