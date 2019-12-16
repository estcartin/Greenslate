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
            // Load users.
            var users = usersRepository.GetAllUserNames();
            var vm = new IndexViewModel();

            // Check if data was received successfully
            if (users.Status.IsSuccessful)
            {
                vm.Users = users.Data;
            }
            else 
            {
                // Redirect to generic error page
                return Redirect("/Home/Error");
            }

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
            // Load projects for selected user.
            var query = projectsRepository.GetUserProjectData(id);

            // Serialize object to return as json.
            var result = JsonConvert.SerializeObject(query);

            // If any error it will be handled in Javascript file.
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}