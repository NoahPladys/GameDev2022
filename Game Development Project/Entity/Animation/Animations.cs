using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Animation
{
    public class Animations
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> _frames;
        private int _counter;
        private double _timeSinceLastFrame;

        public Animations()
        {
            this._frames = new List<AnimationFrame>();
            _timeSinceLastFrame = 0;
        }

        public void AddFrames(int textureWidth, int frameWidth, int frameHeight)
        {
            int frameCount = textureWidth / frameWidth;
            for (int i = 0; i < frameCount; i++)
                this.AddFrame(new AnimationFrame(new Rectangle(frameWidth * i, 0, frameWidth, frameHeight)));

        }

        public void AddFrame(AnimationFrame frame)
        {
            _frames.Add(frame);
            CurrentFrame = _frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = _frames[_counter];

            _timeSinceLastFrame += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 10;

            if (_timeSinceLastFrame >= 1d / fps)
            {
                _counter++;
                if (_counter >= _frames.Count)
                    _counter = 0;
                _timeSinceLastFrame = 0;
            }
        }
    }
}
