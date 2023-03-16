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
        public void SavePersonsInFile(Person[] persons)
        {
                        
            File.WriteAllText("DocumentPersons.json", JsonConvert.SerializeObject(persons));   
            //var serializePersons = JsonConvert.SerializeObject(persons);
            
        }

        public Person[]? ReadingFromFile(string filePath)
        {

            return JsonConvert.DeserializeObject<Person[]>(File.ReadAllText(filePath));
             
        }
    }
}