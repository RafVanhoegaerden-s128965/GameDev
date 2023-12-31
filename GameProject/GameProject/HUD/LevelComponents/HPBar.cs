﻿using GameProject.GameObjects.Playable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GameProject.HUD.Menu.LevelComponents
{
    internal class HPBar : HudComponent
    {
        private Texture2D _texture;

        private SpriteFont _font;

        private MainCharacter _mainCharacter;

        #region HpValues
        private int _hp;
        private int _maxHP;
        #endregion

        #region HpDraw
        private Color _hpBarColor = Color.Red;
        private int _hpBarWidth = 400;
        private int _hpBarHeight = 35;
        #endregion

        public HPBar(MainCharacter mainCharacter, Texture2D backgroundTexture, ContentManager content)
        {
            _mainCharacter = mainCharacter;

            _hp = mainCharacter.HP;
            _maxHP = mainCharacter.MaxHP;
            _texture = backgroundTexture;

            _font = content.Load<SpriteFont>("Fonts\\Font");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Background Bar
            Rectangle backgroundRect = new Rectangle(780, 995, _hpBarWidth + 10, _hpBarHeight + 10);
            spriteBatch.Draw(_texture, backgroundRect, Color.Black);

            // Foreground Bar
            float healthRatio = (float)_hp / _maxHP;
            Debug.WriteLine($"{_hp}/ {_maxHP}");
            int filledWidth = (int)(_hpBarWidth * healthRatio);
            Rectangle filledRect = new Rectangle(785, 1000, filledWidth, _hpBarHeight);
            spriteBatch.Draw(_texture, filledRect, _hpBarColor);

            // Text Label
            string labelText = $"HP Bar: {_mainCharacter.HP} / {_mainCharacter.MaxHP}";
            Vector2 labelPosition = new Vector2(780, 960);
            Color labelColor = Color.Black;
            if (_mainCharacter.HealthPowerUpActive) { labelColor = Color.LightGoldenrodYellow; } // Change if HealthPowerUp is Active
            spriteBatch.DrawString(_font, labelText, labelPosition, labelColor);
        }

        public override void Update(GameTime gameTime)
        {
            if (_hp != _mainCharacter.HP)
            {
                _hp = _mainCharacter.HP;
            }

            if (_maxHP != _mainCharacter.MaxHP)
            {
                _maxHP = _mainCharacter.MaxHP;
            }

            if (_hp < 0)
            {
                _hp = 0;
            }
        }
    }
}
