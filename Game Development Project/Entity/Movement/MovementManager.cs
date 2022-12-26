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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tile = GameDevelopmentProject.Levels.Tile;

namespace GameDevelopmentProject.Entity.Movement
{
    public class MovementManager
    {
        internal void Move(IMovable movable, Level level, GameTime gameTime)
        {
            Vector2 direction = movable.InputReader.ReadInput();
            float scale = (float)gameTime.ElapsedGameTime.TotalSeconds * ScreenSizeManager.getInstance().GetScale();
            Vector2 distance = new Vector2(direction.X * (movable.Speed * scale), 0);
            Vector2 previousPosition;
            Vector2 startPosition = movable.Position;
            Vector2 nextPosition = movable.Position + distance;

            IAnimatable animatable = null;
            if (movable is IAnimatable)
                animatable = (IAnimatable)movable;

            ICollidable collidable = null;
            if (movable is ICollidable)
                collidable = (ICollidable)movable;

            IJumpable jumpable = null;
            if (movable is IJumpable)
                jumpable = (IJumpable)movable;

            //JUMP FORCE
            if (jumpable != null)
            {
                if (direction.Y != 0 && jumpable.CanJump)
                {
                    distance.Y += direction.Y * ((jumpable.JumpForce - jumpable.CurrentJumpForceDecrease) * scale);
                    if (jumpable.CurrentJumpForceDecrease >= jumpable.MaxJumpForce)
                    {
                        jumpable.CurrentJumpForceDecrease = jumpable.MaxJumpForce;
                        jumpable.CanJump = false;
                    }
                    jumpable.CurrentJumpForceDecrease += jumpable.JumpForceDecrease;
                }
                else
                {
                    jumpable.CurrentJumpForceDecrease = 0;
                    jumpable.CanJump = false;
                }

                nextPosition = movable.Position + distance;

                //GRAVITY FORCE
                if (jumpable.GravityForce != 0 && distance.Y == 0)
                {
                    jumpable.CurrentGravityForce += jumpable.GravityForce;
                    if (jumpable.CurrentGravityForce > jumpable.MaxGravityForce)
                        jumpable.CurrentGravityForce = jumpable.MaxGravityForce;

                    nextPosition += new Vector2(0, jumpable.CurrentGravityForce * scale);
                }
            }

            if (nextPosition != movable.Position)
            {
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
                            if (collision(collidable, level))
                            {
                                movable.Position = previousPosition;
                            }
                        }
                    }

                    //CHECK FOR COLLISION ON Y MOVE
                    if (nextPosition.Y != movable.Position.Y)
                    {
                        previousPosition = movable.Position;
                        movable.Position = new Vector2(movable.Position.X, nextPosition.Y);
                        if (collision(collidable, level))
                        {
                            if(movable.Position.Y > previousPosition.Y)
                            {
                                movable.Position = previousPosition;
                                do
                                {
                                    previousPosition = movable.Position;
                                    movable.Position += new Vector2(0, 2f);
                                } while (!collision(collidable, level));
                            }
                            movable.Position = previousPosition;

                            if (jumpable != null)
                            {
                                jumpable.CurrentGravityForce = jumpable.GravityForce;
                                if (direction.Y == 0) jumpable.CanJump = true;
                            }
                        }
                    }
                }
                else
                {
                    movable.Position = nextPosition; //MOVE TO NEXT POSITION
                }

                //SET ANIMATION IF ANIMATABLE
                if (animatable != null)
                {
                    Vector2 animationvector = movable.Position - startPosition;
                    animatable.AnimationManager.SetAnimation(animationvector);
                }
            }
        }

        private bool collision(ICollidable collidable, Level level)
        {
            foreach (Tile currentTile in level.Tileset)
            {
                if (currentTile != null && collidable.RelativeBoundingBox.Intersects(currentTile.RelativeBoundingBox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
