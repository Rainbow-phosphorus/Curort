using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Игора
{
    public partial class DobavSotrudnica2 : Form
    {
        public DobavSotrudnica2()
        {
            InitializeComponent();
        }
        Sqlconection c = new Sqlconection(); 

        private void DobavSotrudnica2_Load(object sender, EventArgs e)
        {
            c = new Sqlconection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.c.Sqlopen();
            string dolhnost = textBox1.Text;
            string familii = textBox2.Text;
            string name = textBox3.Text;
            string othestvo = textBox4.Text;
            string login = textBox5.Text;
            string password = textBox6.Text;
            string lVxod = textBox7.Text;
            string tip = textBox8.Text;
            MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO sotrudnici (`dolhnost`, `familii`, `name`, `othestvo`, `login`, `password`, `last_vxod`, `tip_vxoda`) " +
                "VALUES (\"" + dolhnost + "\", \"" + familii + "\", \"" + name + "\", \"" + othestvo + "\", \"" + login + "\", \"" + password + "\", \"" + lVxod + "\", \"" + tip + "\")", c.conection);
            sqlCommand.ExecuteNonQuery();
            this.c.Sqlclose();
        }
    }
}
