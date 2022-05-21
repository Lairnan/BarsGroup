﻿namespace ConsoleApp4;

internal static class Program
{
    private static readonly List<string> Messages = new List<string>();
    private static int _;
    public static void Main(string[] args)
    {
        Console.WriteLine("Приложение запущено.");
        Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
        var message = Console.ReadLine();
        while (message != "/exit")
        {
            Console.WriteLine($"Будет послано сообщение '{message}'");
            var arguments = new List<string?>();
            do
            {
                Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны - введите /end");
                arguments.Add(Console.ReadLine());
            } while (arguments[^1] != "/end");

            var messageLocal = message;
            ThreadPool.QueueUserWorkItem(callBack=>
            {
                if (messageLocal != null) Request(messageLocal, arguments.ToArray());
            });
            var key = Guid.NewGuid().ToString("D");
            Messages.Add(key);
            Console.WriteLine($"Было отправлено сообщение '{message}'. Присвоен идентификатор {key}");
            Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
            message = Console.ReadLine();
        }
        Console.WriteLine("Приложение завершает работу.");
    }

    private static void Request(string text, string?[] args)
    {
        var requestHandler = new DummyRequestHandler();
        var message = requestHandler.HandleRequest(text, args);
        Console.WriteLine(message != "Я упал, как сам просил"
            ? $"Сообщение с идентификатором {Messages[_]} получило ответ - {message}"
            : $"Сообщение с идентификатором {Messages[_]} упало с ошибкой: {message}");
        _++;
    }
}