using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Controls
{
    internal class JumpMoveWithDelayControl : IInputReader
    {
        public bool IsDestinationInput => false;

        private Hero _hero;
        private Hostile _hostile;
        private float _range;

        private double _timeBetweenJumps;
        private double _timeSinceLastLanding;
        private int _direction;
        private bool _jump;

        public JumpMoveWithDelayControl(Hero hero, Hostile hostile, float range)
        {
            _hero = hero;
            _hostile = hostile;
            _range = range * ScreenSizeManager.getInstance().GetScale();
            _timeBetweenJumps = 1d;
            _jump = false;
        }

        public Vector2 ReadInput()
        {
            Vector2 direction = Vector2.Zero;

            if (Math.Abs(_hero.Position.X - _hostile.Position.X) <= _range)
            {
                if (!_hostile.CanJump || _jump)
                {
                    direction.X += _direction;
                }

                if (_hostile.CurrentGravityForce == _hostile.GravityForce && _hostile.CanJump)
                {
                    _timeSinceLastLanding += 0.02d;
                    if (_timeSinceLastLanding >= _timeBetweenJumps)
                    {
                        _direction = getHeroDirection();
                        _jump = true;
                        _timeSinceLastLanding = 0;
                    }
                }
                else
                {
                    _timeSinceLastLanding = 0;
                    _jump = false;
                }

                if (_jump)
                {
                    direction.Y -= 1;
                }
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
