using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Pressure_Sensor_EOL
{
    public class Database
    {
        private MySqlConnection con;
        private DataSet ds;

        private bool isOpen;

        public Database(string ip, string dbName, string uid, string pwd)
        {
            try
            {
                string strConn = "Server = " + ip + ";";
                strConn += "Database = " + dbName + ";";
                strConn += "Uid = " + uid + ";";
                strConn += "Pwd = " + pwd + ";";
                con = new MySqlConnection(strConn);
                ds = new DataSet();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        ~Database()
        {
            DisConnect();
            ds.Dispose();
        }
        public bool CONNECTED
        {
            get { return isOpen; }
        }

        public bool Connect()
        {
            bool result = false;
            try
            {
                con.Open();
                result = true;
                isOpen = true;
            }
            catch(Exception ex)
            {
                ex.ToString();
                result = false;
                isOpen = false;
            }
            return result;
        }

        public void DisConnect()
        {
            if (isOpen)
            {
                con.Close();
                con = null;
                isOpen = false;
            }
        }

        public void Select_Query(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            ds.Clear();
            ds.Reset();
            adapter.Fill(ds);
        } 

        public bool Insert_Query(string query)
        {
            bool result = false;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch(Exception ex)
            {
                ex.ToString();
                result = false;
            }
            return result;
        }
        public DataSet GetDataSet()
        {
            return ds;
        }
    }
}
