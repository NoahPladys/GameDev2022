using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity
{
    internal class YellowSlime : Slime
    {
        public YellowSlime(Vector2 startPosition, Hero hero, ContentManager content) : base(startPosition, hero, content, 3)
        {
            AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Slime/Yellow/Jump"), 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11), true);
            AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Slime/Yellow/Jump"), 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11), true);
            AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Slime/Yellow/Jump"), 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11), true);
            AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Slime/Yellow/Jump"), 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11), true);
            AnimationManager.AddAnimation(AnimationState.hit, content.Load<Texture2D>("Sprites/Hostiles/Slime/Yellow/Hit"), 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11), false);
            AnimationManager.AddAnimation(AnimationState.dead, content.Load<Texture2D>("Sprites/Hostiles/Slime/Yellow/Die"), 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11), false);
            AnimationManager.CurrentAnimationState = AnimationState.idle;
            AnimationManager.AnimationScale = 2.5f;
        }
    }
}
