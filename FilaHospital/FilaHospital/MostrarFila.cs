using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaHospital
{
    internal class MostrarFila
    {
        public void ShowFila()
        {
            Dao dao = new Dao();

            string sql;
            MySqlCommand cmd;
            string connectionString = "Server=localhost;Port=3306;Database=Hospital;Uid=root;Pwd='';";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sql = "SELECT * FROM fila";
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("posição da fila" + reader["id_fila"]  );
                Console.WriteLine(reader["nomep"] + "\npreferencia:" + reader["preferencia"]+"\n");
            }

            reader.Close();
        }
    }
}
            

    

