using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Interface
{
    internal interface IControllable
    {
        public IInputReader InputReader { get; set; }
    }
}
