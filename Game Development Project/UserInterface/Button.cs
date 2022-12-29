using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    internal class Button : IGameObject
    {
        public int ButtonX { get; }

        public int ButtonY { get; }

        string Name;
        Texture2D Texture;

        private Game1 _game;

        public Button(string name, Texture2D texture, int buttonX, int buttonY, Game1 game)
        {
            this.Name = name;
            this.Texture = texture;
            this.ButtonX = buttonX;
            this.ButtonY = buttonY;
            this._game = game;
        }

        public bool enterButton()
        {
            if (Mouse.GetState().X < ButtonX + Texture.Width &&
                    Mouse.GetState().X > ButtonX &&
                    Mouse.GetState().Y-20 < ButtonY + Texture.Height &&
                    Mouse.GetState().Y-20 > ButtonY)
                return true;
            return false;
        }

        public void Update(GameTime gameTime, Level level = null)
        {
            if (enterButton() && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Name == "Resume")
                {
                    _game.GameState = GameState.Playing;
                }
                else if (Name == "Menu")
                {
                    _game.GameState = GameState.Menu;
                }
                else if(Name == "Quit")
                {
                    _game.Exit();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, float cameraOffset = 0)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)ButtonX, (int)ButtonY, Texture.Width, Texture.Height), Color.White);
        }
    }
}
