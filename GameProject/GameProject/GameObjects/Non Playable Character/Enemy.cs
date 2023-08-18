using GameProject.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Non_Playable_Character
{
    internal abstract class Enemy : Entity
    {
        public bool IsFacingLeft = true;
        public Rectangle Pathway;
    }
}
