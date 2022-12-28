using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Controls
{
    internal class WalkNoJumpControl : IInputReader
    {
        public bool IsDestinationInput => false;

        private Hero _hero;
        private Hostile _hostile;
        private float _range;


        public WalkNoJumpControl(Hero hero, Hostile hostile, float range)
        {
            _hero = hero;
            _hostile = hostile;
            _range = range * ScreenSizeManager.getInstance().GetScale();
        }

        public Vector2 ReadInput()
        {
            Vector2 direction = Vector2.Zero;

            if (Math.Abs(_hero.Position.X - _hostile.Position.X) <= _range)
            {
                direction.X += getHeroDirection();
            }

            return direction;
        }

        private int getHeroDirection()
        {
            if (_hero.Position.X + _hero.BoundingBox.Width / 2 < _hostile.Position.X - 5 + _hostile.BoundingBox.Width / 2)
            {
                return -1;
            }
            if (_hero.Position.X + _hero.BoundingBox.Width / 2 > _hostile.Position.X + 5 + _hostile.BoundingBox.Width / 2)
            {
                return +1;
            }
            return 0;
        }
    }
}
