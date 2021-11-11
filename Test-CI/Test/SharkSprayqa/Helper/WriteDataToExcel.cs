using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

namespace SharkSprayqa.Helper
{
    class WriteDataToExcel
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        public static string region = "";
        public static void ExcelCode(string res, string msg, int row)
        {
            Thread.Sleep(2000);
            Excel.Application x1 = new Excel.Application();
            
            bool resultExcel = (System.IO.File.Exists(path + "\\TestResults" + "\\Sharkspray_TestResult" + ".xlsx"));
            if (resultExcel)
            {
                //Open excel and write result data
                Excel.Workbook w1 = x1.Workbooks.Open(path + "\\TestResults" + "\\Sharkspray_TestResult" + ".xlsx");
                Excel._Worksheet s1 = w1.Sheets[1];
                Excel.Range r1 = s1.UsedRange;
                r1.Cells[row, 12] = res;
                r1.Cells[row, 13] = msg;
                w1.Save();
                w1.Close();
            }
            else
            {
                //Copy excel file from backup folder
                var sourcepath = path +  "\\BackupFolder" + "\\Sharkspray_TestResult" + ".xlsx";
                var destpath = path +  "\\TestResults" + "\\Sharkspray_TestResult" + ".xlsx";
                File.Copy(sourcepath, destpath);
                //Open excel and write result data
                Excel.Workbook w1 = x1.Workbooks.Open(path +  "\\TestResults" + "\\Sharkspray_TestResult" + ".xlsx");
                Excel._Worksheet s1 = w1.Sheets[1];
                Excel.Range r1 = s1.UsedRange;
                r1.Cells[row, 12] = res;
                r1.Cells[row, 13] = msg;
                w1.Save();
                w1.Close();
            }
        }
    }
}
