namespace Homework02;

class Program
{
    static void Main(string[] args)
    {
        int step = 0, player = 1, cell;
        bool gameOver = false;
        string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] message = { "Ход ноликов", "Ход крестиков" };
        string result = "Ничья";

        void PrintBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == Convert.ToString(i + 1)) Console.ForegroundColor = ConsoleColor.Green;
                else if (board[i] == "X") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(board[i] + " ");
                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
            }

            Console.ResetColor();
        }

        bool CheckWinner(string symbol)
        {
            if (symbol == board[0] && symbol == board[1] && symbol == board[2]) return true;
            if (symbol == board[3] && symbol == board[4] && symbol == board[5]) return true;
            if (symbol == board[6] && symbol == board[7] && symbol == board[8]) return true;

            if (symbol == board[0] && symbol == board[3] && symbol == board[6]) return true;
            if (symbol == board[1] && symbol == board[4] && symbol == board[7]) return true;
            if (symbol == board[2] && symbol == board[5] && symbol == board[8]) return true;

            if (symbol == board[0] && symbol == board[4] && symbol == board[8]) return true;
            if (symbol == board[2] && symbol == board[4] && symbol == board[6]) return true;

            return false;
        }

        int ReadCell()
        {
            string[] boardL = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string c = Console.ReadLine();
            bool good = boardL.Contains(c) && board[int.Parse(c) - 1] != "X" && board[int.Parse(c) - 1] != "O";
            while (!good)
            {
                Console.Write("Нужно ввeсти номер пустой клетки: ");
                c = Console.ReadLine();
                good = boardL.Contains(c) && board[int.Parse(c) - 1] != "X" && board[int.Parse(c) - 1] != "O";
            }

            return int.Parse(c);
        }

        while (!gameOver && step < board.Length)
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine(message[player]);
            cell = ReadCell();
            if (player == 1)
            {
                board[cell - 1] = "X";
                if (CheckWinner("X"))
                {
                    gameOver = true;
                    result = "Выиграли крестики";
                }
            }
            else
            {
                board[cell - 1] = "O";
                if (CheckWinner("O"))
                {
                    gameOver = true;
                    result = "Выиграли нолики";
                }
            }

            player++;
            player %= 2;
            step++;
        }

        Console.Clear();
        PrintBoard();
        Console.WriteLine(result);
    }
}