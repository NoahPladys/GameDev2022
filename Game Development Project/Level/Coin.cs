using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Levels
{
    public class Coin : IGameObject
    {
        public Vector2 Position { get; set; }
        public Rectangle PickupRange {
            get
            {
                return new Rectangle(
                    (int)Math.Round(Position.X),
                    (int)Math.Round(Position.Y),
                    (int)Math.Round(_animation.BoundingBox.Width * _scale),
                    (int)Math.Round(_animation.BoundingBox.Height * _scale));
            }
        }

        public bool IsPickedUp { get; set; }
        private Animations _animation;
        private float _scale;

        public Coin(Vector2 position, ContentManager content)
        {
            _animation = new Animations(
                content.Load<Texture2D>("Sprites/Icons/CoinAnimation"),
                new Rectangle(2, 2, 16, 16),
                new Rectangle(2, 2, 16, 16),
                true);
            _animation.AddFrames(16, 16);
            Position = position * ScreenSizeManager.getInstance().GetScale();
            IsPickedUp = false;
            _scale = ScreenSizeManager.getInstance().GetScale() * 4;
        }

        public void Draw(SpriteBatch spriteBatch, float cameraHorizontalOffset = 0)
        {
            spriteBatch.Draw(
                _animation.Texture,
                Position - new Vector2(cameraHorizontalOffset + _animation.BoundingBox.X, _animation.BoundingBox.Y),
                _animation.CurrentFrame.SourceRectangle,
                Color.White,
                0,
                new Vector2(0),
                _scale,
                SpriteEffects.None,
                0);
        }

        public void Update(GameTime gameTime, Game1 game = null)
        {
            _animation.Update(gameTime);
            if (game.Hero.RelativeBoundingBox.Intersects(PickupRange))
                IsPickedUp = true;
        }
    }
}
