using GameDevelopmentProject.Interfaces;
using GameDevelopmentProject.Entity.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SharpDX.MediaFoundation;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using GameDevelopmentProject.Entity.Controls;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Levels;

namespace GameDevelopmentProject.Entity
{
    public class Hero : Entity
    {
        public Hero(IInputReader inputReader, float speed)
        {
            //INITIALIZE ANIMATIONS
            AnimationManager = new AnimationManager();

            //INITIALIZE MOVEMENT
            MovementManager = new MovementManager();
            InputReader = inputReader;
            Position = new Vector2(0, 0);
            Speed = new Vector2(speed, 0);
            IsFalling = false;
            BoundingBox = new Rectangle(50, 43, 29, 37);
        }

        override public void Update(GameTime gameTime, Level level)
        {
            base.Update(gameTime, level);
        }
    }
}
