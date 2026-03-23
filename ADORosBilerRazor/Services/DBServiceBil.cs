using ADORosBilerRazor.Models;
using Microsoft.Data.SqlClient;

namespace ADORosBilerRazor.Services
{
    public class DBServiceBil
    {
      
        protected string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(localdb)\\MSSQLLocalDB";
                builder.InitialCatalog = "RosBilDB";

                return builder.ConnectionString;
            }
        }

        public List<Bil> GetAllCars()
        {
            List<Bil> data = new List<Bil>();
            string queryStr = $"SELECT * FROM Bil";

            // Etablér DB-forbindelse (med brug af using-syntaksen)
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            // 2) Definér og udfør SQL-statement
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // 3) Processér de læste data
            while (reader.Read())
            {
                data.Add(GetRow(reader));
            }

            return data;

        }

       
        public int Create(Bil bil)
        {
            int id = NextId();
            bil.Id = id;
            string queryStr = $"INSERT INTO Bil (Id, Nummerplade, Model, PrisPrDag) VALUES (@Id, @nummerplade, @model, @prisPrDag)";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            AddParameterValues(cmd, bil);
            
            cmd.ExecuteNonQuery();
           
            return id;

        }

        private int NextId()
        {
            return GetAllCars().Select(t => t.Id).DefaultIfEmpty(0).Max() + 1;
        }

        protected Bil GetRow(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            string nummerplade = reader.GetString(reader.GetOrdinal("Nummerplade"));
            string model = reader.GetString(reader.GetOrdinal("Model"));
            int prisPrDag = reader.GetInt32(reader.GetOrdinal("PrisPrDag"));

            return new Bil(id, nummerplade, model, prisPrDag);
        }

        protected void AddParameterValues(SqlCommand cmd, Bil bil)
        {
            cmd.Parameters.AddWithValue("@Id", bil.Id);
            cmd.Parameters.AddWithValue("@Nummerplade", bil.Nummerplade);
            cmd.Parameters.AddWithValue("@Model", bil.Model);
            cmd.Parameters.AddWithValue("@PrisPrDag", bil.PrisPrDag);
        }
    }
}
