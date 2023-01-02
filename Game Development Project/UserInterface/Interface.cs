using GameDevelopmentProject.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.UserInterface
{
    internal class Interface
    {
        public static Graphic[] getMenuGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/Title"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Title").Width / 2),
                    100*(int)ScreenSizeManager.getInstance().GetScale(),
                    game
                    ),
                new Button(
                "Level1",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/level1"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/level1").Width / 2),
                    300*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                "Level2",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/level2"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/level2").Width / 2),
                    475*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                "Level3",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/level3"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/level3").Width / 2),
                    650*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                "Quit",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/quit"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/quit").Width / 2),
                    850*(int)ScreenSizeManager.getInstance().GetScale(),
                    game)
            };
        }

        public static Graphic[] getPausedGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/Paused"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Paused").Width / 2),
                    100*(int)ScreenSizeManager.getInstance().GetScale(),
                    game
                    ),
                new Button(
                    "Resume",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/resume"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/resume").Width / 2),
                    300*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                    "Menu",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    500*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                    "Quit",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/quit"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/quit").Width / 2),
                    700*(int)ScreenSizeManager.getInstance().GetScale(),
                    game)
            };
        }

        public static Graphic[] getVictoryGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/victory"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/victory").Width / 2),
                    250*(int)ScreenSizeManager.getInstance().GetScale(),
                    game
                    ),
                new Button(
                    "Next",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/next"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/next").Width / 2),
                    450*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                    "Menu",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    650*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
            };
        }

        public static Graphic[] getGameoverGraphics(ContentManager content, Game1 game)
        {
            return new Graphic[]
            {
                new Graphic(
                    content.Load<Texture2D>("Sprites/Interface/gameover"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/gameover").Width / 2),
                    250*(int)ScreenSizeManager.getInstance().GetScale(),
                    game
                    ),
                new Button(
                    "Retry",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/retry"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/retry").Width / 2),
                    450*(int)ScreenSizeManager.getInstance().GetScale(),
                    game),
                new Button(
                    "Menu",
                    content.Load<Texture2D>("Sprites/Interface/Buttons/menu"),
                    (ScreenSizeManager.getInstance().WindowWidth / 2) - (content.Load<Texture2D>("Sprites/Interface/Buttons/menu").Width / 2),
                    650*(int)ScreenSizeManager.getInstance().GetScale(),
                    game)
            };
        }
    }
}
