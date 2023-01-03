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
    abstract class Slime : Hostile
    {
        public Slime(Vector2 startPosition, Hero hero, ContentManager content, int maxHealthPoints) : base(maxHealthPoints, 1)
        {
            setInputReader(new JumpMoveWithDelayControl(hero, this, 750f));
            Position = startPosition;
            Speed = 125f;
            GravityForce = 8;
            MaxGravityForce = 500;
            JumpForce = 300;
            JumpForceDecrease = 8;
            MaxJumpForce = 220;
        }
    }
}
