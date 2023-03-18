using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public struct FileProvider
    {
        public void SavePersonsInFile(Person[] persons, string path)
        {
            
            Person[]? readJson = ReadingFromFile(path);

            var newCombine = new Person[persons.Length + readJson.Length];

           
            Array.Copy(readJson, newCombine, readJson.Length);  // Копируем старые значения в новый массив

            
            Array.Copy(persons, 0, newCombine, readJson.Length, persons.Length); // Копируем новые значения в новый массив начиная с конца старых значений

            string serialized = JsonConvert.SerializeObject(newCombine, Formatting.Indented);
            File.WriteAllText(path, serialized);
            

        }

        public Person[]? ReadingFromFile(string filePath)
        {

            return JsonConvert.DeserializeObject<Person[]>(File.ReadAllText(filePath));
             
        }
    }
}