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
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace Игора
{
    public partial class Entrance : Form
    {
        Sqlconection c;

        public Entrance()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(255, 255, 255);
            ExitButton.BackColor = Color.FromArgb(73, 140, 81);
            VPasswordButton.BackColor = Color.FromArgb(73, 140, 81);
            c = new Sqlconection();
        }

        
        private void VPasswordButton_Click(object sender, EventArgs e)
        {
            if(PasswordBox.PasswordChar == '\0')
            {
                PasswordBox.PasswordChar = '*';
            }
            else if(PasswordBox.PasswordChar == '*')
            {
                PasswordBox.PasswordChar = '\0';
            }
        }

        bool Blocapha = false;
        bool bok = true;
        
        int m;

        public static bool blok = true;
        public void Bloc()
        {
            blok = false;
            timer1.Start();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            B();
        }
        public string B()
        {
            string log = LoginBox.Text;
            string pas = PasswordBox.Text;
           
            c.Sqlopen();
            MySqlCommand sqlCommand = new MySqlCommand($"SELECT id FROM sotrudnici WHERE login =\"" +log + "\"  and password =\"" + pas + "\"", c.conection);
            object q = sqlCommand.ExecuteScalar();
            string srav = "";
            if(q != null)
            {
                srav = q.ToString();
            }

            c.Sqlclose();
            Vxod(srav);
            return srav;
        }

        public void Vxod (string srav)
        {
            bool tip = false;
            if (srav != "")
            {
                c.Sqlopen();
                MySqlCommand cmd = new MySqlCommand($"SELECT name, familii, othestvo, login, password, dolhnost FROM sotrudnici WHERE id = \"" +srav+"\"", c.conection);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(table);

                string[] mas = new string[table.Columns.Count];
                for (int i =0; i<table.Columns.Count; i++)
                {
                    mas[i] = table.Rows[0][i].ToString();
                }
                if (mas[5] == "Администратор")
                {
                    Admin a = new Admin();
                    a.NameS(Convert.ToString(mas[0]), Convert.ToString(mas[1]), Convert.ToString(mas[5]));
                    tip = true;
                    a.Show();
                    
                }
                else if (mas[5] == "Продавец")
                {
                    Prodovex p = new Prodovex();
                    p.NameS(Convert.ToString(mas[0]), Convert.ToString(mas[1]), Convert.ToString(mas[5]));
                    tip = true;
                    p.Show();
                    
                }
                else if (mas[5] == "Старший смены")
                {
                    StarSmen s = new StarSmen();
                    s.NameS(Convert.ToString(mas[0]), Convert.ToString(mas[1]), Convert.ToString(mas[5]));
                    tip = true;
                    s.Show();
                    
                }
                else
                {
                    tip = false;
                }
                c.Sqlclose();
                History(mas,tip);
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");

            }
        }

        public void History(string[]mas, bool tip)
        {
            c.Sqlopen();
            DateTime dt = DateTime.Now;
            MySqlCommand hisCom = new MySqlCommand("INSERT INTO sotrudnici (`dolhnost`, `familii`, `name`, `othestvo`, `login`, `password`, `last_vxod`, `tip_vxoda`) VALUES (\"" + mas[5] + "\", \"" + mas[1] + "\", \"" + mas[0] + "\", \"" + mas[2] + "\", \"" + mas[3] + "\", \"" + mas[4] + "\", \"" + Convert.ToString(dt) + "\", \"" + tip + "\")", c.conection);
            hisCom.ExecuteNonQuery();
            c.Sqlclose();
        }

        int g = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            g++;
            if(g==6)
            {
                blok = true;
                MessageBox.Show("3 минуты прошло блокировка снята");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            m++;
        }

        
    }
}
