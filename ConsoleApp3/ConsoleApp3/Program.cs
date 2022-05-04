using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            var entity = new List<Entity>();
            for (int i = 0; i < 5; i++)
            {
                var ent = new Entity();
                if (i == 0)
                {
                    ent.Id = i + 1;
                    ent.ParentId = i;
                    ent.Name = "Root entity";
                }
                else
                {
                    int k = rnd.Next(0, 4);
                    ent.Id = i + 1;
                    ent.ParentId = k;
                    ent.Name = $"Child of {k} entity";
                }
                entity.Add(ent);
            }

            var result = entity
                .GroupBy(s => s.ParentId);
            foreach (var key in result)
            {
                Console.Write($"Key = {key.Key}, ");
                Console.Write($"Value = List [ ");
                foreach (var value in key)
                {
                    Console.Write($"Entity[Id = {value.Id}], ");
                }

                Console.Write(" ]");

                Console.WriteLine();
            }
        }
    }
}
