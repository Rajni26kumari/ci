using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkSprayqa.Helper
{
    class CompareHashValue
    {
        public static string _refhash = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Ref_hashvalue");
        public static string _webhash = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Web_hashvalue");
        public static string _refbackup = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\BackupFolder\\ref_hashBU");
        public static string _webbackup = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\BackupFolder\\Web_hashBU");
        public void compare(string reffile,string name)
        {

            var files = Directory.GetFiles(_refhash, "*.*", SearchOption.AllDirectories)
                                     .OrderBy(p => p).ToList();
            var files1 = Directory.GetFiles(_webhash, "*.*", SearchOption.AllDirectories)
                                     .OrderBy(p => p).ToList();
            // bool fileverification = (files != null && files1 != null);
            if (files.Count != 0 && files1.Count != 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string file = files[i];
                    var reffilename = Path.GetFileName(file);
                    var refrencefile = Path.GetFileNameWithoutExtension(file);
                    if (refrencefile.Equals(reffile))
                    {
                        Console.WriteLine("This is the required file");
                        for (int j = 0; j < files1.Count; j++)
                        {
                            string file1 = files1[j];
                            var webdownaloadfile = Path.GetFileName(file);
                            var webfile = Path.GetFileNameWithoutExtension(file1);

                            List<string> fileSource = new List<string>();
                            fileSource = System.IO.File.ReadAllLines(file).ToList();
                            File.Move(file,_refbackup + name + refrencefile);
                            List<string> fileDestination = new List<string>();
                            fileDestination = System.IO.File.ReadAllLines(file1).ToList();
                            File.Move(file1,_webbackup + name + webfile);

                            bool isEqual = Enumerable.SequenceEqual(fileSource.OrderBy(e => e), fileDestination.OrderBy(e => e));
                            if (isEqual)
                            {
                                Console.WriteLine("Files Matched");
                            }
                            else
                            {
                                Assert.Fail("Files Unmatched");
                            }

                        }
                    }
                    else
                    {
                        Assert.Fail("This is not the required file");
                    }

                }
            }
            else
            {
                Assert.Fail("No file available for comparing");
            }
        }
    }
}
