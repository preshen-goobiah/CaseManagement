﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    public class ReportsController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
