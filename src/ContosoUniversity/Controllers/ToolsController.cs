using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Index()
        {
            List<double> nums = new List<double>();
            var rans = new Random();
            for (int i = 0; i < 15; i++)
            {
                nums.Add(rans.NextDouble());
            }

            return View(nums);
        }
    }
}