using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        //public bool loopAnimation { get; }
        public Texture2D Texture { get; }
        private List<AnimationFrame> _frames;
        private int _counter;
        private double _timeSinceLastFrame;

        public Animations(Texture2D texture)
        {
            _frames = new List<AnimationFrame>();
            Texture = texture;
            _timeSinceLastFrame = 0;
        }

        public void AddFrames(int frameWidth, int frameHeight)
        {
            int frameCount = Texture.Width / frameWidth;
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
