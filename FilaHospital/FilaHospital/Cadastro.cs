using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FilaHospital
{
    public class Cadastro
    {

        public void Cadastrar()
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
            string nome;
            string cpf;
            Console.WriteLine("\nCadastro de paciente\n");
            Console.WriteLine("Digite o nome do paciente\n");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf\n");
            cpf = Console.ReadLine();
            sql = "insert into paciente(nome,cpf) values(@nome,@cpf)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@usuario", nome);
            cmd.Parameters.AddWithValue("@senha", cpf);

            try
            {
                int linhasafetadas = cmd.ExecuteNonQuery();

                if (linhasafetadas == 0)
                {
                    throw new Exception("Nenhuma linha foi afetada pela consulta.");
                }
                else
                {
                    Console.WriteLine("Linhas afetadas:{0}", linhasafetadas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro:{0}", ex.Message);
            }

            return;

        }
    }
}
