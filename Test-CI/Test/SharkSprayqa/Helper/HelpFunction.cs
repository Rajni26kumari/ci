using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharkSprayqa.Helper
{
    class HelpFunction
    {
        public static string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
        protected static string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        public static string _downloadpath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Test_files");
        public static string _refPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Reference_files");
        public static string _refhash = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Ref_hashvalue");
        public static string _webhash = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Web_hashvalue");
        protected static string sourcefile = "";
        //public static string WebExtractPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\JSON_TC\\Test_files\\UnZippedfile");
        //C:\Users\DELL\source\repos\Sharkspray-QA\SharkSprayqa\Refrence_files\trios_hitemp_ModelFiles
        public static void SaveSelectedModelsVisible(IWebElement saveSelectModelelement)
        {
            bool visibilityBtn = saveSelectModelelement.Displayed;
            if (visibilityBtn == false)
            {
                Assert.Fail("Model Name Not selected.");

            }
        }

        public void extractfile()
        {
            //int rowCount = 2;
            //Excel.Application x1 = new Excel.Application();
            ExplicitWaiting.waitForTime(10000);

            var files = Directory.GetFiles(_downloadpath, "*.*", SearchOption.AllDirectories)
                                    .OrderBy(p => p).ToList();

            if (files.Count != 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    // ExplicitWaiting.waitForAnElementUntilClickable(ObjectIdentifiers._exportModelasZipButton);
                    string file = files[i];
                    string filename = Path.GetFileNameWithoutExtension(file);
                    string extractedfile = _downloadpath + filename;

                    if (file.EndsWith(".zip"))
                    {
                        bool Unzipfile = (System.IO.Directory.Exists(extractedfile) ? true : false);
                        //Create directory if does not exists               
                        if (Unzipfile)
                        {
                            Console.WriteLine("Directory exists");

                        }
                        else
                        {
                            Directory.CreateDirectory(extractedfile);
                        }
                        ExplicitWaiting.waitForTime(2000);
                        ZipFile.ExtractToDirectory(file, extractedfile);
                        File.Delete(file);

                    }
                    else
                    {

                        File.Delete(file);
                        Directory.Delete(extractedfile); //delete directory also
                        //Assert.Fail("No zip file present");
                    }

                }

            }
            else
            {
                Assert.Fail("No file available for extracting");

            }

        }
        public void removeunwantedline_ref(string shouldbuild, string refrence_file)
        {
            if (shouldbuild == "True")
            {
                MD5 md5 = MD5.Create();
                Dictionary<string, string> parsed = new Dictionary<string, string>();

                //

                // Dictionary<string, string> refrence_filedata = new Dictionary<string, string>();
                string filename = _refPath + refrence_file;
                bool ref_path1 = (System.IO.Directory.Exists(filename) ? true : false);
                if (ref_path1)
                {
                    var files = Directory.GetFiles(filename, "*.*", SearchOption.AllDirectories)
                                            .OrderBy(p => p).ToList();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string file = files[i];
                        if (file.EndsWith(".pdf"))
                        {
                            using (var stream = File.OpenRead(file))
                            {

                                var HashValue = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                                parsed.Add(file, HashValue);

                            }

                        }
                        else if (file.EndsWith((".xlsx")))
                        {

                            MemoryStream ms = new MemoryStream();  
                            using (FileStream fs = File.OpenRead(file))
                            using (ExcelPackage excelPackage = new ExcelPackage(fs))
                            {
                                ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets["General Info"];
                                excelWorksheet.Cells[52, 3].Value = "";
                                excelWorksheet.Cells[53, 3].Value = "";

                                for (int k = 29; k <= 51; k++)
                                {
                                    excelWorksheet.Cells[k, 4].Value = "";

                                }
                                excelPackage.SaveAs(ms);

                                var HashValue = BitConverter.ToString(md5.ComputeHash(ms)).Replace("-", string.Empty);
                                parsed.Add(file, HashValue);
                            }
                        }
                        else
                        {

                            String lines = "";
                            string line = "";
                            int counter = 0;
                            System.IO.StreamReader file1 = new System.IO.StreamReader(file);
                            while ((line = file1.ReadLine()) != null)
                            {
                                System.Console.WriteLine(line);
                                if (!line.Contains("Verification Code:") && !line.Contains("Material model exported"))
                                {
                                    lines += line;
                                }
                                //counter++;
                            }

                            byte[] bytes = Encoding.ASCII.GetBytes(lines);
                            parsed[file] = BitConverter.ToString(md5.ComputeHash(bytes.ToArray<byte>())).Replace("-", string.Empty);

                        }
                    }

                    string ref_hash = path + "\\Ref_hashvalue";
                    bool ref_hash_path = (System.IO.Directory.Exists(ref_hash) ? true : false);
                    //Create directory if does not exists               
                    if (ref_hash_path)
                    {
                        Console.WriteLine("Directory exists");
                    }
                    else
                    {
                        Directory.CreateDirectory(ref_hash);
                    }

                    foreach (KeyValuePair<string, string> item in parsed)
                    {
                        Console.WriteLine("{0} = {1}", item.Key, item.Value);
                        string keydata = item.Key;
                        string keyactualvalue = keydata.Replace(filename, string.Empty);
                        sourcefile = Path.Combine(ref_hash, Path.GetFileNameWithoutExtension(filename)) + ".txt";


                        System.IO.File.AppendAllText(sourcefile, string.Format("{0} {1} {2} {3}", keyactualvalue, " - ", item.Value, Environment.NewLine));


                    }

                }
            }

            else
            {
                Assert.Fail("No refrence file available for comparison");
            }



        }

        public void removeunwantedline_web()
        {
            MD5 md5 = MD5.Create();
            Dictionary<string, string> parsed = new Dictionary<string, string>();

            string[] fileArray = Directory.GetDirectories(_downloadpath);
            for (int i = 0; i < fileArray.Length; i++)
            {
                Console.WriteLine(fileArray[i]);
                string webfile = (fileArray[i]);


                //string filename = _downloadpath + web_file;
                bool ref_path1 = (System.IO.Directory.Exists(webfile) ? true : false);
                if (ref_path1)
                {
                    var files1 = Directory.GetFiles(webfile, "*.*", SearchOption.AllDirectories)
                                            .OrderBy(p => p).ToList();
                    for (int j = 0; j < files1.Count; j++)
                    {
                        string file = files1[j];
                        if (file.EndsWith(".pdf"))
                        {
                            using (var stream = File.OpenRead(file))
                            {

                                var HashValue = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                                parsed.Add(file, HashValue);

                            }

                        }
                        else if (file.EndsWith((".xlsx")))
                        {
                            MemoryStream ms = new MemoryStream();
                            using (FileStream fs = File.OpenRead(file))
                            using (ExcelPackage excelPackage = new ExcelPackage(fs))
                            {
                                ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                                ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets["General Info"];
                                excelWorksheet.Cells[52, 3].Value = "";
                                excelWorksheet.Cells[53, 3].Value = "";

                                for (int k = 29; k <= 51; k++)
                                {

                                    excelWorksheet.Cells[k, 4].Value = "";

                                }
                                excelPackage.SaveAs(ms); // This is the important part.

                                var HashValue = BitConverter.ToString(md5.ComputeHash(ms)).Replace("-", string.Empty);
                                parsed.Add(file, HashValue);
                            }
                        }
                        else
                        {

                            String lines = "";
                            string line = "";
                            int counter = 0;
                            System.IO.StreamReader file1 = new System.IO.StreamReader(file);
                            while ((line = file1.ReadLine()) != null)
                            {
                                System.Console.WriteLine(line);
                                if (!line.Contains("Verification Code:") && !line.Contains("Material model exported"))
                                {
                                    lines += line;
                                }
                               // counter++;
                            }

                            byte[] bytes = Encoding.ASCII.GetBytes(lines);
                            parsed[file] = BitConverter.ToString(md5.ComputeHash(bytes.ToArray<byte>())).Replace("-", string.Empty);
                        }



                    }
                }

                string ref_hash = path + "\\Web_hashvalue";
                bool ref_hash_path = (System.IO.Directory.Exists(ref_hash) ? true : false);
                //Create directory if does not exists               
                if (ref_hash_path)
                {
                    Console.WriteLine("Directory exists");
                }
                else
                {
                    Directory.CreateDirectory(ref_hash);
                }

                foreach (KeyValuePair<string, string> item in parsed)
                {
                    Console.WriteLine("{0} = {1}", item.Key, item.Value);
                    string keydata = item.Key;
                    string keyactualvalue = keydata.Replace(webfile, string.Empty);
                    sourcefile = Path.Combine(ref_hash, Path.GetFileNameWithoutExtension(webfile)) + ".txt";

                    System.IO.File.AppendAllText(sourcefile, string.Format("{0} {1} {2} {3}", keyactualvalue, " - ", item.Value, Environment.NewLine));

                }


            }

        }
    }
}
