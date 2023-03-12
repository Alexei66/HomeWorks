using System;
using static Person.Person;

namespace Person
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person[] arrPers = new Person[]
            {
                new Person(Guid.NewGuid(),"имя1", "фамилия1", 1),
                new Person(Guid.NewGuid(),"имя2", "фамилия2", 2),
                new Person(Guid.NewGuid(),"имя3", "фамилия3", 3),
                new Person(Guid.NewGuid(),"имя4", "фамилия4", 4),
                new Person(Guid.NewGuid(),"имя6", "фамилия6", 6),
                new Person(Guid.NewGuid(),"имя7", "фамилия7", 7),
                new Person(Guid.NewGuid(),"имя8", "фамилия8", 8),
            };

            var json = System.Text.Json.JsonSerializer.Serialize<Person[]>(arrPers);
            Console.WriteLine(json);
            var test = System.Text.Json.JsonSerializer.Deserialize<Person[]>(json);
        }
    }
}