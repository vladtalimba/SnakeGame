using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    internal interface IFood
    {
        int X { get; set; }
        int Y { get; set; }
        void Spawn();
        void HoldPosition();
        void Die();
    }
}
