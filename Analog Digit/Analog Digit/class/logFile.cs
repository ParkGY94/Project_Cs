using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

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

        /*public List<string> load(string Filename)
        {
            List<string> list = new List<string>();

            string value = "";

            using (StreamReader rdr = new StreamReader(Filename))
            {
                while (true)
                {
                    value = rdr.ReadLine();
                    if (value != null)
                        list.Add(value);
                    else
                        break;
                }
            }
            return list;
        }*/

        /*public DataTable load(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "YES" : "NO";
            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            string sql = @"SELECT * FROM [" + fileName + "]";
            using (OleDbConnection connection = new OleDbConnection(
        @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + pathOnly + ";Mode = ReadWrite|Share Deny None; " +
            "Extended Properties='Excel 12.0; HDR=YES; IMEX=1';" +
            "Persist Security Info=False"))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }*/
    }
}
