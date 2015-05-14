using MinutoSeguros.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinutosSeguros.Web.Controllers
{
    public class ArtigoController : Controller
    {
        public ActionResult Index()
        {
            var url = ConfigurationManager.AppSettings["URL_FEED_MINUTOSEGUROS"].ToString();
            var artigoBusiness = new ArtigoBusiness(url);
            var artigosAnalisados = artigoBusiness.AnalisarDezPrincipaisPalavrasNosArtigos();
            return View(artigosAnalisados);
        }       
    }
}
