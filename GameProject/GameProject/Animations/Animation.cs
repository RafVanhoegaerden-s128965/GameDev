﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameProject.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> _frames;

        private int _counter;

        private double _secondCounter = 0;

        public Animation()
        {
            _frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            _frames.Add(frame);
            CurrentFrame = _frames[0];
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    AddFrame(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }

        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = _frames[_counter];

            _secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            // FPS
            int fps = 5;

            if(_secondCounter >= 1d/fps)
            {
                _counter++;
                _secondCounter = 0;
            }

            if(_counter >= _frames.Count)
            {
                _counter = 0;
            }
        }
    }
}
