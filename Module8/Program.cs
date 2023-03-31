namespace Module8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
            Создать прототип информационной системы, в которой есть возможность работать со структурой организации
            В структуре присутствуют департаменты и сотрудники

            Каждый департамент может содержать не более 1_000_000 сотрудников.

            У каждого департамента есть поля: наименование, дата создания,
            количество сотрудников числящихся в нём (можно добавить свои пожелания)

            У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится,
            уникальный номер, размер оплаты труда, количество закрепленным за ним проектов.
             */
            var gen = new Generator();
            var workers = gen.GenerateWorkersWithDepartments(10, 3);
            var depart = gen.Departments;

            foreach (var dep in depart)
            {
                Console.WriteLine(dep.Print());
            }
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.Print());
            }
        }
    }
}