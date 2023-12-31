﻿using GameProject.Animations;
using GameProject.GameObjects.PowerUps;
using GameProject.InputReader;
using GameProject.Interface;
using GameProject.Managers;
using GameProject.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects.Playable
{
    internal class MainCharacter : Player
    {
        private Game1 _game;
        public MainCharacter(Game1 game, ContentManager content)
        {
            _game = game;

            GravityFactor = 5;

            #region Textures
            IdleTexture = content.Load<Texture2D>("Sprites\\MainCharacter\\Idle-Sheet");
            RunningTexture = content.Load<Texture2D>("Sprites\\MainCharacter\\Run-Sheet");
            AttackTexture = content.Load<Texture2D>("Sprites\\MainCharacter\\Attack-01-Sheet");
            #endregion

            #region Animations
            IdleAnimation = new Animation();
            IdleAnimation.GetFramesFromTextureProperties(IdleTexture.Width, IdleTexture.Height, 4, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            RunningAnimation = new Animation();
            RunningAnimation.GetFramesFromTextureProperties(RunningTexture.Width, RunningTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            AttackAnimation = new Animation();
            AttackAnimation.GetFramesFromTextureProperties(AttackTexture.Width, AttackTexture.Height, 8, 1); // Widht, Height, NumberOfSpritesWidth, NumberOfSpritesHeight

            CurrentMovementState = CurrentMovementState.Idle;
            #endregion

            #region Hitbox

            #endregion

            #region Combat
            HP = 3;
            MaxHP = 3;
            Damage = 1;
            #endregion

            #region Moving
            Position = new Vector2(0, 0);
            Speed = new Vector2(7, 10);
            Acceleration = new Vector2(0f, 0f);

            StartY = Position.Y;

            // Jump State
            IsFalling = true;
            IsJumping = false;
            #endregion
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // DrawLevel Animations
            AnimationManager.DrawAnimation(spriteBatch, this);
        }

        public void Update(GameTime gameTime)
        {
            // Apply gravity
            MovementManager.Gravity(this);

            // Read Input
            InputReader.ReadInput(_game, this);

            // Combat
            if (HealthPowerUpActive && !HealthEffectApplied)
            {
                MaxHP += HealthEffect;
                HP = MaxHP;
                HealthEffectApplied = true;
            }

            if (AttackPowerUpActive)
            {
                Damage = AttackEffect;
            }

            // Movement
            MovementManager.Move(this);
            MovementManager.Jump(this);

            // UpdateLevel Animations + Hitbox
            AnimationManager.UpdateAnimation(gameTime, this);
        }
    }
}
