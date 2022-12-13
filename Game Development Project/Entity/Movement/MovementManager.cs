using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Movement
{
    public class MovementManager
    {
        internal void Move(IMoving movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var distance = direction * movable.Speed;
            var nextPosition = movable.Position + distance;

            if(nextPosition != movable.Position)
            {
                if (nextPosition.X < 800 - 120 && nextPosition.X > 0)
                {
                    if (movable is IAnimatable)
                    {
                        ((IAnimatable)movable).AnimationManager.CurrentAnimationState = AnimationState.running;
                        if (nextPosition.X > movable.Position.X)
                            ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.None;
                        else
                            ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.FlipHorizontally;

                    }
                    movable.Position = nextPosition;
                }
            }
        }

    }
}
