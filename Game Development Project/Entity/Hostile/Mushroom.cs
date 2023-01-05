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
        public Mushroom(Vector2 startPosition, Hero hero, ContentManager content) : base(1, 1)
        {
            Position = startPosition;
            Speed = 100f;

            this.setInputReader(new WalkNoJumpControl(hero, this, 450f));
            this.AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/running"), 24, 16, new Rectangle(4, 4, 12, 12), new Rectangle(8, 4, 12, 12), true);
            this.AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/idle"), 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12), true);
            this.AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/idle"), 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12), true);
            this.AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/idle"), 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12), true);
            this.AnimationManager.AddAnimation(AnimationState.hit, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/hit"), 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12), false);
            this.AnimationManager.AddAnimation(AnimationState.dead, content.Load<Texture2D>("Sprites/Hostiles/Mushroom/die"), 24, 16, new Rectangle(5, 4, 12, 12), new Rectangle(6, 4, 12, 12), false);
            this.AnimationManager.CurrentAnimationState = AnimationState.idle;
            this.AnimationManager.AnimationScale = 2.5f;
        }
    }
}
