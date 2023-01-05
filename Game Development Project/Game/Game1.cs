using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Levels;
using GameDevelopmentProject.UserInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Diagnostics;
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
        public Hero Hero;
        public Level Level;
        private Graphic[] _pausedGraphics;
        private Graphic[] _menuGraphics;
        private Graphic[] _victoryGraphics;
        private Graphic[] _gameoverGraphics;
        public GameState GameState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _screen = ScreenSizeManager.GetInstance();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _screen.Initialize(_graphics);
            MusicPlayer.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            MusicPlayer.PlaySong(Content, 0);
            Hero = Hero.getNewHero(Content);
            _screen.SetCurrentResolution(_graphics);

            _pausedGraphics = Interface.getPausedGraphics(Content, this);
            _menuGraphics = Interface.getMenuGraphics(Content, this);
            _victoryGraphics = Interface.getVictoryGraphics(Content, this);
            _gameoverGraphics = Interface.getGameoverGraphics(Content, this);
        }

        private bool previousEscapeButtonPressed = false;
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && previousEscapeButtonPressed == false)
            {
                if (GameState == GameState.Playing)
                {
                    GameState = GameState.Paused;
                    MusicPlayer.Paused(true);
                }
                else if (GameState == GameState.Paused)
                {
                    GameState = GameState.Playing;
                    MusicPlayer.Paused(false);
                }
            }
            previousEscapeButtonPressed = Keyboard.GetState().IsKeyDown(Keys.Escape);
            _screen.SetCurrentResolution(_graphics);

            if(Level != null && Hero.RelativeBoundingBox.Intersects(Level.VictoryBoundingBox))
            {
                GameState = GameState.Victory;
            } 
            
            if (GameState == GameState.Playing || GameState == GameState.GameOver)
            {
                Level.Update(gameTime, this);
                if (GameState == GameState.GameOver)
                {
                    _gameoverGraphics.ToList().ForEach(e => { if (e is Button) ((Button)e).Update(gameTime); });
                }
            }
            else if(GameState == GameState.Paused)
            {
                _pausedGraphics.ToList().ForEach(e => { if (e is Button) ((Button)e).Update(gameTime); });
            } 
            else if(GameState == GameState.Menu)
            {
                _menuGraphics.ToList().ForEach(e => { if (e is Button) ((Button)e).Update(gameTime); });
            } 
            else if(GameState == GameState.Victory)
            {
                _victoryGraphics.ToList().ForEach(e => { if (e is Button) ((Button)e).Update(gameTime); });
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            if (GameState == GameState.Playing || GameState == GameState.Paused || GameState == GameState.Victory || GameState == GameState.GameOver)
            {
                Level.Draw(_spriteBatch);
                Interface.DrawIcons(
                    Hero,
                    Level,
                    _spriteBatch, 
                    Content.Load<Texture2D>("Sprites/Icons/Heart"), 
                    Content.Load<Texture2D>("Sprites/Icons/HeartMissing"),
                    Content.Load<Texture2D>("Sprites/Icons/Coin"),
                    Content.Load<Texture2D>("Sprites/Icons/CoinMissing"));

                if (GameState != GameState.Playing)
                {
                    Texture2D background = Content.Load<Texture2D>("Sprites/Interface/graytransparant");
                    _spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);

                    if (GameState == GameState.Paused)
                        _pausedGraphics.ToList().ForEach(e => e.Draw(_spriteBatch, 0));
                    else if (GameState == GameState.Victory)
                        _victoryGraphics.ToList().ForEach(e => e.Draw(_spriteBatch, 0));
                    else if (GameState == GameState.GameOver)
                        _gameoverGraphics.ToList().ForEach(e => e.Draw(_spriteBatch, 0));
                }
            }
            else if (GameState == GameState.Menu)
            {
                Texture2D background = Content.Load<Texture2D>("Sprites/Interface/menubackground");
                _spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
                _menuGraphics.ToList().ForEach(e => e.Draw(_spriteBatch, 0));
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}