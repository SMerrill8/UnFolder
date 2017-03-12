using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnFolderTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void MainTest()
        {
            UnFolder.UnFolder u = new UnFolder.UnFolder();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string testFolder = $"{desktop}\\TestFolder";
            if (Directory.Exists($"{testFolder}\\F1\\F1.1"))
            {
                Directory.Delete($"{testFolder}\\F1\\F1.1", true);
                Directory.Delete($"{testFolder}\\F1",true);
                Directory.Delete(testFolder,true);
            }
           
            var tf = Directory.CreateDirectory(testFolder);
            var f1 = tf.CreateSubdirectory("F1");
           // tf.CreateSubdirectory("F2");
            var f111 = f1.CreateSubdirectory("F1.1").CreateSubdirectory("F1.1.1");
            FileInfo file1 = new FileInfo($"{f111.FullName}\\Test_F111.txt");
            using (StreamWriter sw = file1.CreateText())
            {
                sw.WriteLine("Blah");
            }
            FileInfo file2 = new FileInfo($"{f1.FullName}\\Test_F1.txt");
            using (StreamWriter sw = file2.CreateText())
            {
                sw.WriteLine("Blah");
            }
            IEnumerable<DirectoryInfo> folders = new List<DirectoryInfo>()
            {
                f1
            };
            u.Unpack(folders,true);
        }
    }
}