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
        public void ReadInput(Entity entity)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            // Controls

            if (state.IsKeyDown(Keys.A) && !(state.IsKeyDown(Keys.D))) // Move LEFT
            {
                entity.Direction = new Vector2(-1, entity.Direction.Y);
            }
            else if (state.IsKeyDown(Keys.D) && !(state.IsKeyDown(Keys.A))) // Move RIGHT
            {
                entity.Direction = new Vector2(1, entity.Direction.Y);
            }
            else if(state.IsKeyDown(Keys.Space)) // Attack
            {
                entity.IsAttacking = true;
                entity.Direction = new Vector2(0, 0);
            }
            else // Default state
            {
                entity.Direction = new Vector2(0, 0);
                entity.IsAttacking = false;
            }
        }
    }
}
