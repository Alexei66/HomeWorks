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


        public void AddPersonsFromFile(string path)
        {

            string jsonText = File.ReadAllText(path);            
            var  jsc = JsonConvert.DeserializeObject(jsonText);

            // добавляем каждый элемент объекта в массив
            foreach (var item in jsc)
            {
                Array.Resize(ref _persons, _persons.Length + 1);
                _persons[_persons.Length - 1] = item.Value.ToString();
            }

            //    int oldSize = _persons.Length;
            //    ResizeArray(oldSize + lines.Length);
            //    for (int i = 0; i < lines.Length; i++)
            //    {
            //        //string[] fields = lines[i].Split('');
            //        if ()
            //        {
            //            
            //            string name =
            //            string lastName =
            //            int age =
            //            Guid id = 
            //            DateTime dateCreation =
            //        }
            //    }
        }

        public static Person[] ImportPersonForDateRange(string filePath, DateTime startDate, DateTime endDate)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не существует.");
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                Person[] persons = JsonConvert.DeserializeObject<Person[]>(json);
                                
                Person[] filteredRecords = Array.FindAll(persons, r => r.Date >= startDate && r.Date <= endDate);

                return filteredRecords;
            }
        }

    }
}