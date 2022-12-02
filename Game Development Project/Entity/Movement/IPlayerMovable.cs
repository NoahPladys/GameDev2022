using GameDevelopmentProject.Entity.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Movement
{
    internal interface IPlayerMovable: IMoving
    {
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
    }
}
