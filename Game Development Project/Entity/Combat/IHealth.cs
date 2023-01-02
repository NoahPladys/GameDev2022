using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Entity.Combat
{
    public interface IHealth
    {
        public CombatManager CombatManager { get; set; }
        public int MaxHealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public bool IsDead { get; set; }
    }
}
