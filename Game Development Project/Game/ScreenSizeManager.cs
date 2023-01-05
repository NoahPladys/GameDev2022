using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;


namespace GameDevelopmentProject
{
    public class ScreenSizeManager
    {
        private static ScreenSizeManager instance = new ScreenSizeManager();

        public static ScreenSizeManager GetInstance()
        {
            return instance;
        }


        private int _defaultWidth;
        private int _defaultHeight;

        public int WindowWidth;
        public int WindowHeight;

        private ScreenSizeManager()
        {
            _defaultWidth = 1280;
            _defaultHeight = 720;
            WindowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            WindowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        public float GetScale()
        {
            return ((float)WindowHeight / _defaultHeight);
        }

        public void Initialize(GraphicsDeviceManager graphics)
        {
            graphics.IsFullScreen = true;
        }

        public void SetCurrentResolution(GraphicsDeviceManager graphics)
        {
            if(graphics.PreferredBackBufferWidth != WindowWidth)
                graphics.PreferredBackBufferWidth = WindowWidth;
            if(graphics.PreferredBackBufferHeight != WindowHeight)
                graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.ApplyChanges();
        }
    }
}
