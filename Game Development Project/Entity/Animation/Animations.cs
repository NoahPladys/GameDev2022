using GameDevelopmentProject.Interfaces;
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
        public bool IsLoopAnimation { get; }
        public Texture2D Texture { get; }
        public Rectangle BoundingBox { get; }
        public Rectangle ReverseBoundingBox { get; }
        public int Counter { get; set; }
        private List<AnimationFrame> _frames;
        private double _timeSinceLastFrame;

        public Animations(Texture2D texture, bool loopAnimation, Rectangle boundingBox, Rectangle reverseBoundingBox)
        {
            _frames = new List<AnimationFrame>();
            Texture = texture;
            IsLoopAnimation = loopAnimation;
            _timeSinceLastFrame = 0;
            Counter = 0;
            BoundingBox = boundingBox;
            ReverseBoundingBox = reverseBoundingBox;
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
            CurrentFrame = _frames[Counter];

            _timeSinceLastFrame += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 10;

            if (_timeSinceLastFrame >= 1d / fps)
            {
                if (Counter == _frames.Count - 1)
                {
                    if (IsLoopAnimation)
                        Counter = 0;
                }
                else
                    Counter++;
                _timeSinceLastFrame = 0;
            }
        }
    }
}
