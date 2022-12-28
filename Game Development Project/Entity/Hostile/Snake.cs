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
        public Snake(Vector2 startPosition, Hero hero, ContentManager content) : base()
        {
            Position = startPosition;
            Speed = 100f;
            GravityForce = 8;
            MaxGravityForce = 500;
            JumpForce = 300;
            JumpForceDecrease = 8;
            MaxJumpForce = 220;

            this.setInputReader(new WalkNoJumpControl(hero, this, 750f));
            this.AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), true, 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16));
            this.AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), true, 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16));
            this.AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), true, 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16));
            this.AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Snake/idle"), true, 30, 19, new Rectangle(0, 3, 19, 16), new Rectangle(11, 3, 19, 16));
            this.AnimationManager.CurrentAnimationState = AnimationState.idle;
            this.AnimationManager.AnimationScale = 2.5f;
        }
    }
}
