using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkSprayqa.Helper
{
    class CreateDropdowns
    {
        public static string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string _destpath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\TestFiles");
        //public static string _destpath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\ss-git\\sharkspray_script\\bin\\Debug", "\\Downloads");
        protected static string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        string FileUploadtPath = path + "\\AutiITScripts" + "\\FileUpload1" + ".exe";
        By _adhesiveDropdown1 = By.XPath("//div[@id='select-newmodel_adhesive_type_select']");
        By _modelPhaseDropdown = By.XPath("//div[@id='select-newmodel_phase_select']");

        //public void test()
        //{
        //    DirectoryInfo dinfo2 = new DirectoryInfo(Environment.SpecialFolder.UserProfile + path);
        //    FileInfo[] Files2 = dinfo2.GetFiles("*.sto");
        //    foreach (FileInfo file2 in Files2)
        //    {

        //    }
        //}
        public void Setadhesivedropdowns(string adhesivetype, IWebDriver _driver)
        {
            IWebElement dropdown = _driver.FindElement(By.XPath("//div[@id='select-newmodel_adhesive_type_select']"));
            dropdown.Click();
            IList<IWebElement> options = dropdown.FindElements(By.XPath("//*[@id='menu-newmodel_adhesive_type_select']/div[2]/ul/li"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals(adhesivetype))
                {
                    option.Click();
                    break;
                }
            }
        }
        public void Setmodelphasedropdown(string modelphase, IWebDriver _driver)
        {
            IWebElement dropdown = _driver.FindElement(By.XPath("//div[@id='select-newmodel_phase_select']"));
            dropdown.Click();
            IList<IWebElement> options = dropdown.FindElements(By.XPath("//*[@id='menu-newmodel_phase_select']/div[2]/ul/li"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals(modelphase))
                {
                    option.Click();
                    break;
                }
            }
        }
        public void deformationmode(string deformationmode, IWebDriver _driver)
        {

            ExplicitWaiting.waitForTime(2000);
            IList<IWebElement> dropdowns = _driver.FindElements(By.XPath("//div[@id='select-deformation_mode_select']"));
            foreach (IWebElement dropdown in dropdowns)
            {
                dropdown.Click();
                IList<IWebElement> options = dropdown.FindElements(By.XPath("//*[@id='menu-deformation_mode_select']/div[2]/ul/li"));
                foreach (IWebElement option in options)
                {
                    if (option.Text.Equals(deformationmode))
                    {
                        option.Click();
                        break;
                    }
                }

            }


        }

        public void FileUpload(string dmafile, string compressionfile, string tesionfile)
        {
            string[] filename = new string[3] { "dmafile", "compressionfile", "tesionfile" };

            for (int i = 0; i < filename.Length; i++)
            {

                if (filename[i] == "dmafile")
                {
                    if (dmafile.Contains(","))
                    {
                        var dma1 = dmafile.Split(',');
                        for (int j = 0; j < dma1.Length; j++)
                        {
                            bool _destFolder = Directory.Exists(_destpath);
                            if (_destFolder)
                            {
                                string _destFile = _destpath + dma1[j];
                                bool _isFilePresent = File.Exists(_destFile);
                                if (_isFilePresent)
                                {
                                    ExplicitWaiting.waitForTime(3000);
                                    BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropDmaFilesIdentifierwithc)).Click();
                                    ExplicitWaiting.waitForTime(2000);
                                    string UploadFile = _destFile;
                                    try
                                    {
                                        Process.Start(FileUploadtPath, UploadFile);
                                        ExplicitWaiting.waitForTime(8000);
                                    }
                                    catch (Exception _ex)
                                    {
                                        Console.WriteLine("Error" + _ex.Message);
                                    }
                                }
                            }
                            else
                            {
                                Directory.CreateDirectory(_destpath);
                                string _destFile = _destpath + dma1[j];
                                bool _isFilePresent = File.Exists(_destFile);
                                if (_isFilePresent)
                                {
                                    ExplicitWaiting.waitForTime(3000);
                                    BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropDmaFilesIdentifierwithc)).Click();
                                    ExplicitWaiting.waitForTime(2000);
                                    string UploadFile = _destFile;
                                    try
                                    {
                                        Process.Start(FileUploadtPath, UploadFile);
                                        ExplicitWaiting.waitForTime(8000);
                                    }
                                    catch (Exception _ex)
                                    {
                                        Console.WriteLine("Error" + _ex.Message);
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        bool _destFolder = Directory.Exists(_destpath);
                        if (_destFolder)
                        {
                            string _destFile = _destpath + dmafile;
                            bool _isFilePresent = File.Exists(_destFile);
                            if (_isFilePresent)
                            {
                                ExplicitWaiting.waitForTime(3000);
                                BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropDmaFilesIdentifier)).Click();
                                ExplicitWaiting.waitForTime(2000);
                                string UploadFile = _destFile;
                                try
                                {
                                    Process.Start(FileUploadtPath, UploadFile);
                                    ExplicitWaiting.waitForTime(8000);
                                }
                                catch (Exception _ex)
                                {
                                    Console.WriteLine("Error" + _ex.Message);
                                }
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(_destpath);
                            string _destFile = _destpath + dmafile;
                            bool _isFilePresent = File.Exists(_destFile);
                            if (_isFilePresent)
                            {
                                ExplicitWaiting.waitForTime(3000);
                                BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropDmaFilesIdentifier)).Click();
                                ExplicitWaiting.waitForTime(2000);
                                string UploadFile = _destFile;
                                try
                                {
                                    Process.Start(FileUploadtPath, UploadFile);
                                    ExplicitWaiting.waitForTime(8000);
                                }
                                catch (Exception _ex)
                                {
                                    Console.WriteLine("Error" + _ex.Message);
                                }
                            }
                        }
                    }

                }
                else if (filename[i] == "compressionfile")
                {
                    bool _destFolder = Directory.Exists(_destpath);
                    if (_destFolder)
                    {
                        string _destFile = _destpath + compressionfile;
                        bool _isFilePresent = File.Exists(_destFile);
                        if (_isFilePresent)
                        {
                            ExplicitWaiting.waitForTime(3000);
                            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropCompFilesIdentifier)).Click();
                            ExplicitWaiting.waitForTime(2000);
                            string UploadFile = _destFile;
                            try
                            {
                                Process.Start(FileUploadtPath, UploadFile);
                                ExplicitWaiting.waitForTime(8000);
                            }
                            catch (Exception _ex)
                            {
                                Console.WriteLine("Error" + _ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(_destpath);
                        string _destFile = _destpath + compressionfile;
                        bool _isFilePresent = File.Exists(_destFile);
                        if (_isFilePresent)
                        {
                            ExplicitWaiting.waitForTime(3000);
                            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropCompFilesIdentifier)).Click();
                            ExplicitWaiting.waitForTime(2000);
                            string UploadFile = _destFile;
                            try
                            {
                                Process.Start(FileUploadtPath, UploadFile);
                                ExplicitWaiting.waitForTime(8000);
                            }
                            catch (Exception _ex)
                            {
                                Console.WriteLine("Error" + _ex.Message);
                            }
                        }
                    }

                }
                else if (filename[i] == "tesionfile")
                {
                    bool _destFolder = Directory.Exists(_destpath);
                    if (_destFolder)
                    {
                        string _destFile = _destpath + tesionfile;
                        bool _isFilePresent = File.Exists(_destFile);
                        if (_isFilePresent)
                        {
                            ExplicitWaiting.waitForTime(3000);
                            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropTensFilesIdentifier)).Click();
                            ExplicitWaiting.waitForTime(2000);
                            string UploadFile = _destFile;
                            try
                            {
                                Process.Start(FileUploadtPath, UploadFile);
                                ExplicitWaiting.waitForTime(8000);
                            }
                            catch (Exception _ex)
                            {
                                Console.WriteLine("Error" + _ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(_destpath);
                        string _destFile = _destpath + tesionfile;
                        bool _isFilePresent = File.Exists(_destFile);
                        if (_isFilePresent)
                        {
                            ExplicitWaiting.waitForTime(3000);
                            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._dropTensFilesIdentifier)).Click();
                            ExplicitWaiting.waitForTime(2000);
                            string UploadFile = _destFile;
                            try
                            {
                                Process.Start(FileUploadtPath, UploadFile);
                                ExplicitWaiting.waitForTime(8000);
                            }
                            catch (Exception _ex)
                            {
                                Console.WriteLine("Error" + _ex.Message);
                            }
                        }
                    }

                }
            }
        }
    }
}
