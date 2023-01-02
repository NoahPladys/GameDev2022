using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Combat
{
    public interface IAttacking : IHealth
    {
        public int Damage { get; }
        public bool CanAttack { get; set; }
        public bool Attacking { get; set; }
        public Rectangle AttackRange { get; }
    }
}
