using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace FilaHospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string controler;

            do
            {
                Console.WriteLine("Bem bindo ao programa de gerenciamento de pacientes\n");

                Console.WriteLine("Para cadastrar um paciente digite - 1\n ");

                Console.WriteLine("Para colocar um paciente na fila digite - 2\n");

                Console.WriteLine("Para listar a fila de pacientes digite - 3\n ");

                Console.WriteLine("Para atender um cliente digite - 4");

                controler = Console.ReadLine();


                if(controler == "1")
                {
                    Cadastro cadastro = new Cadastro();
                    cadastro.Cadastrar();
                    

                }
                if (controler =="2") 
                {
                    Fila fila = new Fila();
                    fila.ColocarFila();
                    
                
                }




            } while (controler !="q");
        }
    }
}
