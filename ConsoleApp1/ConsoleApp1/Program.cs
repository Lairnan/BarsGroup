using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            var Press = new OnKey();
            Press.OnKeyPressed += (sender, symbol) => Console.WriteLine($"Вы нажали на {symbol}");
            Press.Run();
        }
    }
    internal class OnKey
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            while (true)
            {
                Console.Write("Введите символ: ");
                var symbol = Console.ReadKey();
                Console.WriteLine();
                OnKeyPressed?.Invoke(this, symbol.KeyChar);
                if (char.ToLower(symbol.KeyChar) == 'c') {
                    return;
                }
            }
        }
    }
}
