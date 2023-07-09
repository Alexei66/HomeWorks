using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace SeaBattle.Logic.DB
{
    public class PointDBRepository : IPointDBRepository
    {
        private string connectionString;

        public PointDBRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Create(Point point)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                ("INSERT INTO [Points] (X, Y) VALUES (@X, @Y)", connection);
                command.Parameters.AddWithValue("@X", point.X);
                command.Parameters.AddWithValue("@Y", point.Y);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public void CreateTempTable(SqlConnection connection, string tempTableName)
        {
            // Создаем временную таблицу с теми же структурами столбцов, что и основная таблица

            string createTempTableQuery = $"CREATE TABLE {tempTableName} ([X] INT, [Y] INT)";

            using SqlCommand createTempTableCommand = new SqlCommand(createTempTableQuery, connection);
            createTempTableCommand.ExecuteNonQuery();
        }

        public void DropTempTable(SqlConnection connection, string tempTableName)
        {
            // Удаляем временную таблицу

            string dropTempTableQuery = $"DROP TABLE {tempTableName}";

            using SqlCommand dropTempTableCommand = new SqlCommand(dropTempTableQuery, connection);
            dropTempTableCommand.ExecuteNonQuery();
        }

        public string GenerateMergeQuery(string targetTableName, string sourceTableName)
        {
            string mergeQuery = $@"
        MERGE INTO {targetTableName} AS target
        USING {sourceTableName} AS source
        ON (target.[X] = source.[X] AND target.[Y] = source.[Y])
        WHEN MATCHED THEN
            UPDATE SET target.[X] = source.[X], target.[Y] = source.[Y]
        WHEN NOT MATCHED THEN
            INSERT ([X], [Y]) VALUES (source.[X], source.[Y]);";

            return mergeQuery;
        }

        public void CreatePoints(IEnumerable<Point> points)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string tempTableName = "#TempPoints";

            CreateTempTable(connection, tempTableName);

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = tempTableName;

                DataTable data = new DataTable();
                data.Columns.Add("X", typeof(int));
                data.Columns.Add("Y", typeof(int));

                foreach (var point in points)
                {
                    data.Rows.Add(point.X, point.Y);
                }

                bulkCopy.WriteToServer(data);
            }

            string mergeQuery = GenerateMergeQuery("[Points]", tempTableName);

            // Проверяем наличие уже существующих точек
            string checkExistingQuery = "SELECT COUNT(*) FROM [Points] WHERE [X] IN (SELECT [X] FROM " + tempTableName + ") AND [Y] IN (SELECT [Y] FROM " + tempTableName + ")";

            using SqlCommand checkExistingCommand = new SqlCommand(checkExistingQuery, connection);
            int existingCount = (int)checkExistingCommand.ExecuteScalar();

            if (existingCount > 0)
            {
                Console.WriteLine($"Найдены повторяющиеся точки.");
            }
            else
            {
                using SqlCommand mergeCommand = new SqlCommand(mergeQuery, connection);
                int rowsAffected = mergeCommand.ExecuteNonQuery();

                Console.WriteLine($"Добавлено.");
            }

            DropTempTable(connection, tempTableName);

            //using SqlCommand checkExistCommand = new SqlCommand("SELECT COUNT(*) FROM [Points]", connection);

            //using SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
            //bulkCopy.DestinationTableName = "[Points]";

            // DataTable data = new DataTable();
            //data.Columns.Add("X", typeof(int));
            //data.Columns.Add("Y", typeof(int));

            //foreach (var point in points)
            //{
            //    data.Rows.Add(point.X, point.Y);
            //}

            //bulkCopy.WriteToServer(data);

            /*using SqlConnection connection = new SqlConnection(connectionString);
         connection.Open();

         var maxId = 0;
         var command = "SELECT MAX(Id) FROM ShipDB";
         var sqlCommand = new SqlCommand(command, connection);
         var result = sqlCommand.ExecuteScalar();
         maxId = result is DBNull ? 0 : (int)result;

         using SqlBulkCopy bulkCopy = new SqlBulkCopy(connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity);
         bulkCopy.DestinationTableName = "ShipDB";

         // Define column mappings if necessary
         //bulkCopy.ColumnMappings.Add("SourceColumn1", "DestinationColumn1");
         //bulkCopy.ColumnMappings.Add("SourceColumn2", "DestinationColumn2");

         // Prepare your data (e.g., using a DataTable)
         DataTable data = new DataTable();
         data.Columns.Add("Id", typeof(int));
         data.Columns.Add("IdShip", typeof(Guid));
         data.Columns.Add("MaxSpeedShip", typeof(int));
         data.Columns.Add("LengthShip", typeof(int));
         data.Columns.Add("TypeShip", typeof(int));

         foreach (var ship in ships)
         {
             data.Rows.Add(++maxId, ship.Id, ship.MaxSpeed, ship.Length, ship.Type);

             //data.Rows.Add(5, "Value2");
         }
         // Add rows to the data table

         // Add the rows to the SQLBulkInsert object
         bulkCopy.WriteToServer(data);*/
        }

        public bool Delete(Point point)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                ("DELETE FROM [Points] WHERE X = @X AND Y=@Y", connection);

                command.Parameters.AddWithValue("@X", point.X);
                command.Parameters.AddWithValue("@Y", point.Y);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Point> GetAllPoints()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                List<Point> points = new List<Point>();

                SqlCommand command = new SqlCommand("SELECT X,Y FROM Points", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Point point = CreatePointFromDB(reader);

                    points.Add(point);
                }

                return points;
            }
        }

        public bool CreateUniquePoints(IEnumerable<Point> points)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            foreach (var point in points)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Points] WHERE X = @X AND Y = @Y", connection);
                SqlDataReader reader = command.ExecuteReader();

                command.Parameters.AddWithValue("@X", point.X);
                command.Parameters.AddWithValue("@Y", point.Y);

                return (int)command.ExecuteScalar() == 0; // нет совпадений в таблице
            }
            return false;
        }

        public Point? GetPoint(Point point)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT X,Y FROM Points", connection);

                SqlDataReader reader = command.ExecuteReader();

                command.Parameters.AddWithValue("@X", point.X);
                command.Parameters.AddWithValue("@Y", point.Y);

                if (!reader.Read())
                {
                    return null;
                }

                return CreatePointFromDB(reader);
            }
        }

        private Point CreatePointFromDB(SqlDataReader reader)
        {
            int x = (int)reader["X"];
            int y = (int)reader["Y"];

            return new Point(x, y);
        }
    }
}