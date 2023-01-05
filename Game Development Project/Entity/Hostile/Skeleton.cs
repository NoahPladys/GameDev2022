using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Entity.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity
{
    internal class Skeleton : Hostile
    {
        public Skeleton(Vector2 startPosition, Hero hero, ContentManager content) : base(3, 1)
        {
            Position = startPosition;
            Speed = 100f;

            setInputReader(new WalkNoJumpControl(hero, this, 450f));
            AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Skeleton/walk"), 38, 24, new Rectangle(10, 1, 10, 23), new Rectangle(17, 1, 10, 23), true);
            AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Skeleton/idle"), 38, 24, new Rectangle(10, 1, 10, 23), new Rectangle(17, 1, 10, 23), true);
            AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Skeleton/walk"), 38, 24, new Rectangle(10, 1, 10, 23), new Rectangle(17, 1, 10, 23), true);
            AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Skeleton/walk"), 38, 24, new Rectangle(10, 1, 10, 23), new Rectangle(17, 1, 10, 23), true);
            AnimationManager.AddAnimation(AnimationState.hit, content.Load<Texture2D>("Sprites/Hostiles/Skeleton/hit"), 38, 24, new Rectangle(10, 1, 10, 23), new Rectangle(17, 1, 10, 23), false);
            AnimationManager.AddAnimation(AnimationState.dead, content.Load<Texture2D>("Sprites/Hostiles/Skeleton/die"), 38, 24, new Rectangle(10, 1, 10, 23), new Rectangle(17, 1, 10, 23), false);
            AnimationManager.CurrentAnimationState = AnimationState.idle;
            AnimationManager.AnimationScale = 2.5f;
        }
    }
}
