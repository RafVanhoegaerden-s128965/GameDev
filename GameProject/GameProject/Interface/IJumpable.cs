using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface IJumpable
    {
        public float GravityFactor { get; set; }
        float StartY { get; set; }
        float JumpSpeed { get; set; }
        bool IsJumping { get; set; }
        bool IsFalling { get; set;}
    }
}
