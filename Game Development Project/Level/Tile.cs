using GameDevelopmentProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Levels
{
    public class Tile
    {
        public Texture2D Texture;
        public Rectangle SourceRectangle { get; set; }

        public Tile(Texture2D texture, Rectangle sourceRectangle)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
        }
    }
}
