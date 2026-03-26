using ADORosBilerRazor.Models;
using Microsoft.Data.SqlClient;

namespace ADORosBilerRazor.Services
{
    public class DBServiceKunde : DBGenericBaseService<Kunde>
    {
        public DBServiceKunde() : base("Kunde", $"(@Id , @Navn, @Telefon, @VIP)")
        {
        }

        protected override Kunde GetRow(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            string navn = reader.GetString(reader.GetOrdinal("Navn"));
            int telefon = reader.GetInt32(reader.GetOrdinal("Telefon"));
            bool vip = reader.GetBoolean(reader.GetOrdinal("VIP"));

            return new Kunde(id, navn, telefon, vip);
        }

        protected override void AddParameterValues(SqlCommand cmd, Kunde kunde)
        {
            cmd.Parameters.AddWithValue("@Id", kunde.Id);
            cmd.Parameters.AddWithValue("@Navn", kunde.Navn);
            cmd.Parameters.AddWithValue("@Telefon", kunde.Telefon);
            cmd.Parameters.AddWithValue("@VIP", kunde.VIP);
        }
    }
}
