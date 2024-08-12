using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Игора
{
    class Sqlconection
    {
        public MySqlConnection conection = new MySqlConnection("server = 192.168.3.11; port = 3306;database = anna; user = anna; password = qwer1234");
        //public MySqlConnection conection = new MySqlConnection("server = 192.168.1.38; port = 3306; database = curort; user = curort; password = 1234");

        public void Sqlopen()
        {
            try
            {
                conection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблемы с подключением к серверу");
            }
        }
        public void Sqlclose()
        {
            conection.Close();
        }
    }
}
