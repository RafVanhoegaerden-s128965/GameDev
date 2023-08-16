﻿using GameProject.Animations;
using GameProject.Interface;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Playable
{
    internal class Player : Entity, IControllable, IJumpable
    {
        public float GravityFactor { get; set; }
        public bool JumpPowerUpActive { get; set; } = false;

        // IControllable
        public IInputReader InputReader { get; set; }

        // Hitbox Texture
        public Texture2D TestHitboxTexture { get; set; }
    }
}
