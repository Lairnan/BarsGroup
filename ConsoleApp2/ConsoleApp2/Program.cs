using System;


public class Program
{
    static void Main(string[] args)
    {
        string path = Console.ReadLine();
        string path2 = Console.ReadLine();
        string path3 = Console.ReadLine();
        LocalFileLogger<string> localFile = new LocalFileLogger<string>(path);
        localFile.LogInfo(path);
        localFile.LogWarning(path2);
        localFile.LogError(path3, new FormatException());
        Console.ReadKey();
    }
    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }
    public class LocalFileLogger<T> : ILogger
    {
        private string path;
        private string GenericTypeName => typeof(T).Name;

        public LocalFileLogger(string path)
        {
            this.path = path;
        }
        public void LogInfo(string message)
        {
            Console.WriteLine($"[Info]:[{GenericTypeName}]:{message}");
        }
        public void LogWarning(string message)
        {
            Console.WriteLine($"[Warning]:[{GenericTypeName}]:{message}");
        }
        public void LogError(string message, Exception ex)
        {
            Console.WriteLine($"[Info]:[{GenericTypeName}]:{message}, {ex.Message}");
        }
    }
}