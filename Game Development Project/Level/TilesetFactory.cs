using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Levels
{
    public class TilesetFactory
    {
        private static int _tilesetHeight = 16;
        public static Tile[,] GenerateTileSet(char[,] tilesetChar, Texture2D texture, float tileScale)
        {
            if (tilesetChar.GetLength(0) == _tilesetHeight)
            {
                Tile[,] tileset = new Tile[tilesetChar.GetLength(0), tilesetChar.GetLength(1)];
                for (int i = 0; i < tilesetChar.GetLength(0); i++)
                {
                    for (int j = 0; j < tilesetChar.GetLength(1); j++)
                    {
                        if (tilesetChar[i, j] != '.')
                        {
                            if (tilesetChar[i, j] == '#')
                            {
                                if (tileset[i, j] == null)
                                {
                                    int width = 1;
                                    int height = 1;
                                    int k = i;
                                    int l = j;
                                    while (l != tileset.GetLength(1) - 1
                                        && tilesetChar[k, l + 1] == '#'
                                        && k != 0
                                        && tilesetChar[k - 1, l + 1] != '#')
                                    {
                                        width++;
                                        l++;
                                    }
                                    while (k != tileset.GetLength(0) - 1 && tilesetChar[k + 1, l] == '#')
                                    {
                                        height++;
                                        k++;
                                    }
                                    drawSquare(tileset, texture, j, i, width, height, tileScale);
                                }
                            }
                        }
                    }
                }
                return tileset;
            }
            return null;
        }

        private static void drawSquare(Tile[,] tileset, Texture2D texture, int posX, int posY, int width, int height, float scale)
        {
            for (int y = posY; y < posY + height; y++)
            {
                for (int x = posX; x < posX + width; x++)
                {
                    int texturePosX;
                    int texturePosY;

                    if(height == 1 && width == 1)
                    {
                        texturePosX = 0;
                        texturePosY = 64;
                    }
                    else
                    {
                        if (y == posY)
                        {
                            if (height == 1)
                                texturePosY = 48;
                            else
                                texturePosY = 0;
                        }
                        else if (y == posY + height - 1)
                            texturePosY = 32;
                        else
                            texturePosY = 16;


                        if (x == posX)
                        {
                            if (width == 1)
                                texturePosX = 16;
                            else
                                texturePosX = 0;
                        }
                        else if (x == posX + width - 1)
                            texturePosX = 32;
                        else
                            texturePosX = 16;
                    }
                    tileset[y,x] = new Tile(texture, new Rectangle(texturePosX, texturePosY, 16, 16), new Vector2(x*16*scale, y*16*scale));
                }
            }
        }
    }
}