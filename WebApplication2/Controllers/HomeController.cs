using System.Linq;
using System.Web.Mvc;
using Core;
using Core.Interfaces;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ISportTypeRepository sportTypeRepository;
        private readonly ISportListOutput sportListOutput;
        private readonly ISportComplexRepository sportComplexRepository;
        // GET: Home
        public HomeController(IUserRepository userRepository,
                               ISportTypeRepository sportTypeRepository,
                                ISportListOutput sportListOutput, 
                                ISportComplexRepository sportComplexRepository)
        {
            this.userRepository = userRepository;
            this.sportTypeRepository = sportTypeRepository;
            this.sportListOutput = sportListOutput;
            this.sportComplexRepository = sportComplexRepository;
        }

        public ActionResult Index()
        {
            var users = userRepository.GetAll();

            return View(users);
        }
        public ActionResult Index2()
        {
            return View();
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

        public ActionResult SelectSportComplex(int id)
        {
            var user = userRepository.GetById(id);
            return View(user);
        }

        public ActionResult ListSportComplex()
        {
            var list = sportComplexRepository.GetAll().Select(x=> new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.SportComplexes = list;
            return PartialView();
        }

        [HttpPost]
        public ActionResult EditSportComplex(int id, SportComplex sc)
        {
            return RedirectToAction("Index");
        }
    }
}