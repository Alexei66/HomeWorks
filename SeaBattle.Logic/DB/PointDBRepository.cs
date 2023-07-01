using System.Data.SqlClient;

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

        public Point? GetPoint(Point point)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT X,Y FROM Points", connection);

                SqlDataReader reader = command.ExecuteReader();

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