using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Игора
{
    public partial class Checkout : Form
    {
        Sqlconection c;
        public Checkout()
        {
            InitializeComponent();
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            c = new Sqlconection();
            Up();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            c.Sqlopen();
            //int id = Convert.ToInt32(textBox5.Text);
            string cod = Convert.ToString(textBox1.Text);
            string date = Convert.ToString(monthCalendar1.SelectionRange.Start.ToShortDateString());
            string time = textBox2.Text;
            string codclienta = textBox3.Text;
            string yslygi = checkedListBox1.Text;
            string statys = comboBox1.Text;
            string datezacrat =Convert.ToString(monthCalendar2.SelectionRange.Start.ToShortDateString());
            string timeprocata = textBox4.Text;
            MySqlCommand sqlCommand = new MySqlCommand($"INSERT INTO zakaz (cod_zacaza, date_sozd, time_sozd, cod_clienta, yslygi, statys, date_zacr, time_procata) VALUES (\"" +cod+"\",  \""+date+"\",  \""+time+"\",  \""+codclienta+"\",  \""+yslygi+"\",  \""+statys+"\",  \""+datezacrat+"\",  \""+timeprocata+"\") ",c.conection);
            sqlCommand.ExecuteNonQuery();
            c.Sqlclose();
            Up();
        }
        public void Up()
        {
            c.Sqlopen();
            MySqlCommand sqlCommand = new MySqlCommand($"SELECT * FROM zakaz", c.conection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Код заказа";
            dt.Columns[2].ColumnName = "Дата создания";
            dt.Columns[3].ColumnName = "Время создания";
            dt.Columns[4].ColumnName = "Код клиента";
            dt.Columns[5].ColumnName = "Услуги";
            dt.Columns[6].ColumnName = "Статус";
            dt.Columns[7].ColumnName = "Дата закрытия";
            dt.Columns[8].ColumnName = "Время проката";

            dataGridView1.DataSource = dt;

            c.Sqlclose();
        }
    }
}
