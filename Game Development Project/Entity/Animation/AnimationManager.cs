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

        public void AddAnimation(AnimationState animationState, Texture2D texture, int frameWidth, int frameHeight)
        {
            var animation = new Animations(texture);
            animation.AddFrames(frameWidth, frameHeight);
            Animations.Add(animationState, animation);
        }
    }
}
