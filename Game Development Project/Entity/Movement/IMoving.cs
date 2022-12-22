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
    internal interface IMoving
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public float GravityForce { get; set; }
        public float CurrentGravityForce { get; set; }
        public float MaxGravityForce { get; set; }
        public float JumpForce { get; set; }
        public float MaxJumpForce { get; set; }
        public float JumpForceDecrease { get; set; }
        public float CurrentJumpForceDecrease { get; set; }
        public bool CanJump { get; set; }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
    }
}
