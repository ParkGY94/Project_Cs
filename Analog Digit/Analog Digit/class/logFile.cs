using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Analog_Digit
{
    public class logFile
    {
        //저장
        public void save(string data)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            if (!File.Exists(@"C:\Users\gy157\Documents\DataFile" + today + ".csv"))
            {
                using (StreamWriter wr = new StreamWriter(@"C:\Users\gy157\Documents\DataFile" + today + ".csv", true, Encoding.UTF8))
                {
                    wr.WriteLine("Voltage, switch1, switch2, resistor1, resistor2");
                }
            }
            using(StreamWriter wr = new StreamWriter(@"C:\Users\gy157\Documents\DataFile" + today + ".csv", true, Encoding.UTF8))
            {
                if (data.IndexOf('\n') >= 0)
                    wr.Write(data);
                else
                    wr.Write(data + ",");
            }
        }

        //불러오기
        public DataTable load(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "YES" : "NO";
            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            string sql = @"SELECT * FROM [" + fileName + "]";
            using (OleDbConnection connection = new OleDbConnection(
        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        /*private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        public void save(List<string> data, int a)
        {
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            try
            {
                // Excel 첫번째 워크시트 가져오기                
                excelApp = new Excel.Application();
                wb = excelApp.Workbooks.Add();
                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

                // 데이타 넣기
                int r = 1;
                foreach (var d in data)
                {
                    ws.Cells[a, r] = d;
                    r++;
                }

                // 엑셀파일 저장
                wb.SaveAs(@"C:\Users\gy157\Documents\test3.xls", Excel.XlFileFormat.xlWorkbookNormal);
                wb.Close(true);
                excelApp.Quit();
            }
            finally
            {
                // Clean up
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }
        }

        public DataTable load()
        {
            string szConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\gy157\Documents\test3.xls;Extended Properties='Excel 8.0;HDR=No'";

            OleDbConnection conn = new OleDbConnection(szConn);
            conn.Open();
            
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
            OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);

            using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }*/
    }
}
