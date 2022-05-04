using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            var press = new OnKey();
            press.OnKeyPressed += (sender, symbol) => Console.WriteLine($", вы нажали на {symbol}");
            press.Run();
        }
    }

    internal class OnKey
    {
        internal event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            while(true)
            {
                Console.Write("Введите символ: ");
                var symbol = Console.ReadKey().KeyChar;
                OnKeyPressed?.Invoke(this,symbol);
                if (char.ToLower(symbol) == 'c' || char.ToLower(symbol) == 'с')
                    return;
            }
        }
    }
}
