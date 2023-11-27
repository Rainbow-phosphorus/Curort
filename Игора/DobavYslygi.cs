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

namespace Игора
{
    public partial class DobavYslygi : Form
    {
        Sqlconection c;
        public DobavYslygi()
        {
            InitializeComponent();
        }

        private void DobavYslygi_Load(object sender, EventArgs e)
        {
            c = new Sqlconection();
            Up();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            c.Sqlopen();

            string name = textBox1.Text;
            string codY = textBox2.Text;
            string stoimost = textBox3.Text;
            MySqlCommand cmd1 = new MySqlCommand($"INSERT INTO yslygi (`name_yslygi`, `cod_yslygi`, `stoimost`) VALUES (\"" + name + "\", \"" + codY + "\", \"" + stoimost + "\")", c.conection); 
            cmd1.ExecuteNonQuery();

            c.Sqlclose();
            Up();
        }

        public void Up()
        {
            c.Sqlopen();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM yslygi", c.conection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Наименование услуги";
            dt.Columns[2].ColumnName = "Код услуги";
            dt.Columns[3].ColumnName = "Стоимость";
            dataGridView1.DataSource = dt;

            c.Sqlclose();
        }
    }
}
