using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Collision;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Movement
{
    public class MovementManager
    {
        internal void Move(IMoving movable, Level level, GameTime gameTime)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var distance = direction * (movable.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            var nextPosition = movable.Position + distance * ScreenSizeManager.getInstance().GetScale();

            if(nextPosition != movable.Position)
            {
                if (movable is IAnimatable)
                {
                    ((IAnimatable)movable).AnimationManager.CurrentAnimationState = AnimationState.running;
                    if (nextPosition.X > movable.Position.X)
                        ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.None;
                    else
                        ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.FlipHorizontally;

                }

                if(movable.IsFalling) // CALCULATE GRAVITY
                {
                    
                }

                if (true) // LEVEL BOUNDS
                {
                    movable.Position = nextPosition;
                }

                //KEEP HERO IN LEVEL BOUNDS
                float scale = 1;
                if (movable is IAnimatable)
                    scale *= ((IAnimatable)movable).AnimationManager.AnimationScale;
                float boundLeft = 0;
                float boundRight = level.Tileset.GetLength(1) * level.getTileScale() * 16 - (movable.BoundingBox.Width * scale);
                if (movable.Position.X < boundLeft)
                    movable.Position = new Vector2(boundLeft, movable.Position.Y);
                else if (movable.Position.X > boundRight)
                    movable.Position = new Vector2(boundRight, movable.Position.Y);
            }
        }
    }
}
