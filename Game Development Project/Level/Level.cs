using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GameDevelopmentProject.Levels
{
    public class Level : IGameObject
    {
        public Tile[,] Tileset;
        public Texture2D background;
        public Texture2D backgroundObject;
        private readonly int tilesetHeight = 16;
        public Hero Hero;

        public Level(ContentManager content, char[,] tileSet, Rectangle tileBoundingBox, Hero hero)
        {
            Tileset = TilesetFactory.GenerateTileSet(
                tileSet,
                content.Load<Texture2D>("Sprites/Tileset/Grass/grass_tileset"),
                this.getTileScale(),
                tileBoundingBox);
            background = content.Load<Texture2D>("Sprites/Tileset/Grass/sky");
            backgroundObject = content.Load<Texture2D>("Sprites/Tileset/Grass/background_trees");
            Hero = hero;
            Hero.Position = new Vector2(
                Tileset[getLowestTileHeight(2), 2].Position.X,
                Tileset[getLowestTileHeight(2), 2].Position.Y - Hero.BoundingBox.Height);
        }

        public void Update(GameTime gameTime, Level level = null)
        {
            Hero.Update(gameTime, this);
        }

        public void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0)
        {
            float tileScale = getTileScale();
            float lowestTileHeight = getLowestTileHeight();
            float backgroundScale = getBackgroundScale();
            float backgroundObjectScale = getBackgroundScaleObject();
            cameraHorizontalOffset = getCameraHorizontalOffset(Hero);

            //DRAW BACKGROUND
            for (int i=0; i<Math.Round(Math.Floor((decimal)ScreenSizeManager.getInstance().WindowWidth / background.Width))+1; i++)
                spriteBatch.Draw(
                    background,
                    new Vector2(background.Width*this.getBackgroundScale() * i, 0),
                    new Rectangle(0, 0, background.Width, background.Height),
                    Color.White,
                    0,
                    new Vector2(0, 0),
                    backgroundScale,
                    SpriteEffects.None,
                    0);

            //DRAW BACKGROUND OBJECTS
            if(backgroundObject != null)
            {
                for (int i = 0; i < Math.Round(Math.Floor((decimal)ScreenSizeManager.getInstance().WindowWidth / backgroundObject.Width)) + 1; i++)
                    spriteBatch.Draw(
                        backgroundObject,
                        new Vector2((backgroundObject.Width * i * backgroundObjectScale) - cameraHorizontalOffset / 6,
                        (lowestTileHeight * tileScale * 16) - (backgroundObject.Height * backgroundObjectScale)),
                        new Rectangle(0, 0, backgroundObject.Width, backgroundObject.Height),
                        Color.White,
                        0,
                        new Vector2(0, 0),
                        backgroundObjectScale,
                        SpriteEffects.None,
                        0);
            }

            //DRAW TILES
            for (int i=0; i<Tileset.GetLength(0); i++)
            {
                for(int j=0; j < Tileset.GetLength(1); j++)
                {
                    Tile currentTile = Tileset[i, j];
                    if (currentTile != null)
                        spriteBatch.Draw(
                            currentTile.Texture,
                            currentTile.Position - new Vector2(cameraHorizontalOffset + currentTile.BoundingBox.X, 0 + currentTile.BoundingBox.Y),
                            currentTile.SourceRectangle,
                            Color.White, 
                            0,
                            new Vector2(0, 0),
                            tileScale,
                            SpriteEffects.None,
                            0);
                }
            }

            //DRAW HERO
            Hero.Draw(spriteBatch, cameraHorizontalOffset);
        }

        private float getBackgroundScale()
        {
            return ((float)ScreenSizeManager.getInstance().WindowHeight / background.Height) * (getLowestTileHeight() / (float)tilesetHeight);
        }

        private float getBackgroundScaleObject()
        {
            return ((float)ScreenSizeManager.getInstance().WindowHeight / background.Height) * 1.5f;
        }

        public float getTileScale()
        {
            return (float)Math.Round(((float)(ScreenSizeManager.getInstance().WindowHeight) / tilesetHeight / 16f), 4);
        }

        private int getLowestTileHeight()
        {
            int lowestTile = 0;
            for (int x = 0; x < Tileset.GetLength(1); x++)
            {
                int lowestTileAtX = getLowestTileHeight(x);
                if (lowestTileAtX > lowestTile)
                    lowestTile = lowestTileAtX;
            }
            return lowestTile;
        }

        private int getLowestTileHeight(int x)
        {
            for (int y = 0; y < Tileset.GetLength(0); y++)
            {
                if (Tileset[y, x] != null)
                    return y;
            }
            return Tileset.GetLength(0);
        }

        private float getCameraHorizontalOffset(Hero hero)
        {
            int screenWidth = ScreenSizeManager.getInstance().WindowWidth;
            if (hero.Position.X < (screenWidth / 3))
                return 0;
            else if((hero.Position.X - (screenWidth / 3)) > (Tileset.GetLength(1) * getTileScale() * 16) - screenWidth)
                return ((Tileset.GetLength(1) * getTileScale() * 16) - screenWidth);
            return (hero.Position.X - (screenWidth / 3));
        }
    }
}
