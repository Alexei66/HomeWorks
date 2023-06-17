using SeaBattle.Logic.Ships;
using System.Data.SqlClient;

namespace SeaBattle.Logic.DB;

public class DB
{
    private string connectionString;
    private SqlConnection connection;

    public DB()
    {
        connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\desk\\testc\\SeaBattle.Logic\\DB\\Database1.mdf;Integrated Security=True";
        connection = new SqlConnection(connectionString);
    }

    public void InsertToDB(int MaxSpeedShip, int LengthShip, Guid IdShip)
    {
        SqlCommand command = new SqlCommand
        ("INSERT INTO [ShipDB] (MaxSpeedShip, LengthShip, IdShip) VALUES (@MaxSpeed, @Length, @Id)", connection);
        command.Parameters.AddWithValue("@MaxSpeed", MaxSpeedShip);
        command.Parameters.AddWithValue("@Length", LengthShip);
        command.Parameters.AddWithValue("@Id", IdShip);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }
}