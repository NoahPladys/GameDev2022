using GameDevelopmentProject.Entity.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Animation
{
    public class AnimationManager
    {
        public IDictionary<AnimationState, Animations> Animations { get; }

        private AnimationState currentAnimationState;
        public AnimationState CurrentAnimationState { 
            get { return currentAnimationState; }
            set
            {
                currentAnimationState = value;
                Animations previousAnimation = CurrentAnimation;
                CurrentAnimation = Animations[currentAnimationState];

                if (!(CurrentAnimation.IsLoopAnimation) && previousAnimation != CurrentAnimation)
                    CurrentAnimation.Counter = 0;
            }
        }
        public Animations CurrentAnimation;
        public AnimationState DefaultAnimationState;
        public SpriteEffects SpriteEffect;  
        public float AnimationScale = 1;

        public AnimationManager(AnimationState defaultAnimationState = AnimationState.idle)
        {
            DefaultAnimationState = defaultAnimationState;
            Animations = new Dictionary<AnimationState, Animations>();
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentAnimation.Update(gameTime);
        }

        public void AddAnimation(AnimationState animationState, Texture2D texture, int frameWidth, int frameHeight, Rectangle boundingBox, Rectangle reverseBoundingBox, bool loopAnimation, bool stayonlastframe = false)
        {
            var animation = new Animations(texture, boundingBox, reverseBoundingBox, loopAnimation);
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

        public void SetAnimation(Vector2 direction)
        {
            if (CurrentAnimationState != AnimationState.dead && (CurrentAnimation.IsLoopAnimation || (!CurrentAnimation.IsLoopAnimation && CurrentAnimation.Counter == CurrentAnimation.Frames.Count-1)))
            {
                if (direction != new Vector2(0))
                {
                    if (direction.X > 0)
                        SpriteEffect = SpriteEffects.None;
                    else if (direction.X < 0)
                        SpriteEffect = SpriteEffects.FlipHorizontally;

                    if (direction.Y != 0)
                    {
                        if (direction.Y < 0)
                            CurrentAnimationState = AnimationState.jumping;
                        else if (direction.Y > 0)
                            CurrentAnimationState = AnimationState.falling;
                        return;
                    }

                    if (direction.X != 0)
                    {
                        if (currentAnimationState != AnimationState.running)
                        {
                            CurrentAnimationState = AnimationState.running;
                        }
                        return;
                    }
                }
                else
                {
                    CurrentAnimationState = AnimationState.idle;
                }
            }
        }
    }
}
