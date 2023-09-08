using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<(string PlayerName, int Attempts)> highscores = new List<(string, int)>();

    static void Main()
    {
        Console.WriteLine("Willkommen beim Zahlenraten-Spiel!");

        while (true)
        {
            Console.Write("Möchten Sie das Spiel spielen? (1 für Einzelspieler, 2 für Zweispielerspiel, 0 zum Beenden): ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Auf Wiedersehen!");
                DisplayHighscores();
                break;
            }
            else if (choice == "1")
            {
                PlaySinglePlayerGame();
            }
            else if (choice == "2")
            {
                PlayTwoPlayerGame();
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie 1 für Einzelspieler, 2 für Zweispielerspiel oder 0 zum Beenden.");
            }
        }
    }

    static void PlaySinglePlayerGame()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int attempts = 0;

        Console.Write("Geben Sie Ihren Namen ein: ");
        string playerName = Console.ReadLine();

        while (true)
        {
            attempts++;
            Console.Write($"{playerName}, geben Sie eine Zahl zwischen 1 und 100 ein: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int guessedNumber))
            {
                if (guessedNumber < secretNumber)
                {
                    Console.WriteLine("Die geratene Zahl ist niedriger als die Geheimzahl.");
                }
                else if (guessedNumber > secretNumber)
                {
                    Console.WriteLine("Die geratene Zahl ist größer als die Geheimzahl.");
                }
                else
                {
                    Console.WriteLine($"Glückwunsch, {playerName}! Sie haben die Geheimzahl {secretNumber} erraten.");
                    Console.WriteLine($"Anzahl der Versuche: {attempts}");
                    UpdateHighscores(playerName, attempts);
                    break;
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
            }
        }
    }

    static void PlayTwoPlayerGame() 
    {
        Random random = new Random();
        int secretNumber1 = random.Next(1, 101);
        int secretNumber2 = random.Next(1, 101);
        int attempts1 = 0;
        int attempts2 = 0;
        string player1Name, player2Name;

        Console.Write("Spieler 1, geben Sie Ihren Namen ein: ");
        player1Name = Console.ReadLine();
        Console.Write("Spieler 2, geben Sie Ihren Namen ein: ");
        player2Name = Console.ReadLine();

        while (true)
        {
            attempts1++;
            Console.Write($"{player1Name}, geben Sie eine Zahl zwischen 1 und 100 ein: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int guessedNumber))
            {
                if (guessedNumber < secretNumber1)
                {
                    Console.WriteLine("Die geratene Zahl ist niedriger als die Geheimzahl von Spieler 1.");
                }
                else if (guessedNumber > secretNumber1)
                {
                    Console.WriteLine("Die geratene Zahl ist größer als die Geheimzahl von Spieler 1.");
                }
                else
                {
                    Console.WriteLine($"Glückwunsch, {player1Name}! Sie haben die Geheimzahl von Spieler 1 ({secretNumber1}) erraten.");
                    Console.WriteLine($"Anzahl der Versuche: {attempts1}");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
            }
        }

        while (true)
        {
            attempts2++;
            Console.Write($"{player2Name}, geben Sie eine Zahl zwischen 1 und 100 ein: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int guessedNumber))
            {
                if (guessedNumber < secretNumber2)
                {
                    Console.WriteLine("Die geratene Zahl ist niedriger als die Geheimzahl von Spieler 2.");
                }
                else if (guessedNumber > secretNumber2)
                {
                    Console.WriteLine("Die geratene Zahl ist größer als die Geheimzahl von Spieler 2.");
                }
                else
                {
                    Console.WriteLine($"Glückwunsch, {player2Name}! Sie haben die Geheimzahl von Spieler 2 ({secretNumber2}) erraten.");
                    Console.WriteLine($"Anzahl der Versuche: {attempts2}");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
            }
        }
    }

    static void DisplayHighscores()
    {
        Console.WriteLine("Highscores:");
        foreach (var (playerName, attempts) in highscores)
        {
            Console.WriteLine($"{playerName}: {attempts} Versuche");
        }
    }

    static void UpdateHighscores(string playerName, int attempts)
    {
        highscores.Add((playerName, attempts));
        highscores.Sort((x, y) => x.Attempts.CompareTo(y.Attempts)); 
        highscores = highscores.Take(10).ToList(); 
    }
}
// Zeilen 79 bis 167 wurden mit Hilfe von ChatGPT gelöst und korrigiert.
