using Business;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
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
        catch {
                TempData["erro"] = "Pagina não pode ser alterada";
        }

            Response.Redirect("/paginas");
        }
    }
}