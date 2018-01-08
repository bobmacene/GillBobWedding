using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GillBobWedding.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_GetFilePaths()
        {
            var dirPath = @"C:\Users\bob\Source\Repos\GillBobWedding\GillBobWedding\wwwroot\images\uploads";
           
            var paths = Directory.GetFiles(dirPath);

            var imgPaths = new List<string>();

            foreach(var path in paths)
            {
                var split = path.Split(new string[] { "images" }, StringSplitOptions.None).Last();

                var replace = split.Replace("\\", @"/");

                imgPaths.Add("~/images" + replace);
            }


            Assert.IsTrue(paths.Length > 0);
        }

        [TestMethod]
        public void LinqTakeTest()
        {
            var arr = new List<int> { 1, 2, 3, 4, 5 };
            var arr1 = new List<int> { 1, 2, 3 };

            var shortened = arr.Take(3);

            Assert.AreEqual(shortened.Sum(), arr1.Sum());
        }
    }
}
