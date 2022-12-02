using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Movement
{
    internal interface IMoving
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
    }
}
