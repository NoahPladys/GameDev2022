using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Movement;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity
{
    internal class Slime : Hostile
    {
        public Slime(Vector2 startPosition) : base()
        {
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
