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
    public class Tile : ICollidable
    {
        public Texture2D Texture;
        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; }
        public Rectangle RelativeBoundingBox { 
            get
            {
                Rectangle boundingBox = BoundingBox;
                return new Rectangle(
                    (int)Math.Round(Position.X),
                    (int)Math.Round(Position.Y),
                    boundingBox.Width,
                    boundingBox.Height
                    );
            } 
        }

        public Tile(Texture2D texture, Rectangle sourceRectangle, Vector2 position, Rectangle boundingBox)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Position = position;
            BoundingBox = boundingBox;
        }
    }
}
