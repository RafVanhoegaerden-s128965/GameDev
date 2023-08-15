using GameProject.Animations;
using GameProject.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface IAnimatable
    {
        public AnimationManager AnimationManager { get; set; }
        public Texture2D IdleTexture { get; set; }
        public Animation IdleAnimation { get; set; }
        public Texture2D RunningTexture { get; set; }
        public Animation RunningAnimation { get; set; }
    }
}
