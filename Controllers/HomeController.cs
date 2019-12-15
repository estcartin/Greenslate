using Greenslate.Models;
using Greenslate.Repositories.Implementations; //TODO: REMOVE
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greenslate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new UsersRepository();

            var vm = new IndexViewModel();

            vm.UserNames = repo.GetAllUserNames();

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetUserProjectInfo(int id) 
        {

            var repo = new ProjectsRepository();

            

            var query = repo.GetUserProjectData(id).ToList();

            var result = JsonConvert.SerializeObject(query);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}