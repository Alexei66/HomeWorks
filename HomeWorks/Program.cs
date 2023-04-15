namespace Person;

internal class Program
{
    private static void Main(string[] args)
    {
        PersonStorage personStorage = new PersonStorage();

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

        string path = "qqDocumentPersons.json";
        //var save = new FileProvider();

        //save.SavePersonsInFile(arrPers, "DocumentPersons.json");

        var fp = new FileProvider();
        try
        {
            fp.ReadingFromFile(null);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        var persFromFile = fp.AddPersonsFromFile("DocumentPersons.json"); // считали людей

        personStorage.AddPersons(persFromFile);               // добавляем считаных людей в хранилище
        personStorage.AddPerson(new Person(Guid.NewGuid(), "Имя", "Фамилия", 66));// добаляем нового человека в хранилище

        var personsFromStor = personStorage.GetPersons();
        try
        {
            var filteredPersons = fp.ImportPersonForDateRange(path, DateTime.Parse("01/01/2020"), DateTime.Parse("03/17/2023"));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        foreach (var item in personsFromStor)
        {
            Console.WriteLine(item.Print());
        }

        Console.WriteLine();

        //pr.DeletePersonById(Guid.Parse("7c269fe7-1bfe-4ca5-908f-a5052d3e70f9"));
        //pr.SortByDate();
        //Console.WriteLine();

        //foreach (var item in arrPers)
        //{
        //    Console.WriteLine(item.Print());
        //}

        //Console.WriteLine();
        //Console.WriteLine();

        //foreach (var item in readJson)
        //{
        //    Console.WriteLine(item.Print());
        //}
    }
}