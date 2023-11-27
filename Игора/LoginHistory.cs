using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Игора
{
    public partial class LoginHistory : Form
    {
        Sqlconection c;
        public LoginHistory()
        {
            InitializeComponent();
        }

        private void LoginHistory_Load(object sender, EventArgs e)
        {
            
            c = new Sqlconection();
            c.Sqlopen();

            MySqlCommand sqlCommand = new MySqlCommand($"SELECT * FROM sotrudnici", c.conection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Должность";
            dt.Columns[2].ColumnName = "Фамилия";
            dt.Columns[3].ColumnName = "Имя";
            dt.Columns[4].ColumnName = "Отчество";
            dt.Columns[5].ColumnName = "Логин";
            dt.Columns[6].ColumnName = "Пароль";
            dt.Columns[7].ColumnName = "Последний вход";
            dt.Columns[8].ColumnName = "Тип входа";

            dataGridView1.DataSource = dt;

            MySqlCommand sqlCommandcom = new MySqlCommand($"SELECT login FROM sotrudnici", c.conection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlCommandcom);
            DataTable dt2 = new DataTable();
            mySqlDataAdapter.Fill(dt2);
            comboBox1.DisplayMember = "login";
            comboBox1.DataSource = dt2;
           

            c.Sqlclose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Sqlopen();

            string log = comboBox1.Text;

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sotrudnici WHERE login = \"" + log + "\"", c.conection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            DataTable dt3 = new DataTable();    
            sqlDataAdapter.Fill(dt3);
            dataGridView1.DataSource= dt3;

            c.Sqlclose();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Sqlopen();

            string date = textBox1.Text;

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sotrudnici WHERE last_vxod = \"" + date + "\"", c.conection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            DataTable dt3 = new DataTable();
            sqlDataAdapter.Fill(dt3);
            dataGridView1.DataSource = dt3;

            c.Sqlclose();
        }
    }
}
