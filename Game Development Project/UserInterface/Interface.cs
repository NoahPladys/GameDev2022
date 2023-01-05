using GameDevelopmentProject.Entity;
using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GameDevelopmentProject.UserInterface
{
    internal class Interface
    {
        public static void DrawIcons(Hero hero, Level level, SpriteBatch spriteBatch, Texture2D heartTexture, Texture2D missingHeartTexture, Texture2D coinTexture, Texture2D missingCoinTexture)
        {
            //DRAW HEARTS
            float scale = ScreenSizeManager.GetInstance().GetScale();
            float spacing = 15 * scale;
            Texture2D currentTexture = heartTexture;
            Vector2 currentHeartPosition = new Vector2(30*scale, 30 * scale);
            for (int i = 0; i < hero.MaxHealthPoints; i++)
            {
                if (i >= hero.CurrentHealthPoints)
                    currentTexture = missingHeartTexture;

                spriteBatch.Draw(
                    currentTexture,
                    currentHeartPosition,
                    new Rectangle(0, 0, currentTexture.Width, currentTexture.Height),
                    Color.White,
                    0,
                    new Vector2(0, 0),
                    scale*3,
                    SpriteEffects.None,
                    0);

                currentHeartPosition.X += (spacing + heartTexture.Width) * 3;
            }

            //DRAW COINS
            scale = ScreenSizeManager.GetInstance().GetScale() * 1.5f;
            spacing = 13 * scale;
            currentTexture = coinTexture;
            Coin[] coins = level.Coins.Where(e => (e != null)).ToArray();
            Vector2 currentCoinPosition = new Vector2(ScreenSizeManager.GetInstance().WindowWidth - (((spacing + coinTexture.Width) * 3) * coins.Length), 20 * scale);
            for (int i = 0; i < coins.Length; i++)
            {
                if (!level.Coins[i].IsPickedUp)
                    currentTexture = missingCoinTexture;
                else
                    currentTexture = coinTexture;

                spriteBatch.Draw(
                    currentTexture,
                    currentCoinPosition,
                    new Rectangle(0, 0, currentTexture.Width, currentTexture.Height),
                    Color.White,
                    0,
                    new Vector2(0, 0),
                    scale * 3,
                    SpriteEffects.None,
                    0);

                currentCoinPosition.X += (spacing + coinTexture.Width) * 3;
            }
        }
        
        public static Graphic[] getMenuGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/Title"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Title").Width / 2),
                    100*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game
                    ),
                new Button(
                "Level1",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/level1"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/level1").Width / 2),
                    300*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                "Level2",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/level2"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/level2").Width / 2),
                    475*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                "Level3",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/level3"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/level3").Width / 2),
                    650*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                "Quit",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/quit"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/quit").Width / 2),
                    850*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game)
            };
        }

        public static Graphic[] getPausedGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/Paused"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Paused").Width / 2),
                    100*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game
                    ),
                new Button(
                    "Resume",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/resume"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/resume").Width / 2),
                    300*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                    "Menu",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    500*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                    "Quit",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/quit"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/quit").Width / 2),
                    700*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game)
            };
        }

        public static Graphic[] getVictoryGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/victory"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/victory").Width / 2),
                    250*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game
                    ),
                new Button(
                    "Next",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/next"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/next").Width / 2),
                    450*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                    "Menu",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    650*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
            };
        }

        public static Graphic[] getGameoverGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/gameover"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/gameover").Width / 2),
                    250*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game
                    ),
                new Button(
                    "Retry",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/retry"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/retry").Width / 2),
                    450*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game),
                new Button(
                    "Menu",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.GetInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    650*(int)ScreenSizeManager.GetInstance().GetScale(),
                    game)
            };
        }
    }
}
