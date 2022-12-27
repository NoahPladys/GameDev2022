using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SamplerState = Microsoft.Xna.Framework.Graphics.SamplerState;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GameDevelopmentProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private ScreenSizeManager _screen;
        private SpriteBatch _spriteBatch;
        private Hero _hero;
        private Level _level;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _screen = ScreenSizeManager.getInstance();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _screen.Initialize(_graphics);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            _hero = new Hero(250f);
            _hero.AnimationManager.AddAnimation(AnimationState.running, Content.Load<Texture2D>("Sprites/Hero/Light/Run"), true, 120, 80, new Rectangle(48,43,18,37), new Rectangle(54,43,18,37));
            _hero.AnimationManager.AddAnimation(AnimationState.idle, Content.Load<Texture2D>("Sprites/Hero/Light/Idle"), true, 120, 80, new Rectangle(47,43,18,37), new Rectangle(55,43,18,37));
            _hero.AnimationManager.AddAnimation(AnimationState.jumping, Content.Load<Texture2D>("Sprites/Hero/Light/Jump"), true, 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37));
            _hero.AnimationManager.AddAnimation(AnimationState.falling, Content.Load<Texture2D>("Sprites/Hero/Light/Fall"), true, 120, 80, new Rectangle(47, 43, 18, 37), new Rectangle(55, 43, 18, 37));
            _hero.AnimationManager.CurrentAnimationState = AnimationState.idle;
            _hero.AnimationManager.AnimationScale = 2.25f;

            _level = LevelFactory.getLevel1(Content, _hero);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _screen.SetCurrentResolution(_graphics);
            _level.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _level.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}