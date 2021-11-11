using SharkSprayqa.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SharkSprayqa.Hooks
{
    [Binding]
    public sealed class binding
    {
        static int rowCount = 3;
        

        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserConfig.Init();
        }

        [AfterStep]
        public static void InitiateScreenshotInFailure()
        {
            var _stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError != null)
            {
                if (_stepType == "Given")
                {
                    string _stepInfo = ScenarioStepContext.Current.StepInfo.Text;
                    TakeScreenshot.captureScreenshot(_stepInfo);
                }
                else if (_stepType == "Then")
                {
                    string _stepInfo = ScenarioStepContext.Current.StepInfo.Text;
                    TakeScreenshot.captureScreenshot(_stepInfo);
                }
                else if (_stepType == "When")
                {
                    string _stepInfo = ScenarioStepContext.Current.StepInfo.Text;
                    TakeScreenshot.captureScreenshot(_stepInfo);
                }
                else if (_stepType == "And")
                {
                    string _stepInfo = ScenarioStepContext.Current.StepInfo.Text;
                    TakeScreenshot.captureScreenshot(_stepInfo);
                }
            }
            else
            {
                Console.WriteLine("no error occured");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            if (ScenarioContext.Current.TestError == null)
            {
                string msg = "Data Matched successfully";
                var res = "PASS";

                WriteDataToExcel.ExcelCode(res, msg, rowCount);

            }
            else if (ScenarioContext.Current.TestError != null)
            {
                string msg = ScenarioContext.Current.TestError.Message;
                var res = "FAIL";

                WriteDataToExcel.ExcelCode(res, msg, rowCount);

            }

            rowCount = rowCount + 1;
            BrowserConfig.webDriver.Quit();
            var path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string chromedriverbatchfile = path + "\\killChromedriver" + ".bat";
            System.Diagnostics.Process.Start(chromedriverbatchfile);
            BrowserConfig.webDriver = null;

        }

        [AfterFeature]
        public static void CloseBrowserInstance()
        {
            
            
        }
    }
}
