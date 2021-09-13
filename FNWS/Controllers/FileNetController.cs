using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FNWS.Controllers
{
    public class FileNetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
