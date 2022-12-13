using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Animation
{
    public interface IAnimatable
    {
        public AnimationManager AnimationManager { get; set; }
    }
}
