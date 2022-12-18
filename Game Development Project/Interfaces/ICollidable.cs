using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Interfaces
{
    internal interface ICollidable
    {
        public Rectangle BoundingBox { get; }
    }
}
