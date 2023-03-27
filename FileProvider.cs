using Newtonsoft.Json;

namespace Person;

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
       if( filePath== null)  throw new ArgumentNullException($"{filePath} был Null");
        return JsonConvert.DeserializeObject<Person[]>(File.ReadAllText(filePath));

    }


    public Person[]? AddPersonsFromFile(string path)
    {

        string jsonText = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<Person[]>(jsonText);
                    
    }

    public  Person[] ImportPersonForDateRange(string filePath, DateTime startDate, DateTime endDate)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Файл {filePath} не существует.");
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string json = sr.ReadToEnd();
            Person[] persons = JsonConvert.DeserializeObject<Person[]>(json);

            Person[] filteredRecords = Array.FindAll(persons, p => p.DateCreation >= startDate && p.DateCreation <= endDate);

            return filteredRecords;
            
        }
    }

}