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
    internal class Mushroom : Hostile
    {
        public Mushroom(Vector2 startPosition, Hero hero, ContentManager content) : base()
        {
            Position = startPosition;
            Speed = 100f;
            GravityForce = 8;
            MaxGravityForce = 500;
            JumpForce = 300;
            JumpForceDecrease = 8;
            MaxJumpForce = 220;

            this.setInputReader(new WalkNoJumpControl(hero, this, 450f));
            this.AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/running"), true, 24, 16, new Rectangle(4, 4, 12, 12), new Rectangle(8, 4, 12, 12));
            this.AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/idle"), true, 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12));
            this.AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/idle"), true, 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12));
            this.AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/idle"), true, 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12));
            this.AnimationManager.CurrentAnimationState = AnimationState.idle;
            this.AnimationManager.AnimationScale = 2.5f;
        }
    }
}
