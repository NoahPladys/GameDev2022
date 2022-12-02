using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Controls
{
    class MouseReader : IInputReader
    {
        public bool IsDestinationInput => true;

        public Vector2 ReadInput()
        {
            MouseState state = Mouse.GetState();
            Vector2 directionMouse = new Vector2(state.X, state.Y);
            return directionMouse;
        }
    }

}
