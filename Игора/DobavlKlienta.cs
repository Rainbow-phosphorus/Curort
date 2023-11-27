using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игора
{
    public partial class DobavlKlienta : Form
    {
        Sqlconection c;
        public DobavlKlienta()
        {
            InitializeComponent();
        }

        private void DobavlKlienta_Load(object sender, EventArgs e)
        {
            c = new Sqlconection();
            Up();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Sqlopen();
            string famil = textBox1.Text;
            string name = textBox2.Text;
            string othestvo = textBox3.Text;
            string seria = textBox4.Text;
            string nomer = textBox5.Text;
            string dateBrith = textBox6.Text;
            string indecsAdres = textBox7.Text;
            string gorod = textBox8.Text;
            string strit = textBox9.Text;
            string nomerDoma = textBox10.Text;
            string nowerCvart = textBox11.Text;
            string pohta = textBox12.Text;
            string password = textBox13.Text;
            //INSERT INTO `client`(`familii`, `name`, `othestvo`, `id`, `seria`, `nomer`, `date_brit`, `indecs_adres`, `gorod`, `strit`, `nomer_doma`, `nomer_cvartire`, `e - mail`, `password`) VALUES('Сливкин', 'Денис', 'Сергеевич', '45462597', '3489', '567765', '2000-12-22', '456987', 'Воронеж', 'Ленина', '34', '23', 'sliva@qwer.com', 'rt67845')
            MySqlCommand cmd2 = new MySqlCommand($"INSERT INTO client (`familii`, `name`, `othestvo`, `seria`, `nomer`, `date_brit`, `indecs_adres`, `gorod`, `strit`, `nomer_doma`, `nomer_cvartire`, `e-mail`, `password`) VALUES (\"" + famil + "\", \"" + name+ "\", \""+othestvo+"\"," +
                " \"" +seria+"\", \""+nomer+"\", \""+dateBrith+"\", \""+indecsAdres+"\", \""+gorod+"\", \""+strit+"\", \""+nomerDoma+"\", \""+nowerCvart+"\", \""+pohta+"\", \""+password+"\")", c.conection);
            cmd2.ExecuteNonQuery();
            c.Sqlclose();
            Up();
        }
        public void Up()
        {
            c.Sqlopen();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM client", c.conection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Фамилия";
            dt.Columns[2].ColumnName = "Имя";
            dt.Columns[3].ColumnName = "Отчество";
            dt.Columns[4].ColumnName = "Серия";
            dt.Columns[5].ColumnName = "Номер";
            dt.Columns[6].ColumnName = "Дата рождения";
            dt.Columns[7].ColumnName = "Индекс адреса";
            dt.Columns[8].ColumnName = "Город";
            dt.Columns[9].ColumnName = "Улица";
            dt.Columns[10].ColumnName = "Дом";
            dt.Columns[11].ColumnName = "Квартира";
            dt.Columns[12].ColumnName = "Почта";
            dt.Columns[13].ColumnName = "Пароль";

            dataGridView1.DataSource = dt;

            c.Sqlclose();
        }
    }
}
