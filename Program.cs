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
            Person[] arrPers2 = new Person[]
            {
                new Person(Guid.NewGuid(),"имя5", "фамилия5", 5),
                new Person(Guid.NewGuid(),"имя6", "фамилия6", 6),
                new Person(Guid.NewGuid(),"имя7", "фамилия7", 7),
                new Person(Guid.NewGuid(),"имя8", "фамилия8", 8),
            };

            Person[] arrPers3 = new Person[]
            {
                new Person(Guid.NewGuid(),"имя55", "фамилия5", 55),
                new Person(Guid.NewGuid(),"имя66", "фамилия6", 66),
                new Person(Guid.NewGuid(),"имя77", "фамилия7", 77),
                new Person(Guid.NewGuid(),"имя88", "фамилия8", 88),
            };
            Person person = new Person(Guid.NewGuid(), "имя5", "фамилия5", 5);
            var personStorage = new PersonStorage();

            personStorage.AddPerson(person);
            personStorage.AddPersons(arrPers);

            foreach (var p in personStorage.GetPersons())
            {
                Console.WriteLine(p.Print());
            }
        }
    }
}