using GameDevelopmentProject.Entity.Animation;
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
    public abstract class Entity: IGameObject, IMoving, IAnimatable, ICollidable
    {
        public AnimationManager AnimationManager { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsFalling { get; set; }
        public Vector2 CurrentForce { get; set; }
        public Vector2 JumpingForce { get; set; }
        public Vector2 GravityForce { get; set; }
        public Rectangle BoundingBox { get { return AnimationManager.GetDirectionalBoundingBox(); } }
        public Rectangle RelativeBoundingBox { 
            get 
            { 
                Rectangle boundingBox = AnimationManager.GetDirectionalBoundingBox();
                return new Rectangle(
                    (int)Position.X - boundingBox.X,
                    (int)Position.Y - boundingBox.Y,
                    boundingBox.Width,
                    boundingBox.Height
                    );
            } 
        }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }

        virtual public void Update(GameTime gameTime, Level level)
        {
            AnimationManager.CurrentAnimationState = AnimationManager.DefaultAnimationState;
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
