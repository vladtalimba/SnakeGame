using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    class Food : IFood
    {

        private char foodPart = '#';

        private int x = 1;

        private int y = 0;

        private Random random;

        // Getters and setters for food's position.
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Food() { 
            random = new Random();
        }

        /*
         * This method spawns the food at a random location in the console.
         * */
        public void Spawn()
        {
            // Set the position of the food to a random spot in the console window.
            X = random.Next(0, Console.WindowWidth);
            Y = random.Next(0, Console.WindowHeight);
        }

        // We need to hold the position of the food because the console clears all the time.
        // We set the coordinates in the Spawn() method, then we keep drawing the food.
        public void HoldPosition()
        {
            // Set the cursor to the coordinates.
            Console.SetCursorPosition(X, Y);
            // Write the snake.
            Console.Write(foodPart);
        }

        // Respawn the food.
        public void Die()
        {
            Spawn();
        }
    }
}
