using System;
using static Person.Person;
using Newtonsoft.Json;


namespace Person
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person[] arrPers = new Person[]
            {
                new Person(Guid.NewGuid(),"Имя2", "Фамилия2", 2),
                new Person(Guid.NewGuid(),"Имя3", "Фамилия3", 3),
                new Person(Guid.NewGuid(),"Имя1", "Фамилия1", 1),
                new Person(Guid.NewGuid(),"Имя4", "Фамилия4", 4),
                new Person(Guid.NewGuid(),"Имя6", "Фамилия6", 6),
                new Person(Guid.NewGuid(),"Имя7", "Фамилия7", 7),
                new Person(Guid.NewGuid(),"Имя8", "Фамилия8", 8),
            };


            //string json = System.Text.Json.JsonSerializer.Serialize<Person[]>(arrPers);
            //Console.WriteLine(json);
            //Console.WriteLine( );

            //string JsonObj = JsonConvert.SerializeObject(arrPers);
            //Console.WriteLine(JsonObj);
            //var JsonObject = JsonConvert.DeserializeObject(JsonObj);
            //Console.WriteLine(JsonObject);
            //var test = System.Text.Json.JsonSerializer.Deserialize<Person[]>(json);
            //Console.WriteLine(test);

            var save = new FileProvider();

            save.SavePersonsInFile(arrPers);



            //FileProvider read = new FileProvider();
            //Person[]? readJson =read.ReadingFromFile("DocumentPersons.json");

            //foreach (var item in readJson)
            //{
            //    Console.WriteLine(item.Print());
            //}


            /*
             [
               {
                 "Name": "Имя1",
                 "LastName": "Фамилия1",
                 "Age": 1,
                 "Id": "17f33b1c-6f86-483f-b377-dcfaefeb804b"
             
               },
               {
                 "Name": "Имя2",
                 "LastName": "Фамилия2",
                 "Age": 2,
                 "Id": "01a07826-fca2-487b-88d7-adb32cc2ea0d"
             
               },
               {
                 "Name": "Имя3",
                 "LastName": "Фамилия3",
                 "Age": 3,
                 "Id": "c4518093-93cf-47cd-9f5a-1c304319bb37"
             
               },
               {
                 "Name": "Имя4",
                 "LastName": "Фамилия4",
                 "Age": 4,
                 "Id": "a9006c09-684d-4279-8338-f266cd8dc8c8"
             
               },
               {
                 "Name": "Имя5",
                 "LastName": "Фамилия5",
                 "Age": 5,
                 "Id": "1274fd77-180a-414c-8b2b-24853da00631"
             
               }              
               
             ]
             */

        }
    }
}