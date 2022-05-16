using System;
using System.Collections.Generic;
using System.Linq;

class StringReversal
{
    static void Main2()
    {
        string str = Console.ReadLine();

        Stack<char> stack = new Stack<char>();
        foreach (var ch in str)
        {
            stack.Push(ch);
        }

        Console.WriteLine($"Elements count = {stack.Count}");

        Console.WriteLine($"Contains: {stack.Contains('h')}");

        var arr = stack.ToArray();

        while (stack.Count > 0)
            Console.Write(stack.Pop());
    }
}

class StackSum
{
    static void Main3()
    {
        int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Stack<int> stack = new Stack<int>(elements);
        while (true)
        {
            string cmd = Console.ReadLine().ToLower();
            var cmdItems = cmd.Split(' ');
            if (cmdItems[0] == "add")
            {
                // Push two integers, given as parameters
                int n1 = int.Parse(cmdItems[1]);
                int n2 = int.Parse(cmdItems[2]);
                stack.Push(n1);
                stack.Push(n2);
            }
            else if (cmdItems[0] == "remove")
            {
                // Push two integers, given as parameters
                int count = int.Parse(cmdItems[1]);
                if (stack.Count >= count)
                {
                    for (int i = 0; i < count; i++)
                    {
                        stack.Pop();
                    }
                }
            }
            else if (cmdItems[0] == "end")
            {
                var sum = stack.Sum();
                Console.WriteLine($"Sum: {sum}");
                break;
            }
        }
    }
}

class MatchingBrackets
{
    static void Main4()
    {
        string expr = Console.ReadLine();
        var stack = new Stack<int>();
        for (int i = 0; i < expr.Length; i++)
        {
            char c = expr[i];
            if (c == '(')
                stack.Push(i);
            else if (c == ')')
            {
                int startIndex = stack.Pop();
                int endIndex = i;
                string subexpr = 
                    expr.Substring(startIndex, endIndex - startIndex + 1);
                Console.WriteLine(subexpr);
            }
        }
    }
}


class HotPotato
{
    static void Main5(string[] args)
    {
        var players = Console.ReadLine().Split(' ');
        int n = int.Parse(Console.ReadLine());
        var queue = new Queue<string>(players);
        while (queue.Count > 1)
        {
            for (int i = 1; i <= n-1; i++)
            {
                var player = queue.Dequeue();
                queue.Enqueue(player);
            }
            var lostPlayer = queue.Dequeue();
            Console.WriteLine($"Removed {lostPlayer}");
        }
        var lastPlayer = queue.Dequeue();
        Console.WriteLine($"Last is {lastPlayer}");
    }
}

class TrafficJam
{
    static void Main(string[] args)
    {
        Queue<string> queue = new Queue<string>();
        int totalCarsPassed = 0;
        int n = int.Parse(Console.ReadLine());
        while (true)
        {
            string cmd = Console.ReadLine();
            if (cmd == "green")
            {
                // Green light --> pass n cars ahead
                for (int i = 0; i < n; i++)
                {
                    if (queue.Count > 0)
                    {
                        var car = queue.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        totalCarsPassed++;
                    }
                }
            }
            else if (cmd == "end")
            {
                // Print how many cars passed in total
                Console.WriteLine($"{totalCarsPassed} cars passed the crossroad.");
                break;
            }
            else
            {
                queue.Enqueue(cmd);
            }
        }
    }
}