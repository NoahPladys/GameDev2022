using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tile = GameDevelopmentProject.Levels.Tile;

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
                //CHANGE ANIMATION OF MOVABLE IS ANIMATIBLE
                if (movable is IAnimatable)
                {
                    ((IAnimatable)movable).AnimationManager.CurrentAnimationState = AnimationState.running;
                    if (nextPosition.X > movable.Position.X)
                        ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.None;
                    else
                        ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.FlipHorizontally;

                }

                Vector2 previousPosition = movable.Position;
                movable.Position = nextPosition; //MOVE TO NEXT POSITION

                //CHECK IF MOVABLE IS COLLIDABLE
                if (movable is ICollidable)
                {
                    ICollidable collidable = (ICollidable)movable;

                    bool intersection = false;
                    //KEEP MOVABLE IN LEVEL BOUNDS
                    float boundLeft = 0;
                    float boundRight = level.Tileset.GetLength(1) * level.getTileScale() * 16 - collidable.BoundingBox.Width;
                    if (movable.Position.X < boundLeft)
                        intersection = true;
                    else if (movable.Position.X > boundRight)
                        intersection = true;

                    //CHECK FOR TILE COLLISION
                    for (int y=0; y < level.Tileset.GetLength(0); y++)
                    {
                        for(int x=0; x<level.Tileset.GetLength(1); x++)
                        {
                            Tile currentTile = level.Tileset[y, x];
                            if(currentTile != null)
                            {
                                if (collidable.RelativeBoundingBox.Intersects(currentTile.RelativeBoundingBox))
                                {
                                    intersection = true;
                                }
                            }
                        }
                    }
                    if (intersection)
                    {
                        movable.Position = previousPosition;
                    }
                }
                else
                {
                    movable.Position = nextPosition; //MOVE TO NEXT POSITION
                }
            }
        }
    }
}
