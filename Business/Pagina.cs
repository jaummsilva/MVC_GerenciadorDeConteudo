using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public List<Pagina> Lista()
        {
            var lista  = new List<Pagina>();
            var paginaDb = new Database.Pagina();
            {
                foreach (DataRow data in paginaDb.Lista().Rows)
                {
                    var pagina = new Pagina();
                    pagina.Id = Convert.ToInt32(data["id"]);
                    pagina.Nome = (data["nome"]).ToString();
                    pagina.Conteudo = (data["conteudo"]).ToString();
                    pagina.Data = Convert.ToDateTime(data["data"]);

                    lista.Add(pagina);
                }
                return lista;
            }
        }

        public void Save()
        {
            new Database.Pagina().Salvar(this.Id, this.Nome, this.Conteudo, this.Data);
        }

        

        public static Pagina BuscarPorId(int id)
        {
            var pagina = new Pagina();
            var paginaDb = new Database.Pagina();
            foreach (DataRow data in paginaDb.BuscaPorId(id).Rows)
            {
                    pagina.Id = Convert.ToInt32(data["id"]);
                    pagina.Nome = (data["nome"]).ToString();
                    pagina.Conteudo = (data["conteudo"]).ToString();
                    pagina.Data = Convert.ToDateTime(data["data"]);                
            }
            return pagina;
        }
    }
}
