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
                        
                File.AppendAllText("DocumentPersons.json", JsonConvert.SerializeObject(persons));               
            
        }

        public void ReadingFromFile(string filePath)
        {

            return JsonConvert.DeserializeObject<Person[]>(File.ReadAllText(filePath));
             
        }
    }
}