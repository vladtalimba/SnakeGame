using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    class Game : IGame
    {
        public ISnake snake;
        public IFood food;
        public bool isPlaying = true;

        // Instantiate food and snake objects.
        public Game()
        {
            snake = new Snake();
            food  = new Food();
        }
        public void StartGame()
        {
            // Spawn snake and food at random positions.
            snake.Spawn();
            food.Spawn();

            // While true loop. Works like a function using a ticker.
            while (isPlaying)
            {
                // Update the console. Hold food's position and keep the snake moving.
                Console.Clear();
                food.HoldPosition();
                snake.Move();

                // If snake's head reaches the food, eat the food and make the snake longer.
                if (food.X == snake.SnakeBody[0].xPos && food.Y == snake.SnakeBody[0].yPos)
                {
                    snake.Eat();
                    food.Die();
                }

                // Check if the head of the snake hits any other body parts. If yes, end the game.
                for(int i = 1; i < snake.SnakeBody.Count; i++)
                {
                    if (snake.SnakeBody[0].xPos == snake.SnakeBody[i].xPos && snake.SnakeBody[0].yPos == snake.SnakeBody[i].yPos)
                    {
                        snake.Die();
                        isPlaying = false;
                        EndGame();
                    }
                }
                Thread.Sleep(50);
            }
        }

        public void EndGame()
        {
            // End the game.
            Console.Clear();
            Console.WriteLine("You died.");
        }
    }
}
