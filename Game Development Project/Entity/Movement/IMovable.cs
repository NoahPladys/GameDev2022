using GameDevelopmentProject.Entity.Animation;
using GameDevelopmentProject.Entity.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Movement
{
    internal interface IMovable
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
    }
}
