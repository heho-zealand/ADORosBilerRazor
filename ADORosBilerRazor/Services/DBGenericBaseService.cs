using ADORosBilerRazor.Models;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ADORosBilerRazor.Services
{
    public abstract class DBGenericBaseService<T> where T : class
    {
        private string _tableName;
        private string _parameterList;

       public DBGenericBaseService(string tableName, string parameterList)
        {
            _tableName = tableName;
            _parameterList = parameterList;
        }

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

        public List<T> SelectAllFromDB()
        {
            List<T> data = new List<T>();
            string queryStr = $"SELECT * FROM {_tableName}";

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


        public int InsertInToDB(T t)
        {
            string queryStr = $"INSERT INTO {_tableName} VALUES " + _parameterList;

            try
            {
                // Etablér DB-forbindelse (med brug af using-syntaksen)
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                // Definér SQL-statement (incl. at sætte parameter-værdier)
                SqlCommand cmd = new SqlCommand(queryStr, connection);
                AddParameterValues(cmd, t);

                // Udfør SQL-statement
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                SQLExceptionHandler(e);
            }

            return 0;
        }



        /// <summary>
        /// Læs en enkelt række fra _tableName, og brug det læste data til at
        /// oprette et objekt af typen T.
        /// </summary>
        protected abstract T GetRow(SqlDataReader reader);

        /// <summary>
        /// Sæt parameter-værdierne i den parameteriserede query-string, der skal bruges når
        /// vi skal udføre en INSERT-statement. Værdierne tages fra det givne objekt af typen T.
        /// </summary>
        protected abstract void AddParameterValues(SqlCommand cmd, T t);

        /// <summary>
        /// Simpel håndtering af exceptions
        /// </summary>
        protected void SQLExceptionHandler(SqlException sqlEx, [CallerMemberName] string? caller = null)
        {
            Console.WriteLine($"SqlException i {caller} : {sqlEx.Message}");
        }
    }
}

