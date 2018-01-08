using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GillBobWedding.Models
{
    public class Photo
    {
        public IEnumerable<string> GetImageFilePaths()
        {
            var paths = Directory.GetFiles(@"../GillBobWedding/wwwroot/images/uploads/");

            foreach(var path in paths)
            {

            }

            return paths;
        }
    }
}
