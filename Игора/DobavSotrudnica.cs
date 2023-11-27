using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Игора
{
    public partial class DobavSotrudnica : Form
    {
        public DobavSotrudnica()
        {
            InitializeComponent();
        }
        Sqlconection c = new Sqlconection();

        private void DobavSotrudnica_Load(object sender, EventArgs e)
        {
            Up();
        }
        public void Up()
        {
            this.c.Sqlopen();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sotrudnici", this.c.conection);
            cmd.ExecuteNonQuery();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);
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

            this.c.Sqlclose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //c.conection.Open();
            this.c.Sqlopen();
            int id = Convert.ToInt32(textBox9.Text);
            MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM sotrudnici WHERE id = \"" + id +"\"", this.c.conection);
            cmdDelete.ExecuteNonQuery();
            this.c.Sqlclose();
            Up();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DobavSotrudnica2 sotrudnica2 = new DobavSotrudnica2();
            sotrudnica2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            c.Sqlopen();
            int id = Convert.ToInt32(textBox10.Text);
            string dolhnost = textBox1.Text;
            string familii = textBox2.Text;
            string name = textBox3.Text;
            string othestvo = textBox4.Text;
            string login = textBox5.Text;
            string password = textBox6.Text;
            string lVxod = textBox7.Text;
            string tip = textBox8.Text;

            MySqlCommand sqlCommand = new MySqlCommand("UPDATE sotrudnici SET `dolhnost` =  \"" + dolhnost + "\", `familii` = \"" + familii + "\", `name` = \"" + name + "\", `othestvo` = \"" + othestvo + "\", `login` = \"" + login + "\", " +
                "`password` = \"" + password + "\", `last_vxod` = \"" + lVxod + "\", `tip_vxoda` = \"" + tip + "\" WHERE id = \"" + id + "\"", this.c.conection);
            sqlCommand.ExecuteNonQuery();
            c.Sqlclose();
            Up();
        }
    }
}
