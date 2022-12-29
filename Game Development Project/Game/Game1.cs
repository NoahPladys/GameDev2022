using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Levels;
using GameDevelopmentProject.UserInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Drawing;
using System.Linq;
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
        private Button[] buttons;
        public GameState GameState;

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
            _screen.SetCurrentResolution(_graphics);

            buttons = new Button[]
            {
                new Button(
                    "Resume",
                    Content.Load<Texture2D>("Sprites/Interface/Buttons/resume"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (Content.Load<Texture2D>("Sprites/Interface/Buttons/resume").Width / 2),
                    200*(int)ScreenSizeManager.getInstance().GetScale(),
                    this),
                new Button(
                    "Menu",
                    Content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (Content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    450*(int)ScreenSizeManager.getInstance().GetScale(),
                    this),
                new Button(
                    "Quit",
                    Content.Load<Texture2D>("Sprites/Interface/Buttons/quit"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (Content.Load<Texture2D>("Sprites/Interface/Buttons/quit").Width / 2),
                    700*(int)ScreenSizeManager.getInstance().GetScale(),
                    this)
            };
        }

        private bool previousEscapeButtonPressed = false;
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && previousEscapeButtonPressed == false)
            {
                if (GameState == GameState.Playing)
                    GameState = GameState.Paused;
                else
                    GameState = GameState.Playing;
            }
            previousEscapeButtonPressed = Keyboard.GetState().IsKeyDown(Keys.Escape);


            if (GameState == GameState.Playing)
            {
                _level.Update(gameTime);
                _screen.SetCurrentResolution(_graphics);
                base.Update(gameTime);
            }
            else if(GameState == GameState.Paused)
            {
                buttons.ToList().ForEach(e => e.Update(gameTime));
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _level.Draw(_spriteBatch);
            
            if (GameState == GameState.Paused)
            {
                Texture2D background = Content.Load<Texture2D>("Sprites/Interface/graytransparant");
                _spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
                buttons.ToList().ForEach(e => e.Draw(_spriteBatch, 0));
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}