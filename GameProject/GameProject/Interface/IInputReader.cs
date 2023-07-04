using GameProject.StrategyPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface IInputReader
    {
         void ReadInput(Entity entity);
    }
}
