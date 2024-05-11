using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

namespace FilaHospital
{
    class Dao
    {
        private string sql;
        private string conexaostring;
        public MySqlCommand cmd;
        public MySqlConnection conexao;
        public MySqlDataReader reader;


        public Dao()
        {

        }

       

        public void inserirUsuario(string nome, string cpf)
        {

        }

        public void atenderUsuario(int id)
        {

        }
    }
}
