using System;

class Game
{
    static int playerPositionY = Console.WindowHeight / 2; // Posición inicial del jugador en el centro de la pantalla
    static int obstaclePositionX = Console.WindowWidth - 1; // Posición inicial del obstáculo al final de la pantalla
    static bool gameOver = false;
    static int score = 0;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.Clear();

        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar && playerPositionY > 0) // Mover hacia arriba solo si no estamos en el borde superior
                {
                    playerPositionY--;
                }
                else if (key.Key == ConsoleKey.Spacebar && playerPositionY < Console.WindowHeight - 1) // Mover hacia abajo solo si no estamos en el borde inferior
                {
                    playerPositionY++;
                }
            }

            DrawPlayer();
            MoveObstacle();
            CheckCollision();
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Score: " + score);
            System.Threading.Thread.Sleep(100);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine("Score: " + score);
        Console.ReadLine();
    }

    static void MoveObstacle()
    {
        obstaclePositionX--;

        if (obstaclePositionX <= 0)
        {
            obstaclePositionX = Console.WindowWidth - 1;
            score++;
        }
    }

    static void CheckCollision()
    {
        if (obstaclePositionX == 0 && playerPositionY == Console.WindowHeight - 1)
        {
            gameOver = true;
        }
    }

    static void DrawPlayer()
    {
        Console.Clear();
        Console.SetCursorPosition(0, playerPositionY);
        Console.Write("O");
        Console.SetCursorPosition(obstaclePositionX, Console.WindowHeight - 1);
        Console.Write("X");
    }
}
