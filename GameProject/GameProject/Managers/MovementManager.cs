using GameProject.GameObjects;
using GameProject.Interface;
using GameProject.Settings;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Managers
{
    internal class MovementManager
    {
        public void Move(IMovable entity)
        {
            entity.Direction = entity.InputReader.ReadInput();

            entity.Speed += entity.Acceleration;
            entity.Direction *= entity.Speed;
            entity.Position += entity.Direction;

            // Collision with screen boundaries
            if (entity.Position.X > Screen.Width - 100)
            {
                entity.Position = new Vector2(Screen.Width - 100, entity.Position.Y);
            }
            else if (entity.Position.X <= 0)
            {
                entity.Position = new Vector2(0, entity.Position.Y);
            }
        }
    }
}
