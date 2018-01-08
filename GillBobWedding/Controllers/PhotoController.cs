using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GillBobWedding.Controllers
{
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            var paths = Directory.GetFiles(@"../GillBobWedding/wwwroot/images/uploads/").OrderByDescending(x=>x);

            var imgPaths = new List<string>();

            foreach (var path in paths)
            {
                var split = path.Split(new string[] { "images" }, StringSplitOptions.None).Last();

                var replace = split.Replace("\\", @"/");

                imgPaths.Add("/images" + replace);
            }

            var groupedPaths = new List<IEnumerable<string>>();

            var remainders = 0;

            for(var v = 0; v < imgPaths.Count; v+=4)
            {
                if (imgPaths.Count - v < 4)
                {
                    remainders = imgPaths.Count - v;
                    break;
                }
                groupedPaths.Add(new[] { imgPaths[v], imgPaths[v + 1], imgPaths[v + 2], imgPaths[v + 3] });
            }

            var remainingPaths = new List<string>();
 

            for(var v = remainders; v > 0; v--)
            {
                remainingPaths.Add(imgPaths[imgPaths.Count - v]);
            }

            groupedPaths.Add(remainingPaths.ToArray());

            return View(groupedPaths.ToList());
        }

        // GET: Upload
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var time = DateTime.Now.Ticks;
            
            // full path to file in temp location
            //var filePath = Path.GetTempFileName();
            var filePath = "../GillBobWedding/wwwroot/images/uploads/" + time + ".png";

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return View("UploadSuccess");
        }

        
    }
}