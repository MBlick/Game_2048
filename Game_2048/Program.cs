using System;

namespace Game_2048
{
    internal class Program
    {
        public const uint highestNumber = 1024;

        static void Main(string[] args)
        {
            Tile[,] tiles = new Tile[4, 4]; // creates an array for 4xX tiles
            Random rnd = new Random();
            int rnd_x, rnd_y;

            // creates all tiles
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tiles[i, j] = new Tile();
                }
                Console.WriteLine("");
            }

            bool emptyTiles = false; // emptytiles has to get true in the following for loop
            while (true)
            {
                // check if there are empty tiles left
                emptyTiles = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (tiles[i, j].Value == 0)
                        {
                            emptyTiles = true;
                            break;
                        }
                    }
                }
                if (emptyTiles == false)
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                
                // creates a new random tile
                rnd_x = rnd.Next(4000) / 1000; // generates random numbers between 0 and 3
                rnd_y = rnd.Next(4000) / 1000;
                while (tiles[rnd_y, rnd_x].Value > 0)
                {
                    rnd_x = rnd.Next(4000) / 1000;
                    rnd_y = rnd.Next(4000) / 1000;
                }
                tiles[rnd_y, rnd_x].Position_x = rnd_x;
                tiles[rnd_y, rnd_x].Position_y = rnd_y;
                tiles[rnd_y, rnd_x].Value = 2;

                // prints the field in the console
                Console.Clear(); // clear the console
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        switch (tiles[i, j].Color)
                        {
                            case ColorOfTile.white:
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case ColorOfTile.green:
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                break;
                            case ColorOfTile.yellow:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                break;
                            case ColorOfTile.magenta:
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                                break;
                            case ColorOfTile.red:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                break;
                        }
                        Console.Write("".PadRight(5, ' ') + tiles[i, j].Value + "".PadRight(5, ' '));
                        Console.ResetColor();
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                }

                // user input with movement
                Console.WriteLine("Press one of the following buttons: up, down, left or right");
                Console.WriteLine("Press the escape button to exit the game.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    //          j = 0   j = 1   j = 2   j = 3
                    // i = 0      x       x       x       x
                    // i = 1      x       x       x       x
                    // i = 2      x       x       x       x
                    // i = 3      x       x       x       x
                    case ConsoleKey.UpArrow:
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (tiles[i, j].Value > 0)
                                    {
                                        int tmp_i = i;
                                        while (tmp_i != 0)
                                        {
                                            if (tiles[tmp_i - 1, j].Value > 0)
                                            {
                                                if (tiles[tmp_i - 1, j].Value == tiles[tmp_i, j].Value)
                                                {
                                                    tiles[tmp_i - 1, j].Value += tiles[tmp_i, j].Value;
                                                    tiles[tmp_i - 1, j].SetColorOfTile();
                                                    tiles[tmp_i, j].Value = 0;
                                                    tiles[tmp_i, j].SetColorOfTile();
                                                    tmp_i--;
                                                } else
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                tiles[tmp_i - 1, j].Value = tiles[tmp_i, j].Value;
                                                tiles[tmp_i - 1, j].SetColorOfTile();
                                                tiles[tmp_i, j].Value = 0;
                                                tiles[tmp_i, j].SetColorOfTile();
                                                tmp_i--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            for (int i = 3; i >= 0; i--)
                            {
                                for (int j = 3; j >= 0; j--)
                                {
                                    if (tiles[i, j].Value > 0)
                                    {
                                        int tmp_i = i;
                                        while (tmp_i != 3)
                                        {
                                            if (tiles[tmp_i + 1, j].Value > 0)
                                            {
                                                if (tiles[tmp_i + 1, j].Value == tiles[tmp_i, j].Value)
                                                {
                                                    tiles[tmp_i + 1, j].Value += tiles[tmp_i, j].Value;
                                                    tiles[tmp_i + 1, j].SetColorOfTile();
                                                    tiles[tmp_i, j].Value = 0;
                                                    tiles[tmp_i, j].SetColorOfTile();
                                                    tmp_i++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                tiles[tmp_i + 1, j].Value = tiles[tmp_i, j].Value;
                                                tiles[tmp_i + 1, j].SetColorOfTile();
                                                tiles[tmp_i, j].Value = 0;
                                                tiles[tmp_i, j].SetColorOfTile();
                                                tmp_i++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                break;
                    case ConsoleKey.LeftArrow:
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    if (tiles[i, j].Value > 0)
                                    {
                                        int tmp_j = j;
                                        while (tmp_j != 0)
                                        {
                                            if (tiles[i, tmp_j - 1].Value > 0)
                                            {
                                                if (tiles[i, tmp_j - 1].Value == tiles[i, tmp_j].Value)
                                                {
                                                    tiles[i, tmp_j - 1].Value += tiles[i, tmp_j].Value;
                                                    tiles[i, tmp_j - 1].SetColorOfTile();
                                                    tiles[i, tmp_j].Value = 0;
                                                    tiles[i, tmp_j].SetColorOfTile();
                                                    tmp_j--;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                tiles[i, tmp_j - 1].Value = tiles[i, tmp_j].Value;
                                                tiles[i, tmp_j - 1].SetColorOfTile();
                                                tiles[i, tmp_j].Value = 0;
                                                tiles[i, tmp_j].SetColorOfTile();
                                                tmp_j--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        {
                            for (int i = 3; i >= 0; i--)
                            {
                                for (int j = 3; j >= 0; j--)
                                {
                                    if (tiles[i, j].Value > 0)
                                    {
                                        int tmp_j = j;
                                        while (tmp_j != 3)
                                        {
                                            if (tiles[i, tmp_j + 1].Value > 0)
                                            {
                                                if (tiles[i, tmp_j + 1].Value == tiles[i, tmp_j].Value)
                                                {
                                                    tiles[i, tmp_j + 1].Value += tiles[i, tmp_j].Value;
                                                    tiles[i, tmp_j + 1].SetColorOfTile();
                                                    tiles[i, tmp_j].Value = 0;
                                                    tiles[i, tmp_j].SetColorOfTile();
                                                    tmp_j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                tiles[i, tmp_j + 1].Value = tiles[i, tmp_j].Value;
                                                tiles[i, tmp_j + 1].SetColorOfTile();
                                                tiles[i, tmp_j].Value = 0;
                                                tiles[i, tmp_j].SetColorOfTile();
                                                tmp_j++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Game ended by user!");
                        return;
                    default:
                        break;                        
                }
            }
        }
    }
}
