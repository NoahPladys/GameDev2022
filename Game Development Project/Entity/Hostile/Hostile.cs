using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity
{
    public class Hostile : Entity
    {
        public Hostile(int maxHealthPoints, int damage, Rectangle attackRange = new Rectangle()) : base(maxHealthPoints, damage, attackRange)
        {
            GravityForce = 5;
            MaxGravityForce = 500;
            JumpForce = 400;
            JumpForceDecrease = 5;
            MaxJumpForce = 320;
        }

        override public void Update(GameTime gameTime, Game1 game = null)
        {
            base.Update(gameTime, game);
        }

        public void setInputReader(IInputReader inputReader)
        {
            InputReader = inputReader;
        }
    }
}
