using System.Web.Mvc;
using Core.Interfaces;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ISportTypeRepository sportTypeRepository;
        private readonly ISportListOutput sportListOutput;
        // GET: Home
        public HomeController(IUserRepository userRepository,
                               ISportTypeRepository sportTypeRepository,
                                ISportListOutput sportListOutput)
        {
            this.userRepository = userRepository;
            this.sportTypeRepository = sportTypeRepository;
            this.sportListOutput = sportListOutput;
        }

        public ActionResult Index()
        {
            var users = userRepository.GetAll();

            return View(users);
        }

        public ActionResult ListSportTypes()
        {
            var sportComplexes = sportTypeRepository.GetAll();
            var output = sportListOutput.GetSportList(sportComplexes);
            
            return Content(output);
        }

        protected override void Dispose(bool disposing)
        {
            userRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}