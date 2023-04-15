using Module8.Models;
using Module8.Storage;

namespace Module8;

public static class App
{
    public static void Start()
    {
        #region Commands

        string allCommands =
       $" \n\t{(int)MenuItem.ShowAll}-показать всех сотрудников," +
                $" \n\t{(int)MenuItem.GenWorkWithDep}-генератор сотрудников с департаментами," +
                $" \n\t{(int)MenuItem.GenDep}-генератор департаметов, " +
                $" \n\t{(int)MenuItem.AddWork}-добавить сотрудника, " +
                $" \n\t{(int)MenuItem.DelWorkById}-удаление сотрудника по Guid," +
                $" \n\t{(int)MenuItem.ChangeWorkSalary}-изменить ЗП сотрудника," +
                $" \n\t{(int)MenuItem.DelDep}-удаление департамента," +
                $" \n\t{(int)MenuItem.SaveJson}-сохранение данные в json," +
                $" \n\t{(int)MenuItem.LoadJson}-загрузить данные из json," +
                $" \n\t{(int)MenuItem.SortByAgeAndPrint}-сортировка и печать сотрудников по возрасту," +
                $" \n\t{(int)MenuItem.SortBySalaryAndNameAndPrint}-сортировка и печать сотрудников по ЗП и имени," +
                $" \n\t66-test " +
                $" \n\t{(int)MenuItem.Exit}-Выход ";

        #endregion Commands

        var workStorage = new WorkerStorage();

        var depStorage = new DepartmentStorage();

        var sort = new Sort();

        var cw = new ConsoleWriter();

        var fileJson = new JsonFileWriterReader(cw);

        var menuHandler = new MenuHandler(cw, workStorage, depStorage, sort, fileJson);

        bool isWork = true;

        while (isWork)
        {
            try
            {
                cw.PrintLine(allCommands);
                int inputComand = menuHandler.IntFromConsole();
                menuHandler.HandleCommand(inputComand);
                if (inputComand < 0 || inputComand > 9)
                {
                    isWork = false;
                }
            }
            catch (Exception ex)
            {
                cw.PrintLine(ex.Message);
            }
        }
    }
}