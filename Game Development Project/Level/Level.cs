using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
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
        public int LevelNumber;
        public Tile[,] Tileset;
        public Texture2D Background;
        public Texture2D BackgroundObject;
        private readonly int tilesetHeight = 16;
        public Hero Hero;
        public List<Hostile> Hostiles = new List<Hostile>();
        public Rectangle VictoryBoundingBox;

        public Level(int levelNumber, char[,] tileSet, Rectangle tileBoundingBox, Rectangle victoryBoundingBox, Hero hero, Texture2D tilesetTexture, Texture2D backgroundTexture, Texture2D backgroundObjectTexture = null)
        {
            LevelNumber = levelNumber;
            Tileset = TilesetFactory.GenerateTileSet(
                tileSet,
                tilesetTexture,
                this.getTileScale(),
                tileBoundingBox);
            VictoryBoundingBox = new Rectangle(
                (int)Math.Round(victoryBoundingBox.X * getTileScale() * 16),
                (int)Math.Round(victoryBoundingBox.Y * getTileScale() * 16),
                (int)Math.Round(victoryBoundingBox.Width * getTileScale() * 16),
                (int)Math.Round(victoryBoundingBox.Height * getTileScale() * 16));
            Background = backgroundTexture;
            BackgroundObject = backgroundObjectTexture;
            Hero = hero;
            Hero.Position = new Vector2(
                Tileset[getLowestTileHeight(2), 2].Position.X,
                Tileset[getLowestTileHeight(2), 2].Position.Y - Hero.BoundingBox.Height);
        }

        public void Update(GameTime gameTime, Game1 game = null)
        {
            Hero.Update(gameTime, game);
            Hostiles.ForEach(e => e.Update(gameTime, game));
        }

        public void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0)
        {
            float tileScale = getTileScale();
            float lowestTileHeight = getLowestTileHeight();
            float backgroundScale = getBackgroundScale();
            float backgroundObjectScale = getBackgroundScaleObject();
            cameraHorizontalOffset = getCameraHorizontalOffset(Hero);

            //DRAW BACKGROUND
            for (int i=0; i<Math.Round(Math.Floor((decimal)ScreenSizeManager.getInstance().WindowWidth / Background.Width))+1; i++)
                spriteBatch.Draw(
                    Background,
                    new Vector2(Background.Width*this.getBackgroundScale() * i, 0),
                    new Rectangle(0, 0, Background.Width, Background.Height),
                    Color.White,
                    0,
                    new Vector2(0, 0),
                    backgroundScale+0.001f,
                    SpriteEffects.None,
                    0);

            //DRAW BACKGROUND OBJECTS
            if(BackgroundObject != null)
            {
                for (int i = 0; i < Math.Round(Math.Floor((decimal)ScreenSizeManager.getInstance().WindowWidth / BackgroundObject.Width)) + 1; i++)
                    spriteBatch.Draw(
                        BackgroundObject,
                        new Vector2((BackgroundObject.Width * i * backgroundObjectScale) - cameraHorizontalOffset / 6,
                        (lowestTileHeight * tileScale * 16) - (BackgroundObject.Height * backgroundObjectScale)),
                        new Rectangle(0, 0, BackgroundObject.Width, BackgroundObject.Height),
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

            //DRAW HOSTILES
            Hostiles.ForEach(e => {
                e.Draw(spriteBatch, cameraHorizontalOffset);
                });
        }

        private float getBackgroundScale()
        {
            return ((float)ScreenSizeManager.getInstance().WindowHeight / Background.Height) * (getLowestTileHeight() / (float)tilesetHeight);
        }

        private float getBackgroundScaleObject()
        {
            return ((float)ScreenSizeManager.getInstance().WindowHeight / Background.Height) * 1.5f;
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
