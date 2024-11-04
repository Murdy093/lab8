using System;
using System.Threading.Tasks;

class Program
{
    static async Task<int> CalculateSquareAsync(int number)
    {
        return await Task.Run(() => number * number);
    }

    static async Task Main(string[] args)
    {
        
        int[] numbers = { 2, 3, 4, 5 };

       
        foreach (int number in numbers)
        {
            int result = await CalculateSquareAsync(number);
            Console.WriteLine($"Квадрат числа {number} дорiвнює {result}");
        }

        // Або паралельні виклики через Task.WhenAll
        var tasks = new Task<int>[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            tasks[i] = CalculateSquareAsync(numbers[i]);
        }

        int[] results = await Task.WhenAll(tasks);
        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine($"Квадрат числа {numbers[i]} дорiвнює {results[i]}");
        }
        Console.ReadKey();
    }
}
