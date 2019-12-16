using Greenslate.Models;
using Greenslate.Repositories.Interfaces;
using Newtonsoft.Json;
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

            vm.Users = usersRepository.GetAllUserNames();

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
            var query = projectsRepository.GetUserProjectData(id);

            var result = JsonConvert.SerializeObject(query);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}