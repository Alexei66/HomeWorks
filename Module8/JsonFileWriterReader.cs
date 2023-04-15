using Module8.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Module8;

public class JsonFileWriterReader
{
    private ConsoleWriter _consoleWriter; //это приватное поле класса JsonFileWriteRead

    public JsonFileWriterReader(ConsoleWriter consoleWriter) //это конструктор
    {
        _consoleWriter = consoleWriter; //тут мы присвоили параметр, который передали нашему приватному свойству)
    }

    public string ValidFilePath(string path)
    {
        while (!File.Exists(path))
        {
            _consoleWriter.PrintLine($"Файл {path} не существует.");
            _consoleWriter.Print("Хотите создать новый файл с таким именем? (y/n): ");
            var response = _consoleWriter.Read();
            if (response == "y")
            {
                using FileStream fs = File.Create(path);
                _consoleWriter.PrintLine($"Файл {path} успешно создан.");
            }
            else
            {
                _consoleWriter.Print("Введите другое название файла: ");
                path = _consoleWriter.Read();
            }
        }

        return path;
    }

    public JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public void FileSerialize(string path, List<Worker> worker)
    {
        try
        {
            path = ValidFilePath(path);

            var json = JsonSerializer.Serialize(worker, jsonSerializerOptions);
            File.WriteAllText(path, json, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            _consoleWriter.PrintLine($"Ошибка при сериализации в файл {path}: {ex.Message}");
        }
    }

    public List<Worker> FileDeserialize(string path)
    {
        try
        {
            path = ValidFilePath(path);

            string textJson = File.ReadAllText(path);

            var workers = JsonSerializer.Deserialize<List<Worker>>(textJson, jsonSerializerOptions);

            _consoleWriter.PrintLine($"Файл {path} успешно прочитан, данные загружены.");

            return workers;
        }
        catch (JsonException e)
        {
            _consoleWriter.PrintLine($"Ошибка: {e.Message}");
        }
        return null;
    }
}