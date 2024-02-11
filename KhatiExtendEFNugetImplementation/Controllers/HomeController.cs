using DAL.Model;
using KhatiExtendedEF.Repositories;
using KhatiExtendEFNugetImplementation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KhatiExtendEFNugetImplementation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Student> _studentRepo;
        public HomeController(ILogger<HomeController> logger, IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo; 
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = new Student()
            {
                Name = "Washiq"
            };
            var result = await _studentRepo.Commit(async () =>
            {
                var res = await _studentRepo.Insert(model);
                return res;
            });
            var get = await _studentRepo.GetListAsync();

            return Ok(get);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}