using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        private string sqlConnection()
        {
            return ConfigurationManager.AppSettings["sqlConnection"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "select * from paginas";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;

            }
        }

        public void Salvar(int id, string nome, string conteudo, DateTime data)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "insert into paginas(nome,conteudo,data) values('"+nome+"','"+conteudo+"','"+data.ToString("yyyy-MM-dd hh:mm:ss")+"')";
                if(id != 0)
                {
                    queryString = "update paginas set nome='" + nome + "',conteudo='" + conteudo + "', data='" + data.ToString("yyyy-MM-dd hh:mm:ss") + "'  where id=" + id;
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "select * from paginas where id=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;

            }
        }
    }
}
