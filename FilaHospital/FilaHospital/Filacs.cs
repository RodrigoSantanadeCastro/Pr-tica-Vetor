using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System.Data.SqlClient;


namespace FilaHospital
{
    internal class Fila
    {
        public void ColocarFila()
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

            Console.WriteLine("Digite o nome do paciente que deseja colocar na fila");
            string nomep = Console.ReadLine();
            string query = "SELECT COUNT(*) FROM paciente WHERE nome = @nomep";
            cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nomep", nomep);

            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {
                Console.WriteLine($"O nome {nomep} existe no banco de dados!");
            }
            else
            {
                Console.WriteLine($"O nome {nomep} não existe no banco de dados.");
            }




        }
    }
}
