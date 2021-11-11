using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SharkSprayqa.Helper;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SharkSprayqa.StepDefination
{
    [Binding]
    public class SharksprayAutomationSteps
    {
        [Given(@"I have navigated to Sharkspray Web Application\.")]
        public void GivenIHaveNavigatedToSharksprayWebApplication_()
        {
            BrowserConfig.Init();
            BrowserConfig.login();
        }
        
        [When(@"I set (.*) and (.*) from sheet\.")]
        public void WhenISetAndFromSheet_(string adesivetype, string modelphase)
        {
            CreateDropdowns cd = new CreateDropdowns();
            cd.Setadhesivedropdowns(adesivetype, BrowserConfig.webDriver);
            cd.Setmodelphasedropdown(modelphase, BrowserConfig.webDriver);
        }
        
        [Then(@"I compare (.*),(.*) and (.*) from the sheet and upload it\.")]
        public void ThenICompareAndFromTheSheetAndUploadIt_(string dma_filename, string compression_filename, string tension_filename)
        {
            CreateDropdowns cd = new CreateDropdowns();
            cd.FileUpload(dma_filename, compression_filename, tension_filename);
            ExplicitWaiting.waitForTime(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)BrowserConfig.webDriver;
            IWebElement element = BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._generateConstitutiveModelBtn));
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", element);
        }
        
        [Then(@"I select (.*) from sheet\.")]
        public void ThenISelectFromSheet_(string deformation_mode)
        {
            if (deformation_mode != "auto")
            {
                CreateDropdowns cd = new CreateDropdowns();
                cd.deformationmode(deformation_mode, BrowserConfig.webDriver);
            }
            else
            {
                //go with the default value 
            }
        }
        
        [Then(@"Clicked on the genrate constitutive mechanical model button\.")]
        public void ThenClickedOnTheGenrateConstitutiveMechanicalModelButton_()
        {
            ExplicitWaiting.waitForTime(2000);
            ExplicitWaiting.waitForAnElementUntilClickable(ObjectIdentifiers._generateConstitutiveModelBtn);
            BrowserConfig.webDriver.FindElement(By.XPath("//div[@class='jss532 jss534 jss533 jss580 jss576']")).Click();
            ExplicitWaiting.waitForTime(3000);
            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._generateConstitutiveModelBtn)).Click();
        }
        
        [Then(@"On visualize model page click on the save chart as png button\.")]
        public void ThenOnVisualizeModelPageClickOnTheSaveChartAsPngButton_()
        {
            WebDriverWait wait = new WebDriverWait(BrowserConfig.webDriver, TimeSpan.FromMinutes(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(ObjectIdentifiers._saveChartBtn)));
        }
        
        [Then(@"Click on export and save model check-box and description\.")]
        public void ThenClickOnExportAndSaveModelCheck_BoxAndDescription_()
        {
            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._modelNameSelectButton)).Click();
        }
        
        [Then(@"Click on the save select model button and verify it\.")]
        public void ThenClickOnTheSaveSelectModelButtonAndVerifyIt_()
        {
            BrowserConfig.webDriver.FindElement(By.XPath(ObjectIdentifiers._saveSelectedModelsButton)).Click();
            ExplicitWaiting.waitForTime(4000);
        }
        
        [Then(@"Click on the export external data package\(\*\.ZIP\) and verify if it downloaded\.")]
        public void ThenClickOnTheExportExternalDataPackage_ZIPAndVerifyIfItDownloaded_()
        {
            string _downloadpath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Test_files");
            DirectoryInfo directory = new DirectoryInfo(_downloadpath);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                dir.Delete(true);
            }
            if (System.IO.Directory.GetFiles(_downloadpath).Length == 0)
            {
                BrowserConfig.filedownloadverification();
            }
            else
            {
                Assert.Fail("There are too many files present in Test folder");

            }
        }
        
        [Then(@"Extract the downloaded file\.")]
        public void ThenExtractTheDownloadedFile_()
        {
            ExplicitWaiting.waitForAnElementUntilClickable(ObjectIdentifiers._exportModelasZipButton);
            HelpFunction hp = new HelpFunction();
            hp.extractfile();
        }
        
        [Then(@"Check the status of (.*) and remove unnecessary lines from webfile and (.*)\.")]
        public void ThenCheckTheStatusOfAndRemoveUnnecessaryLinesFromWebfileAnd_(string should_build, string ref_filename)
        {
            HelpFunction hp = new HelpFunction();
            hp.removeunwantedline_ref(should_build, ref_filename);
            hp.removeunwantedline_web();
        }
        
        //[Then(@"Comapre hashvalue of web-data and (.*) data\.")]
        //public void ThenComapreHashvalueOfWeb_DataAndData_(string ref_filename)
        //{
            
        //}
        [Then(@"Comapre hashvalue of web-data and (.*) data and store with (.*) file\.")]
        public void ThenComapreHashvalueOfWeb_DataAndDataAndStoreWithFile_(string ref_filename, string name)
        {
            CompareHashValue ch = new CompareHashValue();
            ch.compare(ref_filename,name);
        }

    }
}
