using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Controls
{
    public interface IInputReader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
