using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.VisualBasic;
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
            Vector2 direction = movable.InputReader.ReadInput();
            float scale = (float)gameTime.ElapsedGameTime.TotalSeconds * ScreenSizeManager.getInstance().GetScale();
            Vector2 distance = direction * (movable.Speed * scale);
            Vector2 nextPosition = movable.Position + distance;
            Vector2 previousPosition;

            IAnimatable animatable = null;
            if (movable is IAnimatable)
                animatable = (IAnimatable)movable;

            ICollidable collidable = null;
            if (movable is ICollidable)
                collidable = (ICollidable)movable;

            //GRAVITY FORCE
            if (movable.GravityForce != 0)
            {
                movable.CurrentGravityForce += movable.GravityForce;
                if (movable.CurrentGravityForce > movable.MaxGravityForce)
                    movable.CurrentGravityForce = movable.MaxGravityForce;

                nextPosition += new Vector2(0, movable.CurrentGravityForce * scale);
            }

            if (nextPosition != movable.Position)
            {
                //CHANGE ANIMATION IF MOVABLE IS ANIMATIBLE
                if (animatable != null)
                {
                    if(nextPosition.X != movable.Position.X)
                    {
                        ((IAnimatable)movable).AnimationManager.CurrentAnimationState = AnimationState.running;
                        if (nextPosition.X > movable.Position.X)
                            ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.None;
                        else if (nextPosition.X < movable.Position.X)
                            ((IAnimatable)movable).AnimationManager.SpriteEffect = SpriteEffects.FlipHorizontally;
                    } 
                }

                //CHECK IF MOVABLE IS COLLIDABLE
                if (collidable != null)
                {
                    //CHECK FOR COLLISION ON X MOVE
                    if (nextPosition.X != movable.Position.X)
                    {
                        previousPosition = movable.Position;

                        //CHECK IF MOVABLE IS STILL IN BOUNDS
                        movable.Position = nextPosition;
                        bool outOfBounds = false;
                        float boundLeft = 0;
                        float boundRight = level.Tileset.GetLength(1) * level.getTileScale() * 16 - collidable.BoundingBox.Width;
                        if (movable.Position.X < boundLeft || movable.Position.X > boundRight)
                            outOfBounds = true;
                        movable.Position = previousPosition;

                        if (!outOfBounds)
                        {
                            previousPosition = movable.Position;
                            movable.Position = new Vector2(nextPosition.X, previousPosition.Y);
                            foreach (Tile currentTile in level.Tileset)
                            {
                                if (currentTile != null && collidable.RelativeBoundingBox.Intersects(currentTile.RelativeBoundingBox))
                                {
                                    movable.Position = previousPosition;
                                    break;
                                }
                            }
                        }
                    }

                    //CHECK FOR COLLISION ON Y MOVE
                    if (nextPosition.Y != movable.Position.Y)
                    {
                        previousPosition = movable.Position;
                        movable.Position = new Vector2(movable.Position.X, nextPosition.Y);
                        foreach (Tile currentTile in level.Tileset)
                        {
                            if (currentTile != null && collidable.RelativeBoundingBox.Intersects(currentTile.RelativeBoundingBox))
                            {
                                movable.Position = previousPosition;
                                movable.CurrentGravityForce = 0;
                                break;
                            }
                        }
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
