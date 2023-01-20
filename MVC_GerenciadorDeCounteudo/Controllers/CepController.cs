﻿using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_GerenciadorDeCounteudo.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Cep = Business.Cep.Busca("89212-610");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Business.Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);
        }
    }
}