using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Collision;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }

        virtual public void Update(GameTime gameTime)
        {
            AnimationManager.CurrentAnimationState = AnimationManager.DefaultAnimationState;
            MovementManager.Move(this);
            AnimationManager.CurrentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                AnimationManager.CurrentAnimation.Texture, 
                Position, 
                AnimationManager.CurrentAnimation.CurrentFrame.SourceRectangle, 
                Color.White,
                0,
                new Vector2(1,1),
                AnimationManager.AnimationScale,
                AnimationManager.SpriteEffect,
                0);
        }
    }
}
