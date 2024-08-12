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
    public partial class Othot : Form
    {
        public Othot()
        {
            InitializeComponent();
        }
        Sqlconection c;
        private void Othot_Load(object sender, EventArgs e)
        {
            c = new Sqlconection();
            UpYslygi();
            UpZakaz();
            UpKlient();
        }

        public void UpYslygi()
        {
            c.Sqlopen();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM yslygi", c.conection);
            cmd1.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Название";
            dt.Columns[2].ColumnName = "Код услуги";
            dt.Columns[3].ColumnName = "Стоимость";
            dataGridView1.DataSource = dt;
            c.Sqlclose();
        }

        public void UpZakaz()
        {
            c.Sqlopen();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM zakaz", c.conection);
            cmd2.ExecuteNonQuery();
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da2.Fill(dt);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Код заказа";
            dt.Columns[2].ColumnName = "Дата создания";
            dt.Columns[3].ColumnName = "Время создания";
            dt.Columns[4].ColumnName = "Код клиента";
            dt.Columns[5].ColumnName = "Услуги";
            dt.Columns[6].ColumnName = "Статус";
            dt.Columns[7].ColumnName = "Дата закрытия";
            dt.Columns[8].ColumnName = "Время проката";
            dataGridView2.DataSource = dt;
            c.Sqlclose();
        }

        public void UpKlient()
        {
            c.Sqlopen();
            MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM client", c.conection);
            cmd3.ExecuteNonQuery(); 
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dt3.Columns[0].ColumnName = "ID";
            dt3.Columns[1].ColumnName = "Фамалия";
            dt3.Columns[2].ColumnName = "Имя";
            dt3.Columns[3].ColumnName = "Отчество";
            dt3.Columns[4].ColumnName = "Серия";
            dt3.Columns[5].ColumnName = "Номер";
            dt3.Columns[6].ColumnName = "Дата рождения";
            dt3.Columns[7].ColumnName = "Индекс адреса";
            dt3.Columns[8].ColumnName = "Город";
            dt3.Columns[9].ColumnName = "Улица";
            dt3.Columns[10].ColumnName = "Номер дома";
            dt3.Columns[11].ColumnName = "Номер квартиры";
            dt3.Columns[12].ColumnName = "Почта";
            dt3.Columns[13].ColumnName = "Пароль";
            dataGridView3.DataSource = dt3;
            c.Sqlclose();
        }
    }
}
