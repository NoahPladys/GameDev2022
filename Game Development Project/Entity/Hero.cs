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
using GameDevelopmentProject.Entity.Collision;

namespace GameDevelopmentProject.Entity
{
    public class Hero: Entity, IPlayerMovable
    {
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public Hero(Texture2D texture, IInputReader inputReader, int frameWidth, int frameHeight)
        {
            _texture = texture;
            _animation = new Animations();
            _animation.AddFrames(texture.Width, frameWidth, frameHeight);
            MovementManager = new MovementManager();
            InputReader = inputReader;
            Position = new Vector2(0, 0);
            Speed = new Vector2(2, 2);
            _hitboxes.Add(new Hitbox(, 0));
        }

        override public void Update(GameTime gameTime)
        {
            MovementManager.Move(this);
            base.Update(gameTime);
        }
    }
}
