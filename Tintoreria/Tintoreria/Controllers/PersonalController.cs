using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Categoria
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            PersonalListModel lista = PersonalListModel.Get();

            IPagedList<PersonalModel> personal = null;
            personal = lista.ToPagedList(pageIndex, pageSize);

            return View(personal);
        }
    }
}