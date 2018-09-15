using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseManagement.Models;
using Microsoft.AspNetCore.Authorization;
using CaseManagement.Models.Home;
using CaseManagementData;

namespace CaseManagement.Controllers
{
    public class HomeController : Controller
    {
        private ICase _cases;
        private ISubmission _submissions;

        public HomeController(ICase cases, ISubmission submissions)
        {
            _cases = cases;
            _submissions = submissions;
            // injected dependancy into patron contorller
        }
        [Authorize]
        public IActionResult Index()
        {
            var claims = User.Claims;

            int userId = Convert.ToInt16(User.Claims.ElementAt(0).Value);
            HomeDetailModel model = new HomeDetailModel
            {
                Cases = _cases.GetBreachedCases(userId),
                Submissions = _submissions.GetBreachedSubmissions(userId)

            };
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
