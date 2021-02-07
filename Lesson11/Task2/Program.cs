using System;
using System.Threading;

namespace Task_2
{
    static class Matrix
    {
        static Random rand = new Random();
        static object block = new object();

        public static void Rain(object x)
        {
            int stringLength = rand.Next(5, Console.WindowHeight);
            int X = (int)x; 
            int Y = rand.Next(0, Console.WindowHeight);
            int currY = 0; 
            for (int i = 0; i < stringLength; i++)
            {
                lock (block)
                {
                    if (Y == Console.WindowHeight - 1)
                    {
                        Y = 0;
                        Console.SetCursorPosition(X, Y);
                        currY = Y + 1;
                    }
                    else
                    {
                        Console.SetCursorPosition(X, Y++);
                        currY = Y + 1;
                    } 
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", Convert.ToChar(rand.Next(100, 126)));
                    if (currY > 3 && i >= 2)
                    {
                        Console.SetCursorPosition(X, currY - 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", Convert.ToChar(rand.Next(100, 126)));

                        Console.SetCursorPosition(X, currY - 4);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0}", Convert.ToChar(rand.Next(100, 126)));
                    }
                    else if (currY <= 2)
                    {
                        Console.SetCursorPosition(X, currY - 4 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", Convert.ToChar(rand.Next(100, 126)));

                        Console.SetCursorPosition(X, currY - 5 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0}", Convert.ToChar(rand.Next(100, 126)));
                    }
                    if (i == stringLength - 1)
                    {
                        if (Y >= stringLength)
                        {
                            Console.SetCursorPosition(X, Y - stringLength);
                            Console.Write(' ');
                            i--;
                        }
                        else
                        {
                            Console.SetCursorPosition(X, Console.WindowHeight - stringLength + Y);
                            Console.Write(' ');
                            i--;
                        }
                    }
                    Thread.Sleep(0);
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            for (int MaxtrixWidth = 0; MaxtrixWidth < Console.WindowWidth - 1;)
            {
                new Thread(new ParameterizedThreadStart(Matrix.Rain)).Start(MaxtrixWidth);
                MaxtrixWidth += 2;
            }
        }
    }
}