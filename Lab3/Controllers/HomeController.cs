using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

            public async Task<ActionResult> Index(NotificationBarModel notificationBarModel)
            {
                return View(notificationBarModel);
            }

            [HttpPost]
            public async Task<ActionResult> SaveNotificationText(NotificationBarModel notificationBarModel)
            {
                string fullFileName = "db.txt";
                StreamWriter streamWriter =
                    new StreamWriter(new FileStream(fullFileName, FileMode.Create, FileAccess.Write));
                streamWriter.Write(notificationBarModel.Content);
                streamWriter.Close();
                return RedirectToAction("Index", notificationBarModel);
            }

            public ActionResult Page2()
            {
                string fullFileName = "db.txt";
                StreamReader streamReader =
                    new StreamReader(new FileStream(fullFileName, FileMode.Open, FileAccess.Read));
                var content = streamReader.ReadToEnd();
                streamReader.Close();
                return View(new NotificationBarModel()
                {
                    Content = content
                });
            }
    }
}
