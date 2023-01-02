using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.UserInterface
{
    internal class Graphic : IGameObject
    {
        public int PosX { get; }
        public int PosY { get; }
        public Texture2D Texture;
        internal Game1 _game;

        public Graphic(Texture2D texture, int posX, int posY, Game1 game)
        {
            this.Texture = texture;
            this.PosX = posX;
            this.PosY = posY;
            this._game = game;
        }

        public void Update(GameTime gameTime, Game1 game = null)
        {
            //EMPTY
        }

        public void Draw(SpriteBatch spriteBatch, float cameraOffset = 0)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)PosX, (int)PosY, Texture.Width, Texture.Height), Color.White);
        }
    }
}
