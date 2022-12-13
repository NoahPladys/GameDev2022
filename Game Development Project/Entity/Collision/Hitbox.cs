using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Collision
{
    public class Hitbox
    {
        public Hitbox(int offsetx, int offsety, int width, int height, int damage)
        {
            this.HitboxBounds = new Rectangle(offsetx, offsety, width, height);
            this.Damage = damage;
        }

        public Rectangle HitboxBounds { get; set; }
        public int Damage { get; set; }
    }
}
