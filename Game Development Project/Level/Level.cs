using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Levels
{
    public class Level : IGameObject
    {
        public Tile[,] Tileset;

        public Level(ContentManager content)
        {
            Tile grassTile = new Tile(content.Load<Texture2D>("Sprites/Hero/Light/Run"), new Rectangle(0, 0, 16, 16));
            Tileset = new Tile[,] {
                { null, null, null },
                { null, null, null },
                { grassTile, grassTile, grassTile }
            };
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i=0; i<Tileset.GetLength(0); i++)
            {
                for(int j=0; j < Tileset.GetLength(1); j++)
                {
                    Console.WriteLine(i+" : "+j);
                    Tile currentTile = Tileset[i, j];
                    if (currentTile != null)
                        spriteBatch.Draw(
                            currentTile.Texture,
                            new Vector2(i*16, j*16),
                            currentTile.SourceRectangle,
                            Color.White);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
