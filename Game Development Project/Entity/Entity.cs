using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Collision;
using GameDevelopmentProject.Entity.Movement;
using GameDevelopmentProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity
{
    public abstract class Entity: IGameObject, IMoving
    {
        internal Texture2D _texture;
        internal Animations _animation;
        internal List<Hitbox> _hitboxes;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        virtual public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, _animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
