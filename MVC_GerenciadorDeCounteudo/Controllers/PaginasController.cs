using Business;
using NVelocity;
using NVelocity.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCounteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public void Criar()
        {
            DateTime data;
            DateTime.TryParse(Request["data"],out data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Conteudo = Request["conteudo"];
            pagina.Data = data;
            pagina.Save();
            Response.Redirect("/paginas");
        }
        public void Deletar(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/paginas");
        }

        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscarPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        public ActionResult Previsao(int id)
        {
            var pagina = Pagina.BuscarPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult PrevisaoNvelocity(int id)
        {
            var pagina = Pagina.BuscarPorId(id);
            Velocity.Init();

            var modelo = new
            {
                header = "Lista de dados dinamicos",
                Itens = new[]
                {
                    new {ID = 1, Nome = "Texto 1", Negrito = false},
                    new {ID = 2, Nome = "Texto 2", Negrito = false},
                    new {ID = 3, Nome = "Texto 3", Negrito = true},
                }
            };
            var velocityContext = new VelocityContext();
            velocityContext.Put("model", modelo);
            velocityContext.Put("paginas", new Pagina().Lista());

            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocityContext, new StringWriter(html), "NomeParaCapturarLogError", new StringReader(pagina.Conteudo));

            ViewBag.Html = html.ToString();
            return View();

        }

        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try {
            var pagina = Pagina.BuscarPorId(id);
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            pagina.Nome = Request["nome"];
            pagina.Conteudo = Request["conteudo"];
            pagina.Data = data;
            pagina.Save();

            TempData["sucesso"] = "Pagina alterada com sucesso";
        }
        catch(Exception err)
            {
                TempData["erro"] = "Pagina não pode ser alterada (" + err.Message + ")";
            }
            Response.Redirect("/paginas");
        }
    }
}