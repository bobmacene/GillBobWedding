using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GillBobWedding.Models;
using System.IO;

namespace GillBobWedding.Controllers
{
    public class RoleCallsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RsvpError()
        {
            return View();
        }

        public IActionResult RsvpSuccess()
        {
            return View();
        }

        // POST: RoleCalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("RecordRsvp")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(
            [Bind("Name,PlusOneName,RSVP,Comment")] RoleCall roleCall)
        {
            var rollCall = new RoleCall();

            var path = "../GillBobWedding/wwwroot/RSVP.csv";


            var correctEntries = roleCall.Name != string.Empty || roleCall.Name != null;
            if(correctEntries) correctEntries = roleCall.RSVP != RSVP.NotResponded;

            if (correctEntries)
            {
                await roleCall.WriteCsv(path, roleCall.ToString());
              
                return RedirectToAction("RsvpSuccess", "RoleCalls");
            }
            return RedirectToAction("RsvpError", "RoleCalls");
        }

        
    }
}
