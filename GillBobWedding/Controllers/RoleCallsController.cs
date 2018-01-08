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

        // POST: RoleCalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("RecordRsvp")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(
            [Bind("Name,PlusOneName,RSVP,Accommodation,Comment")] RoleCall roleCall)
        {
            var rollCall = new RoleCall();

            var path = "../GillBobWedding/wwwroot/RSVP.csv";
            
            if (ModelState.IsValid)
            {
                await roleCall.WriteCsv(path, roleCall.ToString());
              
                return Redirect("RsvpSuccess");
            }
            return Redirect("Error");
        }

        
    }
}
