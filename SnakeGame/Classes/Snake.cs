using SnakeGame.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    // Custom data structure to keep track of the positions on X and Y axis.
    struct Positions
    {
        public Positions(int x, int y)
        {
            xPos = x; yPos = y;
        }
        public int xPos { get; }
        public int yPos { get; }   
    }
    internal class Snake : ISnake
    {
        private char snakePart = 'O';

        private int xDirection = 0;
        private int yDirection = 0;

        private List<Positions> snakeBody;

        private Random random;

        // Getter for the snake body.
        public List<Positions> SnakeBody
        {
            get { return snakeBody; }
        }

        // Instantiate objects.
        public Snake() {
            snakeBody = new List<Positions>();
            random  = new Random();
        }

        /*
         * This methods spawns the snake in the console.
         */
        public void Spawn()
        {
            // Set the position of the snake's head to a random spot in the console window.
            int X = random.Next(0, Console.WindowWidth);
            int Y = random.Next(0, Console.WindowHeight);
            snakeBody.Add(new Positions(X, Y));
        }

        /*
         * Movement logic for the snake.
         */
        public void Move()
        {
            // Set directions according to which arrow button we press.
            if (Console.KeyAvailable)
            {
                var command = Console.ReadKey().Key;
                if(command == ConsoleKey.DownArrow && yDirection != -1)
                {
                    xDirection = 0;
                    yDirection = 1;
                }
                if (command == ConsoleKey.UpArrow && yDirection != 1)
                {
                    xDirection = 0;
                    yDirection = -1;
                }
                if (command == ConsoleKey.LeftArrow && xDirection != 1)
                {
                    xDirection = -1;
                    yDirection = 0;
                }
                if (command == ConsoleKey.RightArrow && xDirection != -1)
                {
                    xDirection = 1;
                    yDirection = 0;
                }

            }

            // Loop through the snake backwards. Looping forwards is also possible but the syntax is simpler like this.
            for(int i = SnakeBody.Count - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    // Move the head according to the set direction.
                    SnakeBody[i] = new Positions(SnakeBody[i].xPos + xDirection, SnakeBody[i].yPos + yDirection);
                }else
                {
                    // Have the other snake parts follow the head's position.
                    SnakeBody[i] = new Positions(SnakeBody[i - 1].xPos, SnakeBody[i - 1].yPos);
                }
                
                // If we go off the edge.
                if (SnakeBody[i].xPos >= Console.WindowWidth)
                {
                    SnakeBody[i] = new Positions(0, SnakeBody[i].yPos);
                }
                else if (SnakeBody[i].xPos <= 0)
                {
                    SnakeBody[i] = new Positions(Console.WindowWidth - 1, SnakeBody[i].yPos);
                }
                else if (SnakeBody[i].yPos >= Console.WindowHeight)
                {
                    SnakeBody[i] = new Positions(SnakeBody[i].xPos, 0);
                }
                else if (SnakeBody[i].yPos <= 0)
                {
                    SnakeBody[i] = new Positions(SnakeBody[i].xPos, Console.WindowHeight - 1);
                }

                // Write a snake part for each position in the list.
                Console.SetCursorPosition(SnakeBody[i].xPos, SnakeBody[i].yPos);
                Console.Write(snakePart);
            }

        }

        public void Eat()
        {
            // When the snake eats, update its length by inserting at the head (easier logic).
            snakeBody.Insert(0, new Positions(SnakeBody[0].xPos + xDirection, SnakeBody[0].yPos + yDirection));
        }
        // Kill the snake.
        public void Die()
        {
            Thread.Sleep(2000);   
        }
    }
}
