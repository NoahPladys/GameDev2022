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
    internal class Snake : Hostile
    {
        public Snake(Vector2 startPosition, Hero hero, ContentManager content) : base(2, 1)
        {
            Position = startPosition;
            Speed = 100f;

            this.setInputReader(new WalkNoJumpControl(hero, this, 750f));
            this.AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16), true);
            this.AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16), true);
            this.AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16), true);
            this.AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16), true);
            this.AnimationManager.AddAnimation(AnimationState.hit, content.Load<Texture2D>("Sprites/Hostiles/Snake/hit"), 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16), false);
            this.AnimationManager.AddAnimation(AnimationState.dead, content.Load<Texture2D>("Sprites/Hostiles/Snake/die"), 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16), false);
            this.AnimationManager.CurrentAnimationState = AnimationState.idle;
            this.AnimationManager.AnimationScale = 2.5f;
        }
    }
}
