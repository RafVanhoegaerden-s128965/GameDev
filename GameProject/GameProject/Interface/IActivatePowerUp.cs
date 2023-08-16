using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface IActivatePowerUp
    {
        public bool JumpPowerUpActive { get; set; }
        public int JumpEffect { get; set; }
        public bool HealthPowerUpActive { get; set; }
        public int HealthEffect { get; set; }
        public bool HealthEffectApplied { get; set; }
        public bool AttackPowerUpActive { get; set; }
        public int AttackEffect { get; set; }

    }
}
