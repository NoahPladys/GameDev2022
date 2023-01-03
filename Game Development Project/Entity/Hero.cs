using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Entity.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SharpDX.MediaFoundation;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework.Content;
using GameDevelopmentProject.UserInterface;

namespace GameDevelopmentProject.Entity
{
    public class Hero : Entity
    {
        public Hero(float speed) : base(3, 1, new Rectangle(18, 0, 37, 37))
        {
            InputReader = new KeyboardReader();
            Position = new Vector2(0, 0);
            Speed = speed;

            GravityForce = 25;
            MaxGravityForce = 800;
            JumpForce = 800;
            MaxJumpForce = 650;
            JumpForceDecrease = 25;
        }

        override public void Update(GameTime gameTime, Game1 game = null)
        {
            base.Update(gameTime, game);
        }

        public void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0)
        {
            base.Draw(spriteBatch, cameraHorizontalOffset);
        }

        public static Hero getNewHero(ContentManager content)
        {
            Hero hero;
            hero = new Hero(250f);
            hero.AnimationManager.AddAnimation(AnimationState.running, content.Load<Texture2D>("Sprites/Hero/Light/Run"), 120, 80, new Rectangle(48, 43, 18, 37), new Rectangle(54, 43, 18, 37), true);
            hero.AnimationManager.AddAnimation(AnimationState.idle, content.Load<Texture2D>("Sprites/Hero/Light/Idle"), 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37), true);
            hero.AnimationManager.AddAnimation(AnimationState.jumping, content.Load<Texture2D>("Sprites/Hero/Light/Jump"), 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37), true);
            hero.AnimationManager.AddAnimation(AnimationState.falling, content.Load<Texture2D>("Sprites/Hero/Light/Fall"), 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37), true);
            hero.AnimationManager.AddAnimation(AnimationState.attacking, content.Load<Texture2D>("Sprites/Hero/Light/Attack"), 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37), true);
            hero.AnimationManager.AddAnimation(AnimationState.hit, content.Load<Texture2D>("Sprites/Hero/Light/Hit"), 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37), false);
            hero.AnimationManager.AddAnimation(AnimationState.dead, content.Load<Texture2D>("Sprites/Hero/Light/Death"), 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37), false);
            hero.AnimationManager.CurrentAnimationState = AnimationState.idle;
            hero.AnimationManager.AnimationScale = 2.25f;
            return hero;
        }
    }
}
