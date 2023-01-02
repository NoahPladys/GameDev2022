using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Interfaces
{
    interface IGameObject
    {
        void Update(GameTime gameTime, Game1 game = null);

        void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0);
    }
}
