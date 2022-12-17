using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Collision;
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
    public abstract class Entity: IGameObject, IMoving, IAnimatable
    {
        public AnimationManager AnimationManager { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsFalling { get; set; }
        public Vector2 CurrentForce { get; set; }
        public Vector2 JumpingForce { get; set; }
        public Vector2 GravityForce { get; set; }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public Rectangle BoundingBox { get; set; }

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
                Position - new Vector2(cameraHorizontalOffset + (this.BoundingBox.X * getBoundingboxScale()), this.BoundingBox.Y * getBoundingboxScale()), 
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
