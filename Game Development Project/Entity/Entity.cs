using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Combat;
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
    public abstract class Entity: IGameObject, IMovable, IAnimatable, ICollidable, IJumpable, IHealth, IAttacking
    {
        public AnimationManager AnimationManager { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public float GravityForce { get; set; }
        public float CurrentGravityForce { get; set; }
        public float MaxGravityForce { get; set; }
        public float JumpForce { get; set; }
        public float MaxJumpForce { get; set; }
        public float JumpForceDecrease { get; set; }
        public float CurrentJumpForceDecrease { get; set; }
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

        public CombatManager CombatManager { get; set; }
        public int MaxHealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public bool IsDead { get; set; }

        public int Damage { get; }
        public bool CanAttack { get; set; }
        public bool Attacking { get; set; }
        private Rectangle _attackRange;
        public Rectangle AttackRange {
            get
            {
                if(AnimationManager.SpriteEffect != SpriteEffects.None)
                {
                    return new Rectangle(
                        (int)Math.Round(Position.X + (_attackRange.X * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale * -1) - _attackRange.Width * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale),
                        (int)Math.Round(Position.Y + (_attackRange.Y * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale)),
                        (int)Math.Round(_attackRange.Width * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale),
                        (int)Math.Round(_attackRange.Height * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale));
                }
                else
                {
                    return new Rectangle(
                        (int)Math.Round(Position.X + (_attackRange.X * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale)),
                        (int)Math.Round(Position.Y + (_attackRange.Y * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale)),
                        (int)Math.Round(_attackRange.Width * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale),
                        (int)Math.Round(_attackRange.Height * ScreenSizeManager.GetInstance().GetScale() * AnimationManager.AnimationScale));
                }
            }
        }

        public Entity(int maxHealthPoints, int damage, Rectangle attackRange)
        {
            AnimationManager = new AnimationManager();
            MovementManager = new MovementManager();
            CombatManager = new CombatManager();

            MaxHealthPoints = maxHealthPoints;
            CurrentHealthPoints = MaxHealthPoints;
            Damage = 1;
            CanAttack = true;
            _attackRange = attackRange;
        }

        virtual public void Update(GameTime gameTime, Game1 game)
        {
            MovementManager.Move(this, game.Level, gameTime);
            CombatManager.Update(this, game.Level, gameTime, game);
            AnimationManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0)
        {
            spriteBatch.Draw(
                AnimationManager.CurrentAnimation.Texture, 
                Position - new Vector2(cameraHorizontalOffset + BoundingBox.X, BoundingBox.Y), 
                AnimationManager.CurrentAnimation.CurrentFrame.SourceRectangle, 
                Color.White,
                0,
                new Vector2(0, 0),
                AnimationManager.AnimationScale * ScreenSizeManager.GetInstance().GetScale(),
                AnimationManager.SpriteEffect,
                0);
        }

        private float getBoundingboxScale()
        {
            return ScreenSizeManager.GetInstance().GetScale() * this.AnimationManager.AnimationScale;
        }
    }
}
