using System;
using static Person.Person;
using Newtonsoft.Json;


namespace Person
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            PersonStorage pr = new PersonStorage();

            Person[] arrPers = new Person[]
            {
                new Person(Guid.Parse("7c269fe7-1bfe-4ca5-908f-a5052d3e70f9"),"Имя2", "Фамилия2", 2),
                new Person(Guid.NewGuid(),"Имя3", "Фамилия3", 3),
                new Person(Guid.NewGuid(),"Имя1", "Фамилия1", 1),
                new Person(Guid.NewGuid(),"Имя4", "Фамилия4", 4),
                new Person(Guid.NewGuid(),"Имя6", "Фамилия6", 6),
                new Person(Guid.NewGuid(),"Имя7", "Фамилия7", 7),
                new Person(Guid.NewGuid(),"Имя8", "Фамилия8", 8),
            };
                        
            
            //var save = new FileProvider();

            //save.SavePersonsInFile(arrPers, "DocumentPersons.json");



            //FileProvider read = new FileProvider();
            //Person[]? readJson = read.ReadingFromFile("DocumentPersons.json");

            foreach (var item in arrPers)
            {
                Console.WriteLine(item.Print());
            }

            Console.WriteLine();

            
            pr.DeletePersonById(Guid.Parse("7c269fe7-1bfe-4ca5-908f-a5052d3e70f9"));
            pr.SortByDate();
            Console.WriteLine();

            foreach (var item in arrPers)
            {
                Console.WriteLine(item.Print());
            }


            //Console.WriteLine();
            //Console.WriteLine();

            //foreach (var item in readJson)
            //{
            //    Console.WriteLine(item.Print());
            //}



        }
    }
}