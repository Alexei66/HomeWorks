using SeaBattle.Logic.Ships;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml;

namespace SeaBattle.Logic.DB;

public class SqlShipRepository : IShipDBRepository
{
    private string connectionString;

    public SqlShipRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Ship GetById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM ShipDB WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            Ship ship = CreateShipFromDB(reader);

            return ship;
        }
    }

    public List<Ship> GetAllShip()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            List<Ship> ships = new List<Ship>();

            SqlCommand command = new SqlCommand("SELECT MaxSpeedShip, LengthShip, IdShip, TypeShip FROM ShipDB", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Ship ship = CreateShipFromDB(reader);

                ships.Add(ship);
            }

            return ships;
        }
    }

    public void Update(Ship ship)
    {
        throw new NotImplementedException();
        //МЕНЯТЬ ПАРАМЕТРЫ ДЛЯ КОРАБЛЯ
    }

    public bool Delete(Guid shipId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand
            ("DELETE FROM [ShipDB] WHERE IdSHip = @IdGuid", connection);

            command.Parameters.AddWithValue("@IdGuid", shipId);

            return command.ExecuteNonQuery() > 0;
        }
    }

    public bool Create(Ship ship)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand
            ("INSERT INTO [ShipDB] (MaxSpeedShip, LengthShip, IdSHip,TypeShip) VALUES (@MaxSpeed, @Length, @IdGuid, @Type)", connection);
            command.Parameters.AddWithValue("@MaxSpeed", ship.MaxSpeed);
            command.Parameters.AddWithValue("@Length", ship.Length);
            command.Parameters.AddWithValue("@IdGuid", ship.Id);
            command.Parameters.AddWithValue("@Type", ship.Type);

            return command.ExecuteNonQuery() > 0;
        }
    }

    public void MultipleInsert(IEnumerable<Ship> ships)
    {
        using SqlConnection connection = new SqlConnection(connectionString);
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
        bulkCopy.WriteToServer(data);
    }

    private Ship CreateShipFromDB(SqlDataReader reader)
    {
        int maxSpeedShip = (int)reader["MaxSpeedShip"];
        int lengthShip = (int)reader["LengthShip"];
        Guid idShip = (Guid)reader["IdShip"];
        ShipType typeShip = (ShipType)reader["TypeShip"];

        Ship ship;

        switch (typeShip)
        {
            case ShipType.Military:
                ship = new Military(maxSpeedShip, idShip);
                break;

            case ShipType.Mixed:
                ship = new Mixed(maxSpeedShip, idShip);
                break;

            case ShipType.Support:
                ship = new Support(maxSpeedShip, idShip);
                break;

            default:
                throw new Exception("Нет корабля");
        }

        ship.Length = lengthShip;

        return ship;
    }
}