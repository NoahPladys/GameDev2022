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
    internal class Slime : Hostile
    {
        public Slime(Vector2 startPosition, Hero hero, ContentManager content) : base()
        {
            Position = startPosition;
            Speed = 125f;
            GravityForce = 8;
            MaxGravityForce = 500;
            JumpForce = 300;
            JumpForceDecrease = 8;
            MaxJumpForce = 220;

            this.setInputReader(new JumpMoveWithDelayControl(hero, this, 750f));
            this.AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Slime/Jump"), true, 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11));
            this.AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Slime/Jump"), true, 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11));
            this.AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Slime/Jump"), true, 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11));
            this.AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Slime/Jump"), true, 20, 16, new Rectangle(3, 5, 14, 11), new Rectangle(3, 5, 14, 11));
            this.AnimationManager.CurrentAnimationState = AnimationState.idle;
            this.AnimationManager.AnimationScale = 2.5f;
        }
    }
}
