using SnakeGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Interfaces
{
    internal interface ISnake
    {
        List<Positions> SnakeBody { get; }
        void Move();
        void Die();
        void Eat();
        void Spawn();
    }
}
