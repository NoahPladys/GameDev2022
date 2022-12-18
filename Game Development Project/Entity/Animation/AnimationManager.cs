using GameDevelopmentProject.Entity.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Animation
{
    public class AnimationManager
    {
        public IDictionary<AnimationState, Animations> Animations { get; }

        AnimationState currentAnimationState;
        public AnimationState CurrentAnimationState { 
            get { return currentAnimationState; }
            set
            {
                currentAnimationState = value;
                CurrentAnimation = Animations[currentAnimationState];
            }
        }
        public Animations CurrentAnimation;
        public AnimationState DefaultAnimationState;
        public SpriteEffects SpriteEffect;  
        public float AnimationScale;

        public AnimationManager(AnimationState defaultAnimationState = AnimationState.idle)
        {
            DefaultAnimationState = defaultAnimationState;
            Animations = new Dictionary<AnimationState, Animations>();
        }

        public void AddAnimation(AnimationState animationState, Texture2D texture, int frameWidth, int frameHeight, Rectangle boundingBox, Rectangle reverseBoundingBox)
        {
            var animation = new Animations(texture, boundingBox, reverseBoundingBox);
            animation.AddFrames(frameWidth, frameHeight);
            Animations.Add(animationState, animation);
        }

        public Rectangle GetDirectionalBoundingBox()
        {
            Rectangle boundingBox;
            if (this.SpriteEffect == SpriteEffects.None)
                boundingBox = CurrentAnimation.BoundingBox;
            else
                boundingBox = CurrentAnimation.ReverseBoundingBox;

            return new Rectangle(
                (int)Math.Round(boundingBox.X * AnimationScale * ScreenSizeManager.getInstance().GetScale()),
                (int)Math.Round(boundingBox.Y * AnimationScale * ScreenSizeManager.getInstance().GetScale()),
                (int)Math.Round(boundingBox.Width * AnimationScale * ScreenSizeManager.getInstance().GetScale()),
                (int)Math.Round(boundingBox.Height * AnimationScale * ScreenSizeManager.getInstance().GetScale()));
        }
    }
}
