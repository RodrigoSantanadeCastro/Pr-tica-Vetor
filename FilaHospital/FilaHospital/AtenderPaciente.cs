using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaHospital
{
    internal class AtenderPaciente
    {
        public void atender()
        {

            Dao dao = new Dao();

            string sql;
            string sql2;
            MySqlCommand cmd;
            MySqlCommand cmd2;
            MySqlCommand cmd3;
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
            sql2 = "DELETE FROM fila WHERE preferencia = @prec";
            string sql3 = "DELETE FROM fila WHERE id_fila = @position";
            cmd = new MySqlCommand(sql, connection);
            cmd2 = new MySqlCommand(sql2, connection);
            cmd3 = new MySqlCommand(sql3, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                int prec = Convert.ToInt32(reader["preferencia"]);
                string position = reader["id_fila"].ToString();
                    
                if(prec == 1)
                {
                    cmd2= new MySqlCommand(sql2, connection);
                    cmd2.Parameters.AddWithValue("@preferencia",prec);
                    cmd2.ExecuteScalar();
                }
                else
                {
                    cmd3 = new MySqlCommand(sql3, connection);
                    cmd3.Parameters.AddWithValue("@position", position);
                    cmd3.ExecuteScalar();
                }
            }
            
            
            reader.Close();

            

        }
    }

}

