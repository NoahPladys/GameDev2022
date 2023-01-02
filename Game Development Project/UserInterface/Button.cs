﻿using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;

namespace GameDevelopmentProject.UserInterface
{
    internal class Button : Graphic
    {
        public string Action;
        private ButtonState lastState;

        public Button(string Action, Texture2D texture, int posX, int posY, Game1 game) : base(texture, posX, posY, game)
        {
            this.Action = Action;
            lastState = ButtonState.Pressed;
        }

        public bool enterButton()
        {
            if (Mouse.GetState().X < PosX + Texture.Width &&
                    Mouse.GetState().X > PosX &&
                    Mouse.GetState().Y-20 < PosY + Texture.Height &&
                    Mouse.GetState().Y-20 > PosY)
                return true;
            return false;
        }

        public void Update(GameTime gameTime, Game1 game = null)
        {
            if (lastState == ButtonState.Released && enterButton() && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Action == "Resume")
                {
                    _game.GameState = GameState.Playing;
                }
                else if (Action == "Menu")
                {
                    _game.GameState = GameState.Menu;
                    _game.Level = null;
                }
                else if (Action == "Quit")
                {
                    _game.Exit();
                }
                else if (Action == "Retry" || Action == "Next" || Action.Substring(0, 5) == "Level")
                {
                    if (Action == "Retry")
                    {
                        Action = "Level" + _game.Level.LevelNumber;
                    }
                    else if (Action == "Next")
                    {
                        Action = "Level" + (_game.Level.LevelNumber + 1);
                    }

                    int levelIndex = int.Parse(Action.Substring(5,1));
                    if (LevelFactory.Exists(levelIndex))
                    {
                        _game.Hero = Hero.getNewHero(_game.Content);
                        _game.Level = LevelFactory.getLevel(levelIndex, _game.Content, _game.Hero);
                        _game.GameState = GameState.Playing;
                    }
                    else
                    {
                        _game.GameState = GameState.Menu;
                    }
                }
            }

            lastState = Mouse.GetState().LeftButton;
        }
    }
}
