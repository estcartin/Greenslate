using Greenslate.Models;
using Greenslate.Repositories.Implementations; //TODO: REMOVE
using Greenslate.Repositories.Interfaces;
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
        readonly IUsersRepository usersRepository;
        readonly IProjectsRepository projectsRepository;

        public HomeController(IUsersRepository userRepo, IProjectsRepository projectsRepo)
        {
            usersRepository = userRepo;
            projectsRepository = projectsRepo;
        }

        public ActionResult Index()
        {
            var vm = new IndexViewModel();

            vm.UserNames = usersRepository.GetAllUserNames();

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
            var query = projectsRepository.GetUserProjectFromCode(id);

            var result = JsonConvert.SerializeObject(query);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}