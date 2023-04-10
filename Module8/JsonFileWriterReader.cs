﻿using Module8.Models;
using Module8.Storage;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Module8
{
    public class JsonFileWriterReader
    {
        public List<Worker> Workers { get; set; }

        public string ValidFilePath(string path)
        {
            while (!File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не существует.");
                Console.Write("Хотите создать новый файл с таким именем? (y/n): ");
                var response = Console.ReadLine();
                if (response == "y")
                {
                    using FileStream fs = File.Create(path);
                    Console.WriteLine($"Файл {path} успешно создан.");
                }
                else
                {
                    Console.Write("Введите другое название файла: ");
                    path = Console.ReadLine();
                }
            }

            return path;
        }

        public void FileSerialize(string path)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            try
            {
                path = ValidFilePath(path);

                var json = JsonSerializer.Serialize(Workers, jsonSerializerOptions);
                File.WriteAllText(path, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сериализации в файл {path}: {ex.Message}");
            }
        }

        public void FileDeserialize(string path)
        {
            var workStorage = new WorkerStorage();

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            try
            {
                path = ValidFilePath(path);

                string textJson = File.ReadAllText(path);

                var workers = JsonSerializer.Deserialize<List<Worker>>(textJson, jsonSerializerOptions);
                workStorage.AddWorkers(workers);
                Console.WriteLine($"Файл {path} успешно прочитан, данные загружены.");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}