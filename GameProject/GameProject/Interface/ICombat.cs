﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface ICombat
    {
        public DateTime LastHitTime { get; set; }
        public bool IsAlive { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Damage { get; set; }
        public bool IsDamaged { get; set; }
    }
}
