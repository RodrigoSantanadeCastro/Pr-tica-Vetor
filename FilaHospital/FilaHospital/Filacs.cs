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
using Google.Protobuf.WellKnownTypes;


namespace FilaHospital
{
    internal class Fila
    {
        //public void ColocarFila()
        //{
        //    Dao dao = new Dao();

        //    string sql;
        //    MySqlCommand cmd;
        //    string connectionString = "Server=localhost;Port=3306;Database=Hospital;Uid=root;Pwd='';";

        //    MySqlConnection connection = new MySqlConnection(connectionString);

        //    try
        //    {
        //        connection.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    Console.WriteLine("Digite o nome do paciente que deseja colocar na fila");
        //    string nomep = Console.ReadLine();
        //    string query = "SELECT COUNT(*) FROM paciente WHERE nome = @nomep";
        //    cmd = new MySqlCommand(query, connection);
        //    {
        //        cmd.Parameters.AddWithValue("@nomep", nomep);

        //        try
        //        {
        //            int count;
        //            count = (int)cmd.ExecuteScalar();

        //            if (count > 0)
        //            {
        //                Console.WriteLine($"O nome {nomep} existe no banco de dados!");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"O nome {nomep} não existe no banco de dados.");
        //            }

        //        }
        //        catch (Exception ex) 
        //        {
        //            Console.WriteLine(ex.Message);
        //        }

        //        return;



        //    }
        // }

        public void ColocarFila() {
            Console.WriteLine("Digite o nome do paciente que deseja colocar na fila");
            string nomep = Console.ReadLine();
            Dao dao = new Dao();
            string connectionString = "Server=localhost;Port=3306;Database=Hospital;Uid=root;Pwd='';";


            // Verifica se o valor existe na tabela de origem
            bool valorExiste = VerificarValorExistente(connectionString, nomep);

        if (valorExiste)
        {
            // Insere o valor na tabela de destino
            InserirValorNaTabelaDestino(connectionString, nomep);
            Console.WriteLine($"O valor '{nomep}' foi encontrado na tabela de origem e inserido na tabela de destino.");
        }
        else
        {
            Console.WriteLine($"O valor '{nomep}' não foi encontrado na tabela de origem.");
        }
        }

        static bool VerificarValorExistente(string connectionString, string nomep)
        {
           
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                connection.Open();

                 string query = "SELECT COUNT(*) FROM paciente WHERE nome = @nomep";
                 using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                 command.Parameters.AddWithValue("@nomep", nomep);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        static void InserirValorNaTabelaDestino(string connectionString, string nomep)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO fila (nomep) VALUES (@nomep)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nomep", nomep);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

