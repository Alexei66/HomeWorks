using SeaBattle.Logic.Ships;
using System.Data.SqlClient;

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

    public void Save(Ship ship)
    {
        throw new NotImplementedException();
    }

    public void Update(Ship ship)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid ship)
    {
        throw new NotImplementedException();
    }

    public void Create(Ship ship)
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

            command.ExecuteNonQuery();
        }
    }
}