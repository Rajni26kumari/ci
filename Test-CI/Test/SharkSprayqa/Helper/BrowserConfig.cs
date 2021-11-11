using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharkSprayqa.Helper
{
    class BrowserConfig
    {
        public static IWebDriver webDriver;
        public static readonly string _baseUrl = ConfigurationManager.AppSettings.Get("url");
        public static readonly string _browser = ConfigurationManager.AppSettings.Get("browsers");
        public static readonly string _username = ConfigurationManager.AppSettings.Get("username");
        protected static string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        public static string _downloadpath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Test_files");

        public static void Init()
        {
            Thread.Sleep(2000);
            if (webDriver != null)
            {
                //string _currentUrl = webDriver.Url;
                //if (_currentUrl.Equals(_baseUrl))
                //{

                //    Console.WriteLine("Already on sharkspray site ");
                //}
                //else
                //{
                    Goto(_baseUrl);
                //}
            }

            else
            {
                switch (_browser)
                {
                    case "Chrome":
                        //ChromeOptions is used for changing dynamic download path in runtime(in chrome)
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddUserProfilePreference("download.default_directory", _downloadpath);
                        webDriver = new ChromeDriver(chromeOptions);
                        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        break;
                    case "IE":
                        webDriver = new InternetExplorerDriver();
                        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        break;
                    case "Firefox":
                        webDriver = new FirefoxDriver();
                        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        break;
                }
                webDriver.Manage().Window.Maximize();
                Goto(_baseUrl);

            }
        }
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }

        public static void Goto(string baseUrl)
        {
            webDriver.Url = baseUrl;
        }

        public static void login()
        {
            // ExplicitWaiting.waitForAnElement(ObjectIdentifiers._next); 
            webDriver.FindElement(By.XPath(ObjectIdentifiers._username)).SendKeys(_username);
            ExplicitWaiting.waitForTime(2000);
            webDriver.FindElement(By.XPath(ObjectIdentifiers._next)).Click();
            ExplicitWaiting.waitForAnElement(ObjectIdentifiers._workac);
            webDriver.FindElement(By.XPath(ObjectIdentifiers._workac)).Click();
            ExplicitWaiting.waitForTime(5000);
            string AutoITpath = path + "\\AutiITScripts" + "\\cred" + ".exe";
            try
            {
                Process.Start(AutoITpath);
                Thread.Sleep(2000);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error" + _ex.Message);
            }


        }

        //download file at custom dynamic path
        public static void filedownloadverification()
        {
            ExplicitWaiting.waitForAnElementUntilClickable(ObjectIdentifiers._exportModelasZipButton);
            ExplicitWaiting.waitForTime(4000);

            webDriver.FindElement(By.XPath(ObjectIdentifiers._exportModelasZipButton)).Click();
            ExplicitWaiting.waitForTime(21000);
        }
        public void QuitBrowsersInstance()
        {
            webDriver.Quit();

        }
    }
}
