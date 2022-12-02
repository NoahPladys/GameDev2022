using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Movement
{
    public class MovementManager
    {
        internal void Move(IPlayerMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var distance = direction * movable.Speed;
            var nextPosition = movable.Position + distance;
            if (nextPosition.X < (800 - 120) && nextPosition.X > 0)
            {
                movable.Position = nextPosition;
            }
        }

    }
}
