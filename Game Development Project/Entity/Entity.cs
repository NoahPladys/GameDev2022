﻿using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity
{
    public abstract class Entity: IGameObject, IMovable, IAnimatable, ICollidable, IJumpable
    {
        public AnimationManager AnimationManager { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public float GravityForce { get; set; }
        public float CurrentGravityForce { get; set; }
        public float MaxGravityForce { get; set; }
        public float JumpForce { get; set; }
        public float MaxJumpForce { get; set; }
        public float CurrentJumpForceDecrease { get; set; }
        public float JumpForceDecrease { get; set; }
        public bool CanJump { get; set; } = true;
        public Rectangle BoundingBox { get { return AnimationManager.GetDirectionalBoundingBox(); } }
        public Rectangle RelativeBoundingBox { 
            get 
            { 
                Rectangle boundingBox = BoundingBox;
                return new Rectangle(
                    (int)Math.Round(Position.X),
                    (int)Math.Round(Position.Y),
                    boundingBox.Width,
                    boundingBox.Height);
            } 
        }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }

        virtual public void Update(GameTime gameTime, Level level)
        {
            MovementManager.Move(this, level, gameTime);
            AnimationManager.CurrentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0)
        {
            spriteBatch.Draw(
                AnimationManager.CurrentAnimation.Texture, 
                Position - new Vector2(cameraHorizontalOffset + BoundingBox.X, 0 + BoundingBox.Y), 
                AnimationManager.CurrentAnimation.CurrentFrame.SourceRectangle, 
                Color.White,
                0,
                new Vector2(0, 0),
                AnimationManager.AnimationScale * ScreenSizeManager.getInstance().GetScale(),
                AnimationManager.SpriteEffect,
                0);
        }

        private float getBoundingboxScale()
        {
            return ScreenSizeManager.getInstance().GetScale() * this.AnimationManager.AnimationScale;
        }
    }
}
