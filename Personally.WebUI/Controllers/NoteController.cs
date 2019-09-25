using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Personally.WebUI.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}