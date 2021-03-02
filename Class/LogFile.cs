using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pressure_Sensor_EOL
{
    class LogFile
    {
        static Excel.Application excelApp;
        static Excel.Workbook workBook;
        static Excel.Worksheet workSheet;
        
        string today;
        public string path;

        public LogFile(string Excelpath)
        {
            today = DateTime.Now.ToString("yyyy-MM-dd");
            //path = @"C:\Users\gy157\Documents\" + today + " Result - EOL.xlsx";
            if(Excelpath == "")
            {
                path = @"C:\Users\abc\Data\2020-09-22 Result - EOL.xlsx";
            }
            else
            {
                path = Excelpath;
            }
            excelApp = null;
            workBook = null;
            workSheet = null;
        }

        public void Save(List<string> data, int row, int col)
        {
            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;
                if (File.Exists(path))
                {
                    workBook = excelApp.Workbooks.Open(path);
                }
                else
                    workBook = excelApp.Workbooks.Add();

                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                excelApp.DisplayAlerts = false;

                
                workSheet.Cells[row, col + 1] = data[0];
                workSheet.Cells[row, col + 4] = data[1];
                workSheet.Cells[row, col] = data[2];
                workSheet.Cells[row, col + 2] = data[3];
                workSheet.Cells[row, col + 3] = data[4];

                workBook.SaveAs(path);
                workBook.Close(true);
                excelApp.Quit();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        public string Load(string type, int row)
        {
            string data = "";
            try
            {
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Open(path);
                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                Excel.Range range = workSheet.UsedRange;

                switch (type)
                {
                    case "Prev":
                        data = Convert.ToString((range.Cells[row + 8, 8] as Excel.Range).Value2);
                        break;
                    case "Barcode":
                        data = Convert.ToString((range.Cells[row + 8, 2] as Excel.Range).Value2);
                        break;
                    case "ID":
                        data = Convert.ToString((range.Cells[row + 8, 3] as Excel.Range).Value2);
                        break;
                }
                workBook.Close(true);
                excelApp.Quit();
                return data;
            }
            catch (Exception ex)
            {
                return data;
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        public void SaveSpec(List<string> data, int row, int col)
        {
            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;
                if (File.Exists(path))
                {
                    workBook = excelApp.Workbooks.Open(path);
                }
                else
                    workBook = excelApp.Workbooks.Add();

                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;
                
                workSheet.Cells[row, col] = data[0];
                workSheet.Cells[row + 1, col] = data[1];
                
                workBook.SaveAs(path);
                workBook.Close(true);
                excelApp.Quit();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        public List<string> LoadSpec(int row, int col)
        {
            List<string> data;
            data = new List<string>();

            try
            {
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Open(path);
                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                Excel.Range range = workSheet.UsedRange;

                data.Add(Convert.ToString((range.Cells[row, col] as Excel.Range).Value2));
                data.Add(Convert.ToString((range.Cells[row +1, col] as Excel.Range).Value2));
                data.Add(Convert.ToString((range.Cells[row, col + 2] as Excel.Range).Value2));
                data.Add(Convert.ToString((range.Cells[row + 1, col + 2] as Excel.Range).Value2));
                
                workBook.Close(true);
                excelApp.Quit();
                return data;
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        public void SaveData(string data, int row, int col)
        {
            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;
                if (File.Exists(path))
                {
                    workBook = excelApp.Workbooks.Open(path);
                }
                else
                    workBook = excelApp.Workbooks.Add();

                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                workSheet.Cells[row, col] = data;


                workBook.SaveAs(path);
                workBook.Close(true);
                excelApp.Quit();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        public List<string> LoadID(int row, int col)
        {
            List<string> ID;
            ID = new List<string>();
            string data;

            try
            {
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Open(path);
                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                Excel.Range range = workSheet.UsedRange;

                while (true)
                {
                    data = Convert.ToString((range.Cells[row, col] as Excel.Range).Value2);
                    if(row > workSheet.UsedRange.Rows.Count)
                    {
                        break;
                    }
                    ID.Add(data);
                    row++;
                }
                
                workBook.Close(true);
                excelApp.Quit();
                return ID;
            }
            catch (Exception ex)
            {
                return ID;
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }

        }
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj); // 액셀 객체 해제 
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null; throw ex;
            }
            finally
            {
                GC.Collect(); // 가비지 수집 
            }
        }
    }
}
