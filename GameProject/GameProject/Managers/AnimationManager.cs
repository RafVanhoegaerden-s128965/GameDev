using GameProject.Interface;
using GameProject.StrategyPattern;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Managers
{
    internal class AnimationManager
    {
        public bool IsWalking(IMovable entity)
        {
            if(entity.Direction.X > 0)
            {
                entity.IsMoving = true;
                entity.DirectionPosition = SpriteEffects.None;
            }
            else if(entity.Direction.X < 0)
            {
                entity.IsMoving = true;
                entity.DirectionPosition = SpriteEffects.FlipHorizontally;
            }
            else
            {
                entity.IsMoving = false;
            }

            return entity.IsMoving;
        }
        public bool IsAttacking(Player entity)
        {
            
            return entity.IsAttacking;
        }
    }
}
